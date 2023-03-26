using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomenovyModel
{
    public class Rozvazka
    {
        public int Id_rozvazky { get; set; }
        public Zamestnanec Zamestnanec { get; set; }
        public Vozidlo Vozidlo { get; set; }
        public DateTime Cas_odjezdu { get; set; }
        public DateTime Cas_prijezdu { get; set; }
    }
}
