using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ClientApp
{
    internal class Program
    {
        static void ConnectServer(string host, int port)
        {
            UdpClient client = new UdpClient();
            IPAddress address = IPAddress.Parse(host);
            IPEndPoint remoteEndPoint = new IPEndPoint(address, port);
            string message;
            int count = 0;
            bool done = false;
            Console.Title = "UDP Client";
            try
            {
                Console.WriteLine(new string('*', 40));
                client.Connect(remoteEndPoint);
                while (!done)
                {
                    message = $"Message {++count:D2}";
                    byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                    client.Send(sendBytes, sendBytes.Length);
                }
            }catch(SocketException SE)
            {
                Console.WriteLine(SE.Message);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
