using System.Net;
using System.Net.Sockets;

class Program
{
static void Main(string[] args)
{
Socket spoofingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

byte[] buffer = new byte[4096];

// Fill the buffer with some data
// ...

IPAddress srcIP = IPAddress.Parse("127.0.0.1"); // Source IP to spoof
IPAddress dstIP = IPAddress.Parse("127.0.0.1"); // Destination IP

IPEndPoint srcEndPoint = new IPEndPoint(srcIP, 0);
IPEndPoint dstEndPoint = new IPEndPoint(dstIP, 0);

spoofingSocket.Bind(srcEndPoint);
spoofingSocket.SendTo(buffer, dstEndPoint);
}
}