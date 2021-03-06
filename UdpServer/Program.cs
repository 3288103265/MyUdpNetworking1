﻿using System;
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
            string Addr = "D:\\Pictures\\results\\";

            for (int i = 1; i <= 155; i++)
            {
                byte[] recvBytes = udpServer.Receive(ref remoteIpEndPoint);
                Image recvImg = Byte2Img(recvBytes);
                Console.WriteLine("Received " + i.ToString() +"th picture.");
                
                string imgAddress = Addr + i.ToString() + ".jpg";
                recvImg.Save(imgAddress, ImageFormat.Jpeg);
                recvImg.Dispose();
                Console.WriteLine("Saved " + i.ToString() + "th picture.");

                Mat rsc = Cv2.ImRead(imgAddress, ImreadModes.AnyColor);
                Cv2.ImShow("RecvImg", rsc);
                Cv2.WaitKey(1);
                rsc.Dispose();
            }

            Cv2.DestroyAllWindows();

            udpServer.Close();
            Console.WriteLine("Transmission completed.");

            Image Byte2Img(byte[] imgByte)
            {
                //Convert Bytestream to Image.
                var ms = new MemoryStream(imgByte);
                return Bitmap.FromStream(ms, true);
            }
        }
    }
}
