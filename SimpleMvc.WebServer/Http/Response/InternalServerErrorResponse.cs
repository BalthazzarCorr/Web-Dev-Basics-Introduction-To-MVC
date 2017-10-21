using System;
using SimpleMvc.WebServer.Contracts.Common;
using SimpleMvc.WebServer.Contracts.Enums;

namespace SimpleMvc.WebServer.Contracts.Http.Response
{
   public class InternalServerErrorResponse : ContentResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpStatusCode.InternalServerError, new InternalServerErrorView(ex).View())
        {
        }
    }
}
