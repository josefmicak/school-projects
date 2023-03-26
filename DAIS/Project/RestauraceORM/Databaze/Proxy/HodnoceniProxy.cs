using System.Collections.ObjectModel;
using System.Configuration;

namespace RestauraceORM.Databaze.Proxy
{
    abstract class HodnoceniProxy
    {
        private static HodnoceniProxy instance
        {
            get
            {
                return new mssql.HodnoceniTable();
            }
        }

        protected abstract int insert(Hodnoceni hodnoceni, DatabaseProxy pDb = null);
        protected abstract int update(Hodnoceni hodnoceni, DatabaseProxy pDb = null);
        protected abstract Collection<Hodnoceni> select(DatabaseProxy pDb = null);
        protected abstract Hodnoceni select(int idHodnoceni, DatabaseProxy pDb = null);
        protected abstract Collection<Hodnoceni> select_by_zak(int idZakaznika, DatabaseProxy pDb = null);
        protected abstract int delete(int idHodnoceni, DatabaseProxy pDb = null);
        protected abstract Hodnoceni max(DatabaseProxy pDb = null);
        protected abstract DatabaseProxy posouzeniHodnoceni(DatabaseProxy pDb = null);

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

        public static Collection<Hodnoceni> Select_by_zak(int idZakaznika, DatabaseProxy pDb = null)
        {
            return instance.select_by_zak(idZakaznika, pDb);
        }

        public static int Delete(int idHodnoceni, DatabaseProxy pDb = null)
        {
            return instance.delete(idHodnoceni, pDb);
        }

        public static Hodnoceni Max(DatabaseProxy pDb = null)
        {
            return instance.max(pDb);
        }

        public static DatabaseProxy PosouzeniHodnoceni(DatabaseProxy pDb = null)
        {
            return instance.posouzeniHodnoceni(pDb);
        }
    }
}
