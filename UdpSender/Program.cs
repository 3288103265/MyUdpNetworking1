﻿using System.Net.Sockets;
using System.Text;

namespace UdpSender
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(0);

            udpClient.Connect("210.72.22.237", 11000);
            byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");
            udpClient.Send(sendBytes, sendBytes.Length);

            udpClient.Close();
        }
    }
}
