namespace SimpleMvc.App.Views.User
{
   using System.Text;
   using Framework.Contracts.Generic;
   using Models;

   public class All : IRenderable<AllUsernamesViewModel>
   {
      public AllUsernamesViewModel Model { get; set; }

      public string Render()
      {
         StringBuilder sb = new StringBuilder();
         sb.AppendLine("<a href=\"/home/index\">&lArr;Home</a>");
         sb.AppendLine("<h3>All user</h3>");
         sb.AppendLine("<ul>");
         foreach (var kvp in Model.UsernamesAndIds)
         {
            sb.AppendLine($"<li><a href=\"/user/profile?id={kvp.Value}\">{kvp.Key}</a></li>");
         }
         sb.AppendLine("</ul>");

         return sb.ToString();
      }
   }
}