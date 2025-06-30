using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_1_Base.Pages.Winkelwagen
{
    public class WinkelwagenModel : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public WinkelwagenModel(MatrixIncDbContext context)
        {
            _context = context;
        }

        public List<WinkelwagenProduct> WinkelwagenProducten { get; set; }

        public void OnGet()
        {
            WinkelwagenProducten = _context.winkelwagenProducts
                .Include(wp => wp.Product)
                .ToList();
        }


        public IActionResult OnPostRemoveItem(int itemId)
        {

            var item = _context.winkelwagenProducts.Find(itemId);
            if (item != null)
            {

                _context.winkelwagenProducts.Remove(item);
                _context.SaveChanges();
            }
            TempData["DeleteNotification"] = item.ProductId;
            return RedirectToPage(); 
        }
    }
}