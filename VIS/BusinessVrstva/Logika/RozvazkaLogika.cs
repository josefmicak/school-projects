using DatovaVrstva.Proxy;
using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessVrstva.Logika
{
    public class RozvazkaLogika
    {
        public Collection<Rozvazka> Select()
        {
            return RozvazkaProxy.Select();
        }

        public Rozvazka Select(int idRozvazky)
        {
            return RozvazkaProxy.Select(idRozvazky);
        }
    }
}
