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
    public class StiznostLogika
    {
        static Collection<Stiznost> seznamStiznosti;
        public int? Insert(Stiznost stiznost)
        {
            return StiznostProxy.Insert(stiznost);
        }

        public int? Update(Stiznost stiznost)
        {
            return StiznostProxy.Update(stiznost);
        }

        public Collection<Stiznost> getSeznamStiznosti()
        {
            if (seznamStiznosti == null)
            {
                seznamStiznosti = StiznostProxy.Select();
            }
            return seznamStiznosti;
        }
    }
}
