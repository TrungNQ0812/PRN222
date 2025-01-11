using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerApp
{
    internal class Program
    {
        const int listenPort = 11000;
        const string host = "127.0.0.1";

        private static  void StartListener()
        {
            string message;
            UdpClient listener = new UdpClient(listenPort);
            IPAddress  address = IPAddress.Parse(host);
            IPEndPoint remoteEndpoint = new IPEndPoint(address, listenPort);
            Console.Title = "UDP Server";
            Console.WriteLine(new string('*', 40));
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref remoteEndpoint);

                }
            }

        }

        static void Main(string[] args)
        {
            
        }
    }
}
