using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EnhancedPacketSniffer
{
class Program
{
static void Main(string[] args)
{
Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

IPAddress localhost = IPAddress.Parse("127.0.0.1");
EndPoint endPoint = new IPEndPoint(localhost, 0);

socket.Bind(endPoint);

socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

byte[] inValue = new byte[] { 1, 0, 0, 0 };
byte[] outValue = new byte[] { 0, 0, 0, 0 };
socket.IOControl(IOControlCode.ReceiveAll, inValue, outValue);

byte[] buffer = new byte[4096];

while (true)
{
int bytesReceived = socket.Receive(buffer);

IPAddress sourceIP = new IPAddress(buffer.Skip(12).Take(4).ToArray());
IPAddress destinationIP = new IPAddress(buffer.Skip(16).Take(4).ToArray());

int protocolTypePosition = 23;
int protocolType = buffer[protocolTypePosition];

string protocol;

switch (protocolType)
{
case 6:
protocol = "TCP";
break;
case 17:
protocol = "UDP";
break;
case 1:
protocol = "ICMP";
break;
default:
protocol = "Unknown";
break;
}

Console.WriteLine($"Source IP: {sourceIP}, Destination IP: {destinationIP}, Protocol: {protocol}");
}
}
}
}