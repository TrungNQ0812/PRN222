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
        //static void ProcessMessage(Object parm)
        //{
        //    string data;
        //    int count;
        //    try
        //    {
        //        TcpClient client = parm as TcpClient;
        //        //buffer for reading data
        //        Byte[] bytes = new byte[256];
        //        //Get a stream object for reading and writing
        //        NetworkStream stream = client.GetStream();
        //        //Loop to receive all the data sent by the client
        //        while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
        //        {
        //            // translate data bytes to a ASCII string
        //            data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);

        //            //data = Encoding.UTF8.GetString(bytes, 0, count); đọc chuỗi JSON


        //            Console.WriteLine($"Received: {data} at {DateTime.Now:t}");
        //            //Process the data sent by the client.
        //            data = $"{data.ToUpper()}";
        //            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
        //            //Send back a response.
        //            stream.Write(msg, 0, msg.Length);

        //            //string response = "accepted"; gui message
        //            //byte[] msg = Encoding.UTF8.GetBytes(response);
        //            //stream.Write(msg, 0, msg.Length);


        //            Console.WriteLine($"Sent: {data}");
        //        }
        //        client.Close();
        //    }catch (Exception ex)
        //    {
        //        Console.WriteLine("{0}", ex.Message);
        //        Console.WriteLine("Waiting message..."); ;
        //    }
        //}



        static void ProcessMessage(Object parm)
        {
            try
            {
                TcpClient client = parm as TcpClient;
                NetworkStream stream = client.GetStream();
                byte[] bytes = new byte[256];
                int count;

                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    string data = Encoding.UTF8.GetString(bytes, 0, count);
                    Console.WriteLine($"Received: {data}");

                    // Gửi phản hồi "accepted"
                    string response = "accepted";
                    byte[] msg = Encoding.UTF8.GetBytes(response);
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Sent: {response}");
                }

                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }



        //static void ProcessMessage(object parm)
        //{
        //    try
        //    {
        //        using (var db = new PePrn222TrialContext())
        //        {
        //            TcpClient client = parm as TcpClient;
        //            NetworkStream stream = client.GetStream();
        //            byte[] bytes = new byte[256];
        //            int count;

        //            while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
        //            {
        //                string data = Encoding.ASCII.GetString(bytes, 0, count);
        //                Console.WriteLine($"Received: {data}");

        //                // Lưu message vào DB
        //                var message = new Message { Content = data, Timestamp = DateTime.Now };
        //                db.Messages.Add(message);
        //                db.SaveChanges();

        //                // Gửi phản hồi lại client
        //                string response = $"Server received: {data.ToUpper()}";
        //                byte[] msg = Encoding.ASCII.GetBytes(response);
        //                stream.Write(msg, 0, msg.Length);
        //                Console.WriteLine($"Saved & Sent: {response}");
        //            }

        //            client.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error: {ex.Message}");
        //    }
        //}


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
            int port = 5000;
            ExecuteServer(host, port);
        }
    }
}
