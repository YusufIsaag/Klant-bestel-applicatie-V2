using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataAccessLayer.Models;

namespace KE03_INTDEV_SE_1_Base.Pages.Bestelhistorie
{
    public class BestelhistorieModel : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public BestelhistorieModel(MatrixIncDbContext context)
        {
            _context = context;
        }

        public List<Bestelling> Bestellingen { get; set; }

        public void OnGet()
        {
            Bestellingen = _context.Bestellingen
                .Include(b => b.WinkelwagenProducts)
                .ThenInclude(wp => wp.Product)
                .ToList();
        }

    }
}