using SimpleMvc.WebServer.Contracts.Enums;

namespace SimpleMvc.WebServer.Contracts.Http.Response
{
   public class BadRequestResponse : HttpResponse
    {
        public BadRequestResponse()
        {
            this.StatusCode = HttpStatusCode.BadRequest;
        }
    }
}
