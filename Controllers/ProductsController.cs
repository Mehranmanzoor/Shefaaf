using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShefaafSpices.Web.Data;

namespace ShefaafSpices.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            var categories = await _context.Categories
                .ToListAsync();

            ViewBag.Categories = categories;
            return View(products);
        }

        // GET: Product Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null) return NotFound();

            return View(product);
        }
    }
}