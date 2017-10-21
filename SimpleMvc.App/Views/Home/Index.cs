using SimpleMvc.Framework.Contracts;

namespace SimpleMvc.App.Views.Home
{
   public class Index : IRenderable
   {
      public string Render()
         => "<h1>Test</h1>";
   }
}
