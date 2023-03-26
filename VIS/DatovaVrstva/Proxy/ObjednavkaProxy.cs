using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatovaVrstva.Proxy
{
    public abstract class ObjednavkaProxy
    {
        private static ObjednavkaProxy instance
        {
            get
            {
                if (TypDatabaze.GetTypDatabaze == TypDatabaze.Databaze.SQL)
                {
                    return new SQL.ObjednavkaTable();
                }
                else
                {
                    return new XML.ObjednavkaTable();
                }
            }
        }

        protected abstract int insert(Objednavka objednavka, DatabaseProxy pDb = null);
        protected abstract int update(Objednavka objednavka, DatabaseProxy pDb = null);
        protected abstract Collection<Objednavka> select(DatabaseProxy pDb = null);
        protected abstract Objednavka select(int idObjednavky, DatabaseProxy pDb = null);
        protected abstract int delete(int idObjednavky, DatabaseProxy pDb = null);

        public static int Insert(Objednavka objednavka, DatabaseProxy pDb = null)
        {
            return instance.insert(objednavka, pDb);
        }

        public static int Update(Objednavka objednavka, DatabaseProxy pDb = null)
        {
            return instance.update(objednavka, pDb);
        }

        public static Collection<Objednavka> Select(DatabaseProxy pDb = null)
        {
            return instance.select(pDb);
        }

        public static Objednavka Select(int idObjednavky, DatabaseProxy pDb = null)
        {
            return instance.select(idObjednavky, pDb);
        }

        public static int Delete(int idObjednavky, DatabaseProxy pDb = null)
        {
            return instance.delete(idObjednavky, pDb);
        }
    }
}
