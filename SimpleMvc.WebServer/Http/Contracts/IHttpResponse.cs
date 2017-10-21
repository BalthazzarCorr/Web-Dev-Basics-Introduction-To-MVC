using SimpleMvc.WebServer.Contracts.Enums;

namespace SimpleMvc.WebServer.Contracts.Http.Contracts
{
   public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }
    }
}
