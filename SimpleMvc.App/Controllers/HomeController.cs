namespace SimpleMvc.App.Controllers
{
   using Framework.Attributes.Methods;
   using Framework.Contracts;
   using Framework.Controllers;
   using Models;

   public class HomeController : Controller
    {
      
       public IActionResult Index()
       {
          return View();
       }

     [HttpPost]
       public IActionResult Index(int id, IndexModel model)
       {
          return View();
       }
    }
}
