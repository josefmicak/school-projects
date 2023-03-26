using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using RestauraceORM.Databaze.Proxy;

namespace RestauraceORM.Databaze.mssql
{
    class ZaznamTable : ZaznamProxy
    {
        public static string TABLE_NAME = "Historie_ujetych_km";

        public static string SQL_SELECT = "SELECT Id_zaznamu, Id_vozidla, Datum_zaznamu, Pocet_ujetych_km FROM \"Historie_ujetych_km\"";
        public static string SQL_SELECT_ID = "SELECT Id_zaznamu, Id_vozidla, Datum_zaznamu, Pocet_ujetych_km FROM \"Historie_ujetych_km\" WHERE Id_zaznamu = @id";
        public static string SQL_INSERT = "INSERT INTO \"Historie_ujetych_km\" VALUES (@id_zaznamu, @id_vozidla, @datum_zaznamu, @pocet_ujetych_km)";
        public static string SQL_DELETE_ID = "DELETE FROM \"Historie_ujetych_km\" WHERE Id_zaznamu = @id";
        public static string SQL_UPDATE = "UPDATE \"Historie_ujetych_km\" SET Id_vozidla = @id_vozidla, Datum_zaznamu = @datum_zaznamu," +
            "Pocet_ujetych_km = @pocet_ujetych_km WHERE Id_zaznamu = @id";

        protected override int insert(Zaznam zaznam, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, zaznam);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override int update(Zaznam zaznam, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zaznam);
            command.Parameters.AddWithValue("@id", zaznam.Id_zaznamu);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override Collection<Zaznam> select(DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }
            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);
            Collection<Zaznam> zaz = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return zaz;

        }

        protected override Zaznam select(int idZaznamu, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.AddWithValue("@id", idZaznamu);
            SqlDataReader reader = db.Select(command);

            Collection<Zaznam> zaz = Read(reader);
            Zaznam zaznam = null;
            if (zaz.Count == 1)
            {
                zaznam = zaz[0];
            }
            reader.Close();
            db.Close();
            return zaznam;
        }

        protected override int delete(int idZaznamu, DatabaseProxy pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@id", idZaznamu);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Zaznam zaznam)
        {
            command.Parameters.AddWithValue("@id_zaznamu", zaznam.Id_zaznamu);
            command.Parameters.AddWithValue("@id_vozidla", zaznam.Vozidlo.Id_vozidla);
            command.Parameters.AddWithValue("@datum_zaznamu", zaznam.Datum_zaznamu);
            command.Parameters.AddWithValue("@pocet_ujetych_km", zaznam.Pocet_ujetych_km);
        }

        private static Collection<Zaznam> Read(SqlDataReader reader)
        {
            Collection<Zaznam> zaz = new Collection<Zaznam>();

            while (reader.Read())
            {
                int i = -1;
                Zaznam zaznam = new Zaznam();
                zaznam.Id_zaznamu = reader.GetInt32(++i);
                zaznam.Vozidlo = new Vozidlo();
                zaznam.Vozidlo.Id_vozidla = reader.GetInt32(++i);
                zaznam.Datum_zaznamu = reader.GetDateTime(++i);              
                zaznam.Pocet_ujetych_km = reader.GetInt32(++i);
                zaz.Add(zaznam);
            }

            return zaz;
        }
    }
}
