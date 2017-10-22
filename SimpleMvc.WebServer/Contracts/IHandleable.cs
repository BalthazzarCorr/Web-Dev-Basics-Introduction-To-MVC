namespace SimpleMvc.WebServer.Contracts
{
   using SimpleMvc.WebServer.Http.Contracts;
   
   public interface IHandleable
   {
      IHttpResponse Handle(IHttpRequest request);
   }
}
