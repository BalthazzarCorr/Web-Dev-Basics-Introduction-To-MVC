using SimpleMvc.WebServer.Contracts.Common;
using SimpleMvc.WebServer.Contracts.Enums;

namespace SimpleMvc.WebServer.Contracts.Http.Response
{
   public class NotFoundResponse : ContentResponse
    {
        public NotFoundResponse()
            : base(HttpStatusCode.NotFound, new NotFoundView().View())
        {
        }
    }
}
