using SimpleMvc.WebServer.Contracts.Contracts;

namespace SimpleMvc.WebServer.Contracts.Common
{
   public class NotFoundView : IView
    {
        public string View()
        {
            return "<h1>404 This page or resource you are trying to access does not exist :/</h1>";
        }
    }
}
