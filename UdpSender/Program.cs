﻿using System.Net.Sockets;
using System.Text;
using OpenCvSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace UdpSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var sendThread = new Thread(new ThreadStart(SendService));
            //sendThread.IsBackground = true;
            sendThread.Start();

            void SendService()
            {
                string Addr = "D:\\PythonProject\\Video2frame\\result\\";
                UdpClient udpClient = new UdpClient(0);
                udpClient.Connect("210.72.22.237", 11000);

                for (int i = 1; i <= 155; i++)
                {
                    string imgAddress = Addr + i.ToString() + ".jpg";
                    byte[] imgByte = Img2Bytes(imgAddress);
                    udpClient.Send(imgByte, imgByte.Length);
                    Thread.Sleep(30);
                }
                udpClient.Close();
                System.Console.WriteLine("Transmission completed.");
            }
            
            byte[] Img2Bytes(string path)
            {
                var file = new FileStream(path, FileMode.Open);
                byte[] imgbyte = new byte[file.Length];
                file.Read(imgbyte, 0, imgbyte.Length);
                file.Close();
                return imgbyte;
            }
            
        }
    }
}
