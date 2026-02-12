using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstWebServer.Server.Http;

namespace MyFirstWebServer.Server.Responses
{
    public class BadRequestResponse : HTTP_Request.Response
    {
        public BadRequestResponse()
            : base(StatusCode.BadRequest)
        {
        }
    }
}
