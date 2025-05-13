using System.ComponentModel.DataAnnotations;

   namespace ShefaafSpices.Web.Models
   {
       public class NewsletterSubscriber
       {
           public int Id { get; set; }

           [Required]
           [EmailAddress]
           public string? Email { get; set; }
       }
   }