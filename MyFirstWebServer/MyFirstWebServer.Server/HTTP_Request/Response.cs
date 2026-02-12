using MyFirstWebServer.Server.Http;

namespace HTTP_Request
{
    public class Response
    {
        private StatusCode badRequest;

        public Response(StatusCode badRequest)
        {
            this.badRequest = badRequest;
        }
    }
}