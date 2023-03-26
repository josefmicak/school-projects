using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using RestauraceORM.Databaze.Proxy;

namespace RestauraceORM.Databaze.mssql
{
    class VozidloTable : VozidloProxy
    {
        public static string TABLE_NAME = "Vozidlo";

        public static string SQL_SELECT = "SELECT Id_vozidla, Datum_porizeni, Cena, Objem_kufru, Znacka, Pocet_ujetych_km FROM \"Vozidlo\"";
        public static string SQL_SELECT_ID = "SELECT Id_vozidla, Datum_porizeni, Cena, Objem_kufru, Znacka, Pocet_ujetych_km FROM \"Vozidlo\" WHERE Id_vozidla = @id";
        public static string SQL_INSERT = "INSERT INTO \"Vozidlo\" VALUES (@id_vozidla, @datum_porizeni, @cena," +
            "@objem_kufru, @znacka, @pocet_ujetych_km)";
        public static string SQL_DELETE_ID = "DELETE FROM \"Vozidlo\" WHERE Id_vozidla = @id";
        public static string SQL_UPDATE = "UPDATE \"Vozidlo\" SET Datum_porizeni = @datum_porizeni, Cena = @cena, Objem_kufru = @objem_kufru," +
            "Znacka = @znacka, Pocet_ujetych_km = @pocet_ujetych_km WHERE Id_vozidla = @id";

        protected override int insert(Vozidlo vozidlo, DatabaseProxy pDb = null)
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
            PrepareCommand(command, vozidlo);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override int update(Vozidlo vozidlo, DatabaseProxy pDb = null)
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
            PrepareCommand(command, vozidlo);
            command.Parameters.AddWithValue("@id", vozidlo.Id_vozidla);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override Collection<Vozidlo> select(DatabaseProxy pDb = null)
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
            Collection<Vozidlo> voz = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return voz;

        }

        protected override Vozidlo select(int idVozidla, DatabaseProxy pDb = null)
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
            command.Parameters.AddWithValue("@id", idVozidla);
            SqlDataReader reader = db.Select(command);

            Collection<Vozidlo> voz = Read(reader);
            Vozidlo vozidlo = null;
            if (voz.Count == 1)
            {
                vozidlo = voz[0];
            }
            reader.Close();
            db.Close();
            return vozidlo;
        }

        protected override int delete(int idVozidla, DatabaseProxy pDb = null)
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

            command.Parameters.AddWithValue("@id", idVozidla);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Vozidlo vozidlo)
        {
            command.Parameters.AddWithValue("@id_vozidla", vozidlo.Id_vozidla);
            command.Parameters.AddWithValue("@datum_porizeni", vozidlo.Datum_porizeni);
            command.Parameters.AddWithValue("@cena", vozidlo.Cena);
            command.Parameters.AddWithValue("@objem_kufru", vozidlo.Objem_kufru);
            command.Parameters.AddWithValue("@znacka", vozidlo.Znacka);
            command.Parameters.AddWithValue("@pocet_ujetych_km", vozidlo.Pocet_ujetych_km);
        }

        private static Collection<Vozidlo> Read(SqlDataReader reader)
        {
            Collection<Vozidlo> voz = new Collection<Vozidlo>();

            while (reader.Read())
            {
                int i = -1;
                Vozidlo vozidlo = new Vozidlo();
                vozidlo.Id_vozidla = reader.GetInt32(++i);
                vozidlo.Datum_porizeni = reader.GetDateTime(++i);
                vozidlo.Cena = reader.GetInt32(++i);
                vozidlo.Objem_kufru = reader.GetInt32(++i);
                vozidlo.Znacka = reader.GetString(++i);
                vozidlo.Pocet_ujetych_km = reader.GetInt32(++i);
                voz.Add(vozidlo);
            }

            return voz;
        }
    }
}
