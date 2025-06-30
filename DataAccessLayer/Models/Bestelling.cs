using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Bestelling
    {
        public int BestellingId { get; set; }
        public DateTime Datum { get; set; }
        public string KlantNaam { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public decimal TotaalBedrag { get; set; }
        public List<WinkelwagenProduct> WinkelwagenProducts { get; set; } = new List<WinkelwagenProduct>();

    }
}
