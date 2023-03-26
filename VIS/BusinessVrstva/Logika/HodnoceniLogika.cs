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
    public class HodnoceniLogika
    {
        static Collection<Hodnoceni> seznamHodnoceni;
        public int? Insert(Hodnoceni hodnoceni)
        {
            return HodnoceniProxy.Insert(hodnoceni);
        }

        public int? Update(Hodnoceni hodnoceni)
        {
            return HodnoceniProxy.Update(hodnoceni);
        }

        public int? Delete(int vybranahodnoceni)
        {
            return HodnoceniProxy.Delete(vybranahodnoceni);
        }

        public Collection<Hodnoceni> getSeznamHodnoceni()
        {
            if (seznamHodnoceni == null)
            {
                seznamHodnoceni = HodnoceniProxy.Select();
            }
            return seznamHodnoceni;
        }
    }
}
