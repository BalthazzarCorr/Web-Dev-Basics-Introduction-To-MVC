namespace SimpleMvc.App
{
   using Data;
   using Framework;
   using Framework.Routers;
   using WebServer;

   public class Launcher
   {
      static void Main(string[] args)
      {
         using (var db = new Context())
         {
            db.Database.EnsureCreated();
         }


         MvcEngine.Run(new WebServer(1338, new ControllerRouter()));
      }
   }
}
