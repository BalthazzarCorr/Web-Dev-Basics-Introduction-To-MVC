namespace SimpleMvc.WebServer.Contracts.Contracts
{
   using Http.Contracts;

   public interface IHandleable
   {
      IHttpResponse Handle(IHttpRequest request);
   }
}
