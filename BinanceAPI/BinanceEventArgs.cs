using System;

namespace BinanceAPI
{
    public class BinanceEventArgs : EventArgs
    {
        internal BinanceEventArgs(Exception ex = null) => this.Exception = ex;

        public Exception Exception { get; private set; }
    }
}
