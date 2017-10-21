using SimpleMvc.WebServer.Contracts.Common;
using SimpleMvc.WebServer.Contracts.Enums;

namespace SimpleMvc.WebServer.Contracts.Http.Response
{
   public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;

            this.Headers.Add(HttpHeader.Location, redirectUrl);
        }
    }
}
