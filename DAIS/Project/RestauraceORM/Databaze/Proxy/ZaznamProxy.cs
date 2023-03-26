using System.Collections.ObjectModel;
using System.Configuration;

namespace RestauraceORM.Databaze.Proxy
{
    abstract class ZaznamProxy
    {
        private static ZaznamProxy instance
        {
            get
            {
                return new mssql.ZaznamTable();
            }
        }

        protected abstract int insert(Zaznam zaznam, DatabaseProxy pDb = null);
        protected abstract int update(Zaznam zaznam, DatabaseProxy pDb = null);
        protected abstract Collection<Zaznam> select(DatabaseProxy pDb = null);
        protected abstract Zaznam select(int idZaznamu, DatabaseProxy pDb = null);
        protected abstract int delete(int idZaznamu, DatabaseProxy pDb = null);

        public static int Insert(Zaznam zaznam, DatabaseProxy pDb = null)
        {
            return instance.insert(zaznam, pDb);
        }

        public static int Update(Zaznam zaznam, DatabaseProxy pDb = null)
        {
            return instance.update(zaznam, pDb);
        }

        public static Collection<Zaznam> Select(DatabaseProxy pDb = null)
        {
            return instance.select(pDb);
        }

        public static Zaznam Select(int idZaznamu, DatabaseProxy pDb = null)
        {
            return instance.select(idZaznamu, pDb);
        }

        public static int Delete(int idZaznamu, DatabaseProxy pDb = null)
        {
            return instance.delete(idZaznamu, pDb);
        }

    }
}
