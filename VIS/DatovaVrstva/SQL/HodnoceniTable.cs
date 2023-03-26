using DatovaVrstva.Proxy;
using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatovaVrstva.SQL
{
    class HodnoceniTable : HodnoceniProxy
    {
        public static string TABLE_NAME = "Hodnoceni";

        public static string SQL_SELECT = "SELECT Hodnoceni.Id_hodnoceni, Hodnoceni.Id_zakaznika, Hodnoceni.Id_zamestnance, Hodnoceni.Id_objednavky, Hodnoceni.Datum, Hodnoceni.Hodnoceni, " +
            "Zamestnanec.Jmeno, Zamestnanec.Prijmeni " +
            "FROM \"Hodnoceni\" " +
            "JOIN Zamestnanec ON Zamestnanec.Id_zamestnance = Hodnoceni.Id_zamestnance";
        public static string SQL_SELECT_ID = "SELECT Hodnoceni.Id_hodnoceni, Hodnoceni.Id_zakaznika, Hodnoceni.Id_zamestnance, Hodnoceni.Id_objednavky, Hodnoceni.Datum, Hodnoceni.Hodnoceni, " +
            "Zamestnanec.Jmeno, Zamestnanec.Prijmeni " +
            "FROM \"Hodnoceni\" " +
            "JOIN Zamestnanec ON Zamestnanec.Id_zamestnance = Hodnoceni.Id_zamestnance " +
            "WHERE Id_hodnoceni = @id";
        public static string SQL_SELECT_BY_ZAK = "SELECT Hodnoceni.Id_hodnoceni, Hodnoceni.Id_zakaznika, Hodnoceni.Id_zamestnance, Hodnoceni.Id_objednavky, Hodnoceni.Datum, Hodnoceni.Hodnoceni, " +
        "Zamestnanec.Jmeno, Zamestnanec.Prijmeni " +
        "FROM \"Hodnoceni\" " +
        "JOIN Zamestnanec ON Zamestnanec.Id_zamestnance = Hodnoceni.Id_zamestnance " +
        "WHERE Hodnoceni.Id_zakaznika = @id";
        public static string SQL_INSERT = "INSERT INTO \"Hodnoceni\" VALUES (@id_hodnoceni, @id_zakaznika, @id_zamestnance, @id_objednavky," +
            "@datum, @hodnoceni)";
        public static string SQL_DELETE_ID = "DELETE FROM \"Hodnoceni\" WHERE Id_hodnoceni = @id";
        public static string SQL_UPDATE = "UPDATE \"Hodnoceni\" SET Id_zakaznika = @id_zakaznika, Id_zamestnance = @id_zamestnance, Id_objednavky = @id_objednavky, Datum = @datum," +
            "Hodnoceni = @hodnoceni WHERE Id_hodnoceni = @id";
        public static string SQL_MAX_ID = "SELECT MAX(Id_hodnoceni) FROM Hodnoceni";

        protected override int insert(Hodnoceni hodnoceni, DatabaseProxy pDb = null)
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
            PrepareCommand(command, hodnoceni);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override int update(Hodnoceni hodnoceni, DatabaseProxy pDb = null)
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
            PrepareCommand(command, hodnoceni);
            command.Parameters.AddWithValue("@id", hodnoceni.Id_hodnoceni);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override Collection<Hodnoceni> select(DatabaseProxy pDb = null)
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
            Collection<Hodnoceni> hod = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return hod;

        }

        protected override Hodnoceni select(int idHodnoceni, DatabaseProxy pDb = null)
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
            command.Parameters.AddWithValue("@id", idHodnoceni);
            SqlDataReader reader = db.Select(command);

            Collection<Hodnoceni> hod = Read(reader);
            Hodnoceni hodnoceni = null;
            if (hod.Count == 1)
            {
                hodnoceni = hod[0];
            }
            reader.Close();
            db.Close();
            return hodnoceni;
        }

        protected override int delete(int idHodnoceni, DatabaseProxy pDb = null)
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

            command.Parameters.AddWithValue("@id", idHodnoceni);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Hodnoceni hodnoceni)
        {
            command.Parameters.AddWithValue("@id_hodnoceni", hodnoceni.Id_hodnoceni);
            command.Parameters.AddWithValue("@id_zakaznika", hodnoceni.Zakaznik.Id_zakaznika);
            command.Parameters.AddWithValue("@id_zamestnance", hodnoceni.Zamestnanec.Id_zamestnance);
            command.Parameters.AddWithValue("@id_objednavky", hodnoceni.Objednavka.Id_objednavky);
            command.Parameters.AddWithValue("@datum", hodnoceni.Datum);
            command.Parameters.AddWithValue("@hodnoceni", hodnoceni.Udelene_hodnoceni);
        }

        private static Collection<Hodnoceni> Read(SqlDataReader reader)
        {
            Collection<Hodnoceni> hod = new Collection<Hodnoceni>();

            while (reader.Read())
            {
                int i = -1;
                Hodnoceni hodnoceni = new Hodnoceni();
                hodnoceni.Id_hodnoceni = reader.GetInt32(++i);
                hodnoceni.Zakaznik = new Zakaznik();
                hodnoceni.Zakaznik.Id_zakaznika = reader.GetInt32(++i);
                hodnoceni.Zamestnanec = new Zamestnanec();
                hodnoceni.Zamestnanec.Id_zamestnance = reader.GetInt32(++i);
                hodnoceni.Objednavka = new Objednavka();
                hodnoceni.Objednavka.Id_objednavky = reader.GetInt32(++i);
                hodnoceni.Datum = reader.GetDateTime(++i);
                hodnoceni.Udelene_hodnoceni = reader.GetInt32(++i);

                hodnoceni.Zamestnanec.Jmeno = reader.GetString(++i);
                hodnoceni.Zamestnanec.Prijmeni = reader.GetString(++i);
                hod.Add(hodnoceni);
            }

            return hod;
        }
    }
}
