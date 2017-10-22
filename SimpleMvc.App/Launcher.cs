namespace SimpleMvc.App
{
   using Framework;
   using Framework.Routers;
   using WebServer;

   public class Launcher
   {
      static void Main(string[] args)
      {
         MvcEngine.Run(new WebServer(1338, new ControllerRouter()));
      }
   }
}
