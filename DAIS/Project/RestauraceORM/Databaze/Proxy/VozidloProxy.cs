using System.Collections.ObjectModel;
using System.Configuration;

namespace RestauraceORM.Databaze.Proxy
{
    abstract class VozidloProxy
    {
        private static VozidloProxy instance
        {
            get
            {
                return new mssql.VozidloTable();
            }
        }

        protected abstract int insert(Vozidlo vozidlo, DatabaseProxy pDb = null);
        protected abstract int update(Vozidlo vozidlo, DatabaseProxy pDb = null);
        protected abstract Collection<Vozidlo> select(DatabaseProxy pDb = null);
        protected abstract Vozidlo select(int idVozidla, DatabaseProxy pDb = null);
        protected abstract int delete(int idVozidla, DatabaseProxy pDb = null);

        public static int Insert(Vozidlo vozidlo, DatabaseProxy pDb = null)
        {
            return instance.insert(vozidlo, pDb);
        }

        public static int Update(Vozidlo vozidlo, DatabaseProxy pDb = null)
        {
            return instance.update(vozidlo, pDb);
        }

        public static Collection<Vozidlo> Select(DatabaseProxy pDb = null)
        {
            return instance.select(pDb);
        }

        public static Vozidlo Select(int idVozidla, DatabaseProxy pDb = null)
        {
            return instance.select(idVozidla, pDb);
        }

        public static int Delete(int idVozidla, DatabaseProxy pDb = null)
        {
            return instance.delete(idVozidla, pDb);
        }

    }
}
