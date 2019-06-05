﻿using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace DoCeluNaCzasMobile.Services.HubServices
{
    public class HubService
    {
        const int DelayOnRetry = 1000;
        const int NumberOfRetries = 3;
        readonly HubConnection _hubConnection;
        readonly IHubProxy _hubProxy1;

        public HubService(string hubConnectionUrl, string hubName)
        {
            _hubConnection = new HubConnection(hubConnectionUrl);
            _hubProxy1 = _hubConnection.CreateHubProxy(hubName);
        }

        public async Task StartConnection()
        {
            await _hubConnection.Start();
        }

        public bool IsConnected()
        {
            return _hubConnection.State == ConnectionState.Connected; ;
        }

        public async Task<T> GetData<T>(string methodName, params int[] args) where T : new()
        {
            for (var i = 1; i <= NumberOfRetries; ++i)
            {
                try
                {
                    if (args.Length > 0)
                        return await _hubProxy1.Invoke<T>(methodName, args[0]);
                    return await _hubProxy1.Invoke<T>(methodName);
                }
                catch (InvalidOperationException ioe)
                {
                    var mes = ioe.Message;
                    await Task.Delay(DelayOnRetry);
                }
                catch (Exception e) when (i < NumberOfRetries)
                {
                    var mes = e.Message;
                    await Task.Delay(DelayOnRetry);
                }
            }

            return new T();
        }

        public void StopConnection()
        {
            _hubConnection.Stop();
        }
    }
}
