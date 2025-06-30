using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace KE03_INTDEV_SE_1_Base.Pages.Product5
{
    public class Product5Model : PageModel
    {
        public readonly MatrixIncDbContext _context;
        public Product5Model(MatrixIncDbContext context)
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
            TempData["De;eteNotification"] = product.Naam;

            _context.winkelwagenProducts.Add(winkelwagenItem);
            _context.SaveChanges();
            return RedirectToPage();
        }

    }
}
