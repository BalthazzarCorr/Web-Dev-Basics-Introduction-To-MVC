using SimpleMvc.App.Models;

namespace SimpleMvc.App.Controllers
{
   using Framework.Attributes.Methods;
   using Framework.Contracts;
   using Framework.Controllers;

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
