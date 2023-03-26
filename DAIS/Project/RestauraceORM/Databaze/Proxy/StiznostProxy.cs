using System.Collections.ObjectModel;
using System.Configuration;

namespace RestauraceORM.Databaze.Proxy
{
    abstract class StiznostProxy
    {
        private static StiznostProxy instance
        {
            get
            {
                return new mssql.StiznostTable();
            }
        }

        protected abstract int insert(Stiznost stiznost, DatabaseProxy pDb = null);
        protected abstract int update(Stiznost stiznost, DatabaseProxy pDb = null);
        protected abstract Collection<Stiznost> select(DatabaseProxy pDb = null);
        protected abstract Stiznost select(int idStiznosti, DatabaseProxy pDb = null);
        protected abstract Collection<Stiznost> select_by_zak(int idZakaznika, DatabaseProxy pDb = null);
        protected abstract int delete(int idStiznosti, DatabaseProxy pDb = null);
        protected abstract Stiznost max(DatabaseProxy pDb = null);

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

        public static Collection<Stiznost> Select_by_zak(int idZakaznika, DatabaseProxy pDb = null)
        {
            return instance.select_by_zak(idZakaznika, pDb);
        }

        public static int Delete(int idStiznosti, DatabaseProxy pDb = null)
        {
            return instance.delete(idStiznosti, pDb);
        }
        public static Stiznost Max(DatabaseProxy pDb = null)
        {
            return instance.max(pDb);
        }

    }
}
