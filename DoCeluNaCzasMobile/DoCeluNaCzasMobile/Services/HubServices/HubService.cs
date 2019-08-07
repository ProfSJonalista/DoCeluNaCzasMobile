using DoCeluNaCzasMobile.DataAccess.Repository.Net.Helpers;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DoCeluNaCzasMobile.Models.Delay;

namespace DoCeluNaCzasMobile.Services.HubServices
{
    public class HubService
    {
        readonly IHubProxy _hubProxy;
        readonly HubConnection _hubConnection;

        public HubService(string hubName)
        {
            _hubConnection = new HubConnection(Urls.SERVER_CONNECTION);
            _hubProxy = _hubConnection.CreateHubProxy(hubName);
        }

        public async Task StartConnection() => await _hubConnection.Start();

        public void StopConnection() => _hubConnection.Stop();

        public async Task<TDataType> GetData<TDataType, TParamType>(string methodName, params object[] args) where TDataType : new()
        {
            var data = new TDataType();

            for (var i = 0; i < 3; i++)
            {
                try
                {
                    if (args.Length > 0)
                        data = await _hubProxy.Invoke<TDataType>(methodName, (TParamType)args[0]);
                    else
                        data = await _hubProxy.Invoke<TDataType>(methodName);
                }
                catch (Exception e)
                {
                    await Task.Delay(1000);
                }
            }

            return data;
        }
    }
}
