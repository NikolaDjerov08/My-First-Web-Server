
using MyFirstWebServer.Server;
using MyFirstWebServer.Server.Responses;
using MyFirstWebServer.Server.Views;

namespace MyFirstWebServer.Demo
{
    public class StartUp
    {
        public static void Main()
        {
            var server = new HttpServer(routes =>
            {
                routes
                .MapGet("/", new TextResponse("Hello from the server!"))
                .MapGet("/HTML", new HtmlResponse("<h1>HTML response</h1>"))
                .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
                .MapGet("/login", new HtmlResponse(Form.HTML));
            });
            server.Start();
        }
    }
}
