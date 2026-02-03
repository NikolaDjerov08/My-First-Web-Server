using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;

namespace MyFirstWebServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ipAdress = IPAddress.Parse("127.0.0.1");
            var port = 8080;
            var serverListener = new TcpListener(ipAdress, port);
            serverListener.Start();
            Console.WriteLine("Server started");
            Console.WriteLine($"Looking for response");

            var connection =serverListener.AcceptTcpClient();
            var networkStream = connection.GetStream();

            string content = "Hello from the server!";
            int contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1
         Content-Type:text/plain;charset=UTF-8
         Content-Length: {contentLength}

         {content}";
            var responseBytes = Encoding.UTF8.GetBytes(response);
            networkStream.Write(responseBytes);
            connection.Close();
        }
        public class HttpServer
        {
            private readonly IPAddress ipAddress;
            private readonly int port;
            private readonly TcpListener serverListener;

            public HttpServer(string ipAddress, int port)
            {
                this.ipAddress = IPAddress.Parse(ipAddress);
                this.port = port;
                this.serverListener = new TcpListener(this.ipAddress, this.port);
            }

            public void Start()
            {
                serverListener.Start();
                Console.WriteLine($"Server started on port {port}");
                Console.WriteLine($"Listening for requests");

                while (true)
                {
                    var connection = serverListener.AcceptTcpClient();
                    var networkStream = connection.GetStream();


                    string content = "Hello from the server!";
                    int contentLength = Encoding.UTF8.GetByteCount(content);
                    var response = $@"HTTP/1.1
Content-Type : text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";
                    var responseBytes = Encoding.UTF8.GetBytes(response);
                    networkStream.Write(responseBytes);
                    connection.Close();
                }
            }
        }
    }
}
