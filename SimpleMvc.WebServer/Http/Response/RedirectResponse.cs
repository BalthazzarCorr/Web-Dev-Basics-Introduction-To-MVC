namespace SimpleMvc.WebServer.Http.Response
{
   using Enums;
   using Common;

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
