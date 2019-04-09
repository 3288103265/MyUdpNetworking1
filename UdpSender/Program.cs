using System.Net.Sockets;
using System.Text;
using OpenCvSharp;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace UdpSender
{
    class Program
    {
        static void Main(string[] args)
        {
            
            UdpClient udpClient = new UdpClient(0);
            udpClient.Connect("210.72.22.237", 11000);
            byte[] imgByte = Img2Bytes("lena.tiff");
            udpClient.Send(imgByte, imgByte.Length);

            udpClient.Close();

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
