namespace SimpleMvc.App.Views.User
{
   using Framework.Contracts;

   public class Register : IRenderable
   {
      public string Render()
         => "<h3>Register new users</h3>" +
            "<form action=\"Register\" method=\"Post\"><br/>" +
            "Username : <input type=\"text\" name=\"Username\"/><br/>" +
            "<br/>" +
            "Password: <input type= \"password\" name=\"Password\"/><br/>" +
            "<input type=\"submit\" value=\"Register\"/>" +
            "</form><br/>";


   }
}
