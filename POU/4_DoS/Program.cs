using System.Net;
using System.Net.Sockets;
using System.Threading;

int i = 1;

while(true)
{
    try
    {
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.100.41"), 80);
        TcpClient tcpClient = new TcpClient();
        tcpClient.Connect(endPoint);
        Console.WriteLine("Starting thread #" + i);
        i++;
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        continue;
    }
}
