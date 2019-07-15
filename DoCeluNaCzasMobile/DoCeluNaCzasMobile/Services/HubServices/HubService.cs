using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.HubServices
{
    public class HubService
    {
        const int DelayOnRetry = 1000;
        const int NumberOfRetries = 3;
        readonly IHubProxy _hubProxy;
        readonly HubConnection _hubConnection;

        public HubService(string hubConnectionUrl, string hubName)
        {
            _hubConnection = new HubConnection(hubConnectionUrl);
            _hubProxy = _hubConnection.CreateHubProxy(hubName);
        }

        public async Task StartConnection() => await _hubConnection.Start();

        public bool IsConnected() => _hubConnection.State == ConnectionState.Connected;

        public void StopConnection() => _hubConnection.Stop();

        public async Task<TDataType> GetData<TDataType, TParamType>(string methodName, params object[] args) where TDataType : new()
        {
            for (var i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                    if(args.Length > 0)
                        return await _hubProxy.Invoke<TDataType>(methodName, (TParamType) args[0]);
                    return await _hubProxy.Invoke<TDataType>(methodName);
                }
                catch (InvalidOperationException ioe)
                {
                    await Task.Delay(DelayOnRetry);
                }
                catch (Exception e) when (i < NumberOfRetries)
                {
                    await Task.Delay(DelayOnRetry);
                }
            }

            return new TDataType();
        }
    }
}
