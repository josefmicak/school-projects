using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MIC0378
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Thread> threadPool = new List<Thread>();

            for (int i = 0; i < 32; i++)
            {
                threadPool.Add(new Thread(connectionThread));
                threadPool[i].Start();
            }

            Console.ReadLine();

            foreach (Thread thread in threadPool)
            {
                thread.Abort();
            }
        }

        private static void connectionThread(object obj)
        {
            for (; ; )
            {
                TcpClient tcpClient = new TcpClient();

                try
                {
                    tcpClient.Connect(new IPEndPoint(IPAddress.Parse("::1"), 80));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
