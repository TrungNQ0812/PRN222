using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerApp
{
    internal class Program
    {
        static void ProcessMessage(Object parm)
        {
            string data;
            int count;
            try
            {
                TcpClient client = parm as TcpClient;
                //buffer for reading data
                Byte[] bytes = new byte[256];
                //Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();
                //Loop to receive all the data sent by the client
                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // translate data bytes to a ASCII string
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
                    Console.WriteLine($"Received: {data} at {DateTime.Now:t}");
                    //Process the data sent by the client.
                    data = $"{data.ToUpper()}";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                    //Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Sent: {data}");
                }
                client.Close();
            }catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("Waiting message..."); ;
            }
        }

        static void ExecuteServer(string host, int port)
        {
            int Count = 0;
            TcpListener server = null;
            try
            {
                Console.Title = "Server Application";
                IPAddress localAddr = IPAddress.Parse(host);
                server = new TcpListener(localAddr, port);

                server.Start();
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("Waiting for c connection...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"Number of client connected: {++Count}");
                    Console.WriteLine(new string('*', 40));
                    Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));
                    thread.Start(client);
                }

            }catch (Exception ex) {
                Console.WriteLine("exception : {0}", ex.Message);
            }
            finally
            {
                server.Stop();
                Console.WriteLine("Server stoped. press any key to exit!");

            }

            Console.Read();
        }
        static void Main(string[] args)
        {
            string host = "127.0.0.1";
            //set the TcpListener on port 13000.
            int port = 13000;
            ExecuteServer(host, port);
        }
    }
}
