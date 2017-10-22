using System.Reflection;

namespace SimpleMvc.Framework
{
   using WebServer.Contracts;
   using System;

   public static class MvcEngine
    {
       public static void Run(WebServer.WebServer server)
       {
          RegisterAssemblyName();
          //RegisterControllerData();
          //RegisterViewsData();
          //RegisterModelsData();


          try
          {
            server.Run();
          }
          catch (Exception e)
          {

             Console.WriteLine(e.Message);
        
          }
       }

       private static void RegisterAssemblyName()
       {
          MvcContext.Get.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
       }

       //private static void RegisterControllerData()
       //{
       //   throw new NotImplementedException();
       //}

       //private static void RegisterViewsData()
       //{
       //   throw new NotImplementedException();
       //}

       //private static void RegisterModelsData()
       //{
       //   throw new NotImplementedException();
       //}
    }
}
