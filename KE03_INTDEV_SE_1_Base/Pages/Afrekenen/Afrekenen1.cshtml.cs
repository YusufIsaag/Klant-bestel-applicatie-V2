using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KE03_INTDEV_SE_1_Base.Pages.Afrekenen
{
    public class Afrekenen1Model : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public Afrekenen1Model(MatrixIncDbContext context)
        {
            _context = context;
        }

        public List<WinkelwagenProduct> WinkelwagenItems { get; set; }
        public decimal Subtotaal { get; set; }
        public decimal Verzendkosten { get; } = 4.95m; 
        public decimal TotaalBedrag { get; set; }

        public void OnGet()
        {
            WinkelwagenItems = _context.winkelwagenProducts
                .Include(w => w.Product)
                .ToList();

            Subtotaal = WinkelwagenItems.Sum(item => item.Aantal * item.Product.Prijs);
            TotaalBedrag = Subtotaal + Verzendkosten;
        }

        public IActionResult OnPost()
        {

            var items = _context.winkelwagenProducts.ToList();
            _context.winkelwagenProducts.RemoveRange(items);
            _context.SaveChanges();

            return RedirectToPage();
        }
    }
}