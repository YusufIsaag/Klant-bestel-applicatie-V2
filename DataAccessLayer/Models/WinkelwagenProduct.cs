using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class WinkelwagenProduct
    {
        public int Id { get; set; }
        public int WinkelwagenProductId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Aantal { get; set; }
        public decimal TotaalBedrag => Aantal * (Product?.Prijs ?? 0);
        public int? BestellingId { get; set; }
        public Bestelling Bestelling { get; set; }

    }
}
