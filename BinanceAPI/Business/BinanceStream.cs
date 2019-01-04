using BinanceAPI.Models;
using Newtonsoft.Json;
using SuperSocket.ClientEngine;
using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using WebSocket4Net;

namespace BinanceAPI.Business
{
    class BinanceStream<T> : IBinanceStream
        where T : BinanceEvent
    {
        public string Name { get; protected set; }

        public event BinanceStreamEventHandler Opened;
        public event BinanceStreamEventHandler Closed;
        public event BinanceStreamEventHandler Error;
        public event BinanceStreamEventHandler<T> EventReceived;

        protected WebSocket Socket { get; private set; }
        protected string baseEndpoint;

        protected virtual string SocketUri => $"{this.baseEndpoint}/ws/{this.Name}";

        public BinanceStream(string baseEndpoint, string streamName)
        {
            this.baseEndpoint = baseEndpoint;
            this.Name = streamName;       
        }

        public void Initialize()
        {
            this.Socket = new WebSocket(this.SocketUri, sslProtocols: SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls);

            this.Socket.Opened += this.Socket_Opened;
            this.Socket.MessageReceived += this.Socket_MessageReceived;
            this.Socket.Closed += this.Socket_Closed;
            this.Socket.Error += this.Socket_Error;
        }

        public async Task OpenAsync() => await Task.Factory.StartNew(() => this.Socket.Open());

        public async Task CloseAsync() => await Task.Factory.StartNew(() => this.Socket.Close());

        public void Dispose()
        {
            if (this.Socket != null)
            {
                if (this.Socket.State == WebSocketState.Open)
                    CloseAsync().Wait();

                this.Socket.Opened -= this.Socket_Opened;
                this.Socket.MessageReceived -= this.Socket_MessageReceived;
                this.Socket.Closed -= this.Socket_Closed;
                this.Socket.Error -= this.Socket_Error;
                this.Socket = null;
            }
        }

        private void Socket_Opened(object sender, EventArgs e) => this.Opened?.Invoke(this.Name, new BinanceEventArgs());

        private void Socket_Closed(object sender, EventArgs e) => this.Closed?.Invoke(this.Name, new BinanceEventArgs());

        private void Socket_Error(object sender, ErrorEventArgs e) => OnError(e.Exception);

        protected virtual void Socket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            try
            {
                var binanceEvent = JsonConvert.DeserializeObject<T>(e.Message);

                if (binanceEvent != null)
                    OnEventReceived(binanceEvent);
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        protected void OnError(Exception ex) => this.Error?.Invoke(this.Name, new BinanceEventArgs(ex));

        protected void OnEventReceived(T binanceEvent) => this.EventReceived?.Invoke(this.Name, binanceEvent);
    }
}