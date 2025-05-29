using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Winkelwagen
    {
        public int Id { get; set; }
        public int ProdutId { get; set; }
        public Product Product { get; set; }
        public int Aantal { get; set; } = 1;
        public decimal TotaalBedrag { get; set; }
    }
}
