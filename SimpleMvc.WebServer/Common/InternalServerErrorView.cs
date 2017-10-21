using System;
using SimpleMvc.WebServer.Contracts.Contracts;

namespace SimpleMvc.WebServer.Contracts.Common
{
   public class InternalServerErrorView : IView
    {
        private readonly Exception exception;

        public InternalServerErrorView(Exception exception)
        {
            this.exception = exception;
        }
        
        public string View()
        {
            return $"<h1>{this.exception.Message}</h1><h2>{this.exception.StackTrace}</h2>";
        }
    }
}
