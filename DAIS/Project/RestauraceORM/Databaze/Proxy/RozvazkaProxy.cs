using System.Collections.ObjectModel;
using System.Configuration;

namespace RestauraceORM.Databaze.Proxy
{
    abstract class RozvazkaProxy
    {
        private static RozvazkaProxy instance
        {
            get
            {
                return new mssql.RozvazkaTable();
            }
        }

        protected abstract int insert(Rozvazka rozvazka, DatabaseProxy pDb = null);
        protected abstract int update(Rozvazka rozvazka, DatabaseProxy pDb = null);
        protected abstract Collection<Rozvazka> select(DatabaseProxy pDb = null);
        protected abstract Rozvazka select(int idRozvazky, DatabaseProxy pDb = null);
        protected abstract int delete(int idRozvazky, DatabaseProxy pDb = null);
        protected abstract DatabaseProxy kontrolaDostupnostiZamestnance(int idZamestnance, DatabaseProxy pDb = null);

        public static int Insert(Rozvazka rozvazka, DatabaseProxy pDb = null)
        {
            return instance.insert(rozvazka, pDb);
        }

        public static int Update(Rozvazka rozvazka, DatabaseProxy pDb = null)
        {
            return instance.update(rozvazka, pDb);
        }

        public static Collection<Rozvazka> Select(DatabaseProxy pDb = null)
        {
            return instance.select(pDb);
        }

        public static Rozvazka Select(int idRozvazky, DatabaseProxy pDb = null)
        {
            return instance.select(idRozvazky, pDb);
        }

        public static int Delete(int idRozvazky, DatabaseProxy pDb = null)
        {
            return instance.delete(idRozvazky, pDb);
        }

        public static DatabaseProxy KontrolaDostupnostiZamestnance(int idZamestnance, DatabaseProxy pDb = null)
        {
            return instance.kontrolaDostupnostiZamestnance(idZamestnance, pDb);
        }

    }
}
