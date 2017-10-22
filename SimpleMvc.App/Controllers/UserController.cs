namespace SimpleMvc.App.Controllers
{
   using System.Collections.Generic;
   using System.Linq;
   using BindingModels;
   using Domain;
   using Framework.Attributes.Methods;
   using Framework.Contracts;
   using Framework.Controllers;
   using Data;
   using Framework.Contracts.Generic;
   using Microsoft.EntityFrameworkCore;
   using Models;

   public class UserController : Controller
   {
      [HttpGet]
      public IActionResult Register()
      {
         return View();
      }


      [HttpPost]
      public IActionResult Register(RegisterUserBindingModel model)
      {
         var user = new User()
         {
            Username = model.Username,
            Password = model.Password
         };
         using (var context = new Context())
         {
            context.Users.Add(user);
            context.SaveChanges();
         }


         return View();
      }

      public IActionResult<AllUsernamesViewModel> All()
      {
         Dictionary<string, int> usernamesAndIds = null;

         using (var context = new Context())
         {
            usernamesAndIds = context.Users.Select(u => new KeyValuePair<string, int>(u.Username, u.Id))
               .ToDictionary(d => d.Key, d => d.Value);
         }

         var viewModel = new AllUsernamesViewModel()
         {
            UsernamesAndIds = usernamesAndIds
         };

         return View(viewModel);
      }

      [HttpGet]
      public IActionResult<UserProfileViewModel> Profile(int id)
      {
         User user = null;

         using (var context = new Context())
         {
            user = context.Users.Include(u => u.Notes).First(u => u.Id == id);
         }

         var viewModel = new UserProfileViewModel()
         {
            UserId = user.Id,
            Username = user.Username,
            Notes = user.Notes
               .Select(n =>
                  new NoteViewModel()
                  {
                     Title = n.Title,
                     Content = n.Content
                  })
         };

         return View(viewModel);
      }

      [HttpPost]
      public IActionResult<UserProfileViewModel> Profile(AddNoteBindingModel model)
      {
         using (var context = new Context())
         {
            var user = context.Users.Include(u => u.Notes).First(u => u.Id == model.UserId);
            var note = new Note(model.Title, model.Content);

            user.Notes.Add(note);
            context.SaveChanges();
         }
         ;

         return Profile(model.UserId);
      }
   }

}

