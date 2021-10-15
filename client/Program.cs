using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace client
{
    class Program
    {
        const string url = "http://localhost:5000/chat";
        static async Task Main(string[] args)
        {
            await using var connection = new HubConnectionBuilder().WithUrl(url).Build();
            System.Console.WriteLine("conectou");
            await connection.StartAsync();
            System.Console.WriteLine("iniciou");

            await connection.InvokeAsync("Streaming");
            // await foreach (var date in connection.InvokeAsync("Streaming"))
            // {
            //     System.Console.WriteLine("no foreach, antes");
            //     Console.WriteLine(date);
            //     System.Console.WriteLine("no foreach, depois");
            // }
        }
    }
}
