namespace SimpleMvc.App.Views.Home
{
   using System.Text;
   using Framework.Contracts;

   public class Index : IRenderable
   {
      public string Render()
      {
         var sb = new StringBuilder();

         sb.AppendLine("<h2>Notes App</h2>");
         sb.AppendLine("<a href=\"/user/all\">All Users</a>");
         sb.AppendLine("<a href=\"/user/register\">Register Users</a>");

         return sb.ToString();
      }
   }
}