using System;
using System.Net.Sockets;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string host = args[0];
        int startPort = Int32.Parse(args[1]);
        int endPort = Int32.Parse(args[2]);

        for (int port = startPort; port <= endPort; port++)
        {
            using var client = new TcpClient();
            try
            {
                await client.ConnectAsync(host, port);
                Console.WriteLine($"Port {port} is open.");
            }
            catch
            {
                Console.WriteLine($"Port {port} is closed.");
            }
        }
    }
}

