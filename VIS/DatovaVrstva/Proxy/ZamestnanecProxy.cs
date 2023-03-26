using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatovaVrstva.Proxy
{
    public abstract class ZamestnanecProxy
    {
        private static ZamestnanecProxy instance
        {
            get
            {
                if (TypDatabaze.GetTypDatabaze == TypDatabaze.Databaze.SQL)
                {
                    return new SQL.ZamestnanecTable();
                }
                else
                {
                    return new XML.ZamestnanecTable();
                }
            }
        }

        protected abstract int insert(Zamestnanec zamestnanec, DatabaseProxy pDb = null);
        protected abstract int update(Zamestnanec zamestnanec, DatabaseProxy pDb = null);
        protected abstract Collection<Zamestnanec> select(DatabaseProxy pDb = null);
        protected abstract Zamestnanec select(int idZamestnance, DatabaseProxy pDb = null);
        protected abstract int delete(int idZamestnance, DatabaseProxy pDb = null);


        public static int Insert(Zamestnanec zamestnanec, DatabaseProxy pDb = null)
        {
            return instance.insert(zamestnanec, pDb);
        }

        public static int Update(Zamestnanec zamestnanec, DatabaseProxy pDb = null)
        {
            return instance.update(zamestnanec, pDb);
        }

        public static Collection<Zamestnanec> Select(DatabaseProxy pDb = null)
        {
            return instance.select(pDb);
        }

        public static Zamestnanec Select(int idZamestnance, DatabaseProxy pDb = null)
        {
            return instance.select(idZamestnance, pDb);
        }

        public static int Delete(int idZamestnance, DatabaseProxy pDb = null)
        {
            return instance.delete(idZamestnance, pDb);
        }
    }
}
