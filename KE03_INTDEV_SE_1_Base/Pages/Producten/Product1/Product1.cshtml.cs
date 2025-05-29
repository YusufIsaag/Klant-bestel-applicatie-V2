using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_1_Base.Pages.Product1
{
    public class Product1Model : PageModel
    {
        public readonly MatrixIncDbContext _context;
        public Product1Model(MatrixIncDbContext context)
        {
            _context = context;
        }


        //var winkelwagen = new Winkelwagen
        //{
        //    ProductId = product.ProductId,
        //    Aantal = aantal,
        //    Product = product,
        //    TotaalBedrag = product.Prijs * aantal
        //}
        //public async Task OngetAsync()
        //{
        //    Winkelwagen = await _context.WinkelwagenToListAsync();
        //}
        //public async Task<IActionResult> OnPostToevoegenAanWinkelwagen(int productID, int Aantal)
        //{
        //    var sessionId = HttpContext.Session.Id;

        //    var product = await _context.Products.FindAsync(productID);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //}
        //_context.Winkelwagen.Add(winkelwagenItem);
        //    await _context.SaveChangesAsync();


    }
}
