using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatovaVrstva.Proxy
{
    public abstract class HodnoceniProxy
    {
        private static HodnoceniProxy instance
        {
            get
            {
                if (TypDatabaze.GetTypDatabaze == TypDatabaze.Databaze.SQL)
                {
                    return new SQL.HodnoceniTable();
                }
                else
                {
                    return new XML.HodnoceniTable();
                }
            }
        }

        protected abstract int insert(Hodnoceni hodnoceni, DatabaseProxy pDb = null);
        protected abstract int update(Hodnoceni hodnoceni, DatabaseProxy pDb = null);
        protected abstract Collection<Hodnoceni> select(DatabaseProxy pDb = null);
        protected abstract Hodnoceni select(int idHodnoceni, DatabaseProxy pDb = null);
        protected abstract int delete(int idHodnoceni, DatabaseProxy pDb = null);

        public static int Insert(Hodnoceni hodnoceni, DatabaseProxy pDb = null)
        {
            return instance.insert(hodnoceni, pDb);
        }

        public static int Update(Hodnoceni hodnoceni, DatabaseProxy pDb = null)
        {
            return instance.update(hodnoceni, pDb);
        }

        public static Collection<Hodnoceni> Select(DatabaseProxy pDb = null)
        {
            return instance.select(pDb);
        }

        public static Hodnoceni Select(int idHodnoceni, DatabaseProxy pDb = null)
        {
            return instance.select(idHodnoceni, pDb);
        }

        public static int Delete(int idHodnoceni, DatabaseProxy pDb = null)
        {
            return instance.delete(idHodnoceni, pDb);
        }
    }
}
