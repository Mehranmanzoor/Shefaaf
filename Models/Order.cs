using System.ComponentModel.DataAnnotations;

namespace ShefaafSpices.Web.Models
   {
       public class Order
       {
           public int Id { get; set; }

           [Required]
           public string? CustomerId { get; set; }

           public DateTime OrderDate { get; set; }

           [Required]
           public decimal TotalAmount { get; set; }

           public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
       }
   }