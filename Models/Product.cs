using System.ComponentModel.DataAnnotations;

   namespace ShefaafSpices.Web.Models
   {
       public class Product
       {
           public int Id { get; set; }

           [Required]
           [StringLength(100)]
           public string ?Name { get; set; }

           [Required]
           public string? Description { get; set; }

           [Required]
           [Range(0.01, 10000)]
           public decimal Price { get; set; }

           [Required]
           public string ?ImageUrl { get; set; }

           [Required]
           [Range(0, int.MaxValue)]
           public int StockQuantity { get; set; }

           public int CategoryId { get; set; }

           public Category? Category { get; set; }
       }
   }
