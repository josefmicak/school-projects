using System.Collections.ObjectModel;
using System.Configuration;

namespace RestauraceORM.Databaze.Proxy
{
    abstract class ZakaznikProxy
    {
        private static ZakaznikProxy instance
        {
            get
            {
                return new mssql.ZakaznikTable();
            }
        }

        protected abstract int insert(Zakaznik zakaznik, DatabaseProxy pDb = null);
        protected abstract int update(Zakaznik zakaznik, DatabaseProxy pDb = null);
        protected abstract Collection<Zakaznik> select(DatabaseProxy pDb = null);
        protected abstract Zakaznik select(int idZakaznika, DatabaseProxy pDb = null);
        protected abstract int delete(int idZakaznika, DatabaseProxy pDb = null);
        protected abstract Zakaznik get(string jmenoZak, string prijmeniZak, DatabaseProxy pDb = null);
        protected abstract DatabaseProxy sumarizaceAktivityZakazniku(DatabaseProxy pDb = null);

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

        public static Zakaznik Get(string jmenoZak, string prijmeniZak, DatabaseProxy pDb = null)
        {
            return instance.get(jmenoZak, prijmeniZak, pDb);
        }

        public static DatabaseProxy SumarizaceAktivityZakazniku(DatabaseProxy pDb = null)
        {
            return instance.sumarizaceAktivityZakazniku(pDb);
        }

    }
}
