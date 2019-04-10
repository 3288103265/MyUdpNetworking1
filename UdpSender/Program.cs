using System.Net.Sockets;
using System.Text;
using OpenCvSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;

namespace UdpSender
{
    class Program
    {
        static void Main(string[] args)
        {
            
            UdpClient udpClient = new UdpClient(0);
            udpClient.Connect("210.72.22.237", 11000);

            List<string> addr = GetAddressList();
            for (int i = 0; i < 10; i++)
            {
                byte[] imgByte = Img2Bytes(addr[i]);
                udpClient.Send(imgByte, imgByte.Length);
            }
            
            udpClient.Close();

            byte[] Img2Bytes(string path)
            {
                var file = new FileStream(path, FileMode.Open);
                byte[] imgbyte = new byte[file.Length];
                file.Read(imgbyte, 0, imgbyte.Length);
                file.Close();
                return imgbyte;
            }

            List<string> GetAddressList()
            {
                //Generate a list contain address name.
                List<string> addrList = new List<string>();
                string Addr = "D:\\Pictures\\";

                for (int i = 0; i < 10; i++)
                {
                    addrList.Add(Addr + i.ToString() + ".jpg");
                }
                return addrList;
            }
        }
    }
}
