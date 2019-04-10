using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenCvSharp;
using System.Collections.Generic;


namespace UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(11000);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            List<string> addr = GetAddressList();

            for (int i = 0; i < 155; i++)
            {
                byte[] recvBytes = udpServer.Receive(ref remoteIpEndPoint);
                Image recvImg = Byte2Img(recvBytes);
                recvImg.Save(addr[i], ImageFormat.Jpeg);
                recvImg.Dispose();
                Mat rsc = Cv2.ImRead(addr[i], ImreadModes.AnyColor);
                Cv2.ImShow("RecvImg", rsc);
                Cv2.WaitKey(0);
                rsc.Dispose();
            }
            udpServer.Close();

            Image Byte2Img(byte[] imgByte)
            {
                //Convert Bytestream to Image.
                var ms = new MemoryStream(imgByte);
                return Bitmap.FromStream(ms, true);
            }

            List<string> GetAddressList()
            {
                //Generate a list contain address name.
                List<string> addrList = new List<string>();
                string Addr = "D:\\Pictures\\RecvResult\\";

                for (int i = 0; i < 155; i++)
                {
                    addrList.Add(Addr + i.ToString() + ".jpg");
                }
                return addrList;
            }
        }

    
    }
}
