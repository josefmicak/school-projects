using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomenovyModel
{
    public class Zaznam
    {
        public int Id_zaznamu { get; set; }
        public Vozidlo Vozidlo { get; set; }
        public DateTime Datum_zaznamu { get; set; }
        public int Pocet_ujetych_km { get; set; }
    }
}
