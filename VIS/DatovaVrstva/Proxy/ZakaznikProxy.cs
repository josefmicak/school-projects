using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatovaVrstva.Proxy
{
    public abstract class ZakaznikProxy
    {
        private static ZakaznikProxy instance
        {
            get
            {
                if (TypDatabaze.GetTypDatabaze == TypDatabaze.Databaze.SQL)
                {
                    return new SQL.ZakaznikTable();
                }
                else
                {
                    return new XML.ZakaznikTable();
                }
            }
        }
        protected abstract int insert(Zakaznik zakaznik, DatabaseProxy pDb = null);
        protected abstract int update(Zakaznik zakaznik, DatabaseProxy pDb = null);
        protected abstract Collection<Zakaznik> select(DatabaseProxy pDb = null);
        protected abstract Zakaznik select(int idZakaznika, DatabaseProxy pDb = null);
        protected abstract int delete(int idZakaznika, DatabaseProxy pDb = null);

        public static int Insert(Zakaznik zakaznik, DatabaseProxy pDb = null)
        {
            return instance.insert(zakaznik, pDb);
        }

        public static int Update(Zakaznik zakaznik, DatabaseProxy pDb = null)
        {
            return instance.update(zakaznik, pDb);
        }

        public static Collection<Zakaznik> Select(DatabaseProxy pDb = null)
        {
            return instance.select(pDb);
        }

        public static Zakaznik Select(int idZakaznika, DatabaseProxy pDb = null)
        {
            return instance.select(idZakaznika, pDb);
        }

        public static int Delete(int idZakaznika, DatabaseProxy pDb = null)
        {
            return instance.delete(idZakaznika, pDb);
        }


    }
}
