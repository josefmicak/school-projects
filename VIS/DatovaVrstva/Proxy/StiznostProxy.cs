using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatovaVrstva.Proxy
{
    public abstract class StiznostProxy
    {
        private static StiznostProxy instance
        {
            get
            {
                if (TypDatabaze.GetTypDatabaze == TypDatabaze.Databaze.SQL)
                {
                    return new SQL.StiznostTable();
                }
                else
                {
                    return new XML.StiznostTable();
                }
            }
        }

        protected abstract int insert(Stiznost stiznost, DatabaseProxy pDb = null);
        protected abstract int update(Stiznost stiznost, DatabaseProxy pDb = null);
        protected abstract Collection<Stiznost> select(DatabaseProxy pDb = null);
        protected abstract Stiznost select(int idStiznosti, DatabaseProxy pDb = null);

        public static int Insert(Stiznost stiznost, DatabaseProxy pDb = null)
        {
            return instance.insert(stiznost, pDb);
        }

        public static int Update(Stiznost stiznost, DatabaseProxy pDb = null)
        {
            return instance.update(stiznost, pDb);
        }

        public static Collection<Stiznost> Select(DatabaseProxy pDb = null)
        {
            return instance.select(pDb);
        }

        public static Stiznost Select(int idStiznosti, DatabaseProxy pDb = null)
        {
            return instance.select(idStiznosti, pDb);
        }
    }
}
