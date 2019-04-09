using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp;
using System.IO;

namespace UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(11000);

            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            byte[] recvBytes = udpServer.Receive(ref remoteIpEndPoint);
            Image recvImg = Byte2Img(recvBytes);
            recvImg.Save("test2.jpg", ImageFormat.Jpeg);
            Mat rsc = Cv2.ImRead("test2.jpg");
            Cv2.ImShow("RecvImg", rsc);
            Cv2.WaitKey(0);


            //string revMsg = Encoding.ASCII.GetString(receiveBytes);
            //Console.WriteLine($"Received: {revMsg}");
            //Console.WriteLine("From IP: " + remoteIpEndPoint.Address.ToString());
            //Console.WriteLine("From Port: " + remoteIpEndPoint.Port.ToString());

            udpServer.Close();

            Image Byte2Img(byte[] imgByte)
            {
                var ms = new MemoryStream(imgByte);
                return Bitmap.FromStream(ms, true);
            }
        }

        
    }
}
