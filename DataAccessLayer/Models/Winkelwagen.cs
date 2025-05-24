using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Winkelwagen
    {
        public Product Product { get; set; }
        public int Aantal { get; set; }

        //public decimal TotaalBedrag = Product.Price * Aantal;
    }
}
