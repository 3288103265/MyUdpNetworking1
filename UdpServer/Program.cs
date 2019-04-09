using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(11000);

            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            byte[] receiveBytes = udpServer.Receive(ref remoteIpEndPoint);
            string revMsg = Encoding.ASCII.GetString(receiveBytes);
            Console.WriteLine($"Received: {revMsg}");
            Console.WriteLine("From IP: " + remoteIpEndPoint.Address.ToString());
            Console.WriteLine("From Port: " + remoteIpEndPoint.Port.ToString());

            udpServer.Close();

        }
    }
}
