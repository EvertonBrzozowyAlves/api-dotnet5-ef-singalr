using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MoviesApi.Hubs
{
    public class MoviesHub : Hub
    {
        public async Task<string> Streaming(CancellationToken cancellationToken)
        {
            while (true)
            {
                // await Task.Run(() => DateTime.Now.ToShortDateString());
                await Clients.All.SendAsync("ReceiveMessage", DateTime.Now.ToShortDateString(), cancellationToken);
            }
        }
    }
}