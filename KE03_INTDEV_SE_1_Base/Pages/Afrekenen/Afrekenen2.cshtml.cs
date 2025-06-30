using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace KE03_INTDEV_SE_1_Base.Pages.Afrekenen
{
    public class Afrekenen2Model : PageModel
    {
        private readonly MatrixIncDbContext _context;

        public Afrekenen2Model(MatrixIncDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public KlantgegevensModel Klantgegevens { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostAddToBestelhistorie()
        {
            var winkelwagenProducts = _context.winkelwagenProducts
                .Include(wp => wp.Product)
                .ToList();
            var totaalBedrag = winkelwagenProducts.Sum(item => item.TotaalBedrag);

            var bestelling = new Bestelling
            {
                Datum = DateTime.Now,
                KlantNaam = $"{Klantgegevens.Voornaam} {Klantgegevens.Achternaam}",
                Email = Klantgegevens.Email,
                Adres = $"{Klantgegevens.Straat} {Klantgegevens.Huisnummer}, {Klantgegevens.Postcode} {Klantgegevens.Plaats}",
                TotaalBedrag = totaalBedrag,  
                WinkelwagenProducts = winkelwagenProducts
            };

            _context.Bestellingen.Add(bestelling);
            _context.SaveChanges();

            if (winkelwagenProducts.Any())
            {
                _context.winkelwagenProducts.RemoveRange(winkelwagenProducts);
                _context.SaveChanges();
            }

            return RedirectToPage("/Afrekenen/Afrekenen3");
        }

        public class KlantgegevensModel
        {
            [Required(ErrorMessage = "Voornaam is verplicht")]
            public string Voornaam { get; set; }

            [Required(ErrorMessage = "Achternaam is verplicht")]
            public string Achternaam { get; set; }

            [Required(ErrorMessage = "E-mailadres is verplicht")]
            [EmailAddress(ErrorMessage = "Ongeldig e-mailadres")]
            public string Email { get; set; }

            public string Telefoon { get; set; }

            [Required(ErrorMessage = "Straat is verplicht")]
            public string Straat { get; set; }

            [Required(ErrorMessage = "Huisnummer is verplicht")]
            public string Huisnummer { get; set; }

            public string Toevoeging { get; set; }

            [Required(ErrorMessage = "Postcode is verplicht")]
            public string Postcode { get; set; }

            [Required(ErrorMessage = "Plaats is verplicht")]
            public string Plaats { get; set; }

            public string Land { get; set; } = "Nederland";

            [Required(ErrorMessage = "Je moet akkoord gaan met de voorwaarden")]
            public bool AkkoordMetVoorwaarden { get; set; }
        }
    }
}