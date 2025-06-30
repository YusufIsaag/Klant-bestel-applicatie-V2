using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;

namespace KE03_INTDEV_SE_1_Base.Pages.Product1
{
    public class Product1Model : PageModel
    {
        public readonly MatrixIncDbContext _context;
        public Product1Model(MatrixIncDbContext context)
        {
            _context = context;
        }
        public IActionResult OnPostToevoegenAanWinkelwagen(int productId, int aantal)
        {
            var product = _context.Products.Find(productId);
            var sessionId = HttpContext.Session.Id;

            var winkelwagenItem = new WinkelwagenProduct
            {
                ProductId = product.ProductId,
                Aantal = aantal,
                Product = product,
            };
            TempData["AddNotification"] = product.Naam;
            _context.winkelwagenProducts.Add(winkelwagenItem);
            _context.SaveChanges();
            return RedirectToPage();
        }

    }
}
