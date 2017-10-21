﻿namespace SimpleMvc.App
{
   using Framework;
   using Framework.Routers;
   using WebServer.Contracts;

   public class Launcher
   {
      static void Main(string[] args)
      {
         MvcEngine.Run(new WebServer(1338, new ControllerRouter()));
      }
   }
}