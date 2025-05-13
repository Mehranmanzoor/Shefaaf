using Microsoft.AspNetCore.Mvc;
     using ShefaafSpices.Web.Data;
     using ShefaafSpices.Web.Models;

     namespace ShefaafSpices.Web.Controllers
     {
         public class NewsletterController : Controller
         {
             private readonly AppDbContext _context;

             public NewsletterController(AppDbContext context)
             {
                 _context = context;
             }

             [HttpPost]
             public IActionResult Subscribe(string email)
             {
                 if (string.IsNullOrEmpty(email) || !email.Contains("@"))
                 {
                     TempData["Message"] = "Please enter a valid email address.";
                     return RedirectToAction("Index", "Home");
                 }

                 var subscriber = new NewsletterSubscriber { Email = email };
                 _context.NewsletterSubscribers.Add(subscriber);
                 _context.SaveChanges();

                 TempData["Message"] = "Thank you for subscribing!";
                 return RedirectToAction("Index", "Home");
             }
         }
     }