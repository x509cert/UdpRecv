using System.Net;
using System.Net.Sockets;
using System.Text;

int listenPort = 9293;

// Create a UDP client
using (var udpClient = new UdpClient(listenPort))
{
    var RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, listenPort);

    try
    {
        Console.WriteLine("Waiting for broadcast");
        while (true)
        {
            var receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
            var returnData = Encoding.ASCII.GetString(receiveBytes).Remove(0, 6);

            var time = DateTime.Now.ToString("HHmmss");
            Console.WriteLine($"{time}:{returnData}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}
