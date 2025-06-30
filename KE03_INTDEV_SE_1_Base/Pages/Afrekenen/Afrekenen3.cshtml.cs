using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace KE03_INTDEV_SE_1_Base.Pages.Afrekenen
{
    public class Afrekenen3Model : PageModel
    {
        public readonly MatrixIncDbContext _context;
        public Afrekenen3Model(MatrixIncDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostVerderWinkelen()
        {
            var items = _context.winkelwagenProducts.ToList();
            if (items.Any())
            {
                _context.winkelwagenProducts.RemoveRange(items);
                _context.SaveChanges();
            }
            return RedirectToPage("/Index");
        }
    }
}