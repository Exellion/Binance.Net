using System;
using System.Threading.Tasks;

namespace BinanceAPI.Business
{
    interface IBinanceStream : IDisposable
    {
        string Name { get; }

        Task OpenAsync();

        Task CloseAsync();
    }
}