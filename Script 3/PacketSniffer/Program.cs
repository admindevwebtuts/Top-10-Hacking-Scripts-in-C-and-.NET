
﻿using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace PacketSniffer
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Socket Initialization
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            
            // 2. Binding Socket
            IPAddress localhost = IPAddress.Parse("127.0.0.1");
            EndPoint endPoint = new IPEndPoint(localhost, 0);

            socket.Bind(endPoint);

            // 3. Setting Socket Options
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);
            
            byte[] inValue = new byte[] { 1, 0, 0, 0 };
            byte[] outValue = new byte[] { 0, 0, 0, 0 };
            socket.IOControl(IOControlCode.ReceiveAll, inValue, outValue);

            // 4. Receiving Packets
            byte[] buffer = new byte[4096];
            
            while (true)
            {
                int bytesReceived = socket.Receive(buffer);
                
                // 5. Parsing Packet Details
                IPAddress sourceIP = new IPAddress(buffer.Skip(12).Take(4).ToArray());
                IPAddress destinationIP = new IPAddress(buffer.Skip(16).Take(4).ToArray());

                Console.WriteLine($"Source IP: {sourceIP}, Destination IP: {destinationIP}");
            }
        }
    }
}