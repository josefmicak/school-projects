using System.Collections.ObjectModel;
using System.Configuration;

namespace RestauraceORM.Databaze.Proxy
{
    abstract class ZamestnanecProxy
    {
        private static ZamestnanecProxy instance
        {
            get
            {
                return new mssql.ZamestnanecTable();
            }
        }

        protected abstract int insert(Zamestnanec zamestnanec, DatabaseProxy pDb = null);
        protected abstract int update(Zamestnanec zamestnanec, DatabaseProxy pDb = null);
        protected abstract Collection<Zamestnanec> select(DatabaseProxy pDb = null);
        protected abstract Zamestnanec select(int idZamestnance, DatabaseProxy pDb = null);
        protected abstract int delete(int idZamestnance, DatabaseProxy pDb = null);
        protected abstract Zamestnanec get(string jmenoZam, string prijmeniZam, DatabaseProxy pDb = null);
        protected abstract DatabaseProxy vypocetEfektivnostiRidicu(DatabaseProxy pDb = null);

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
        public static Zamestnanec Get(string jmenoZam, string prijmeniZam, DatabaseProxy pDb = null)
        {
            return instance.get(jmenoZam, prijmeniZam, pDb);
        }

        public static DatabaseProxy VypocetEfektivnostiRidicu(DatabaseProxy pDb = null)
        {
            return instance.vypocetEfektivnostiRidicu(pDb);
        }

    }
}
