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
    class ObjednavkaTable : ObjednavkaProxy
    {
        public static string TABLE_NAME = "Objednavka";

        public static string SQL_SELECT = "SELECT Objednavka.Id_objednavky, Objednavka.Id_zakaznika, Objednavka.Id_zamestnance, Objednavka.Id_rozvazky, Objednavka.Datum_vytvoreni, Objednavka.Cena, Objednavka.Vyplacena, " +
            "Zakaznik.Jmeno, Zakaznik.prijmeni, " +
            "Zamestnanec.Jmeno, Zamestnanec.prijmeni " +
            "FROM \"Objednavka\" " +
            "JOIN Zakaznik ON Zakaznik.Id_zakaznika = Objednavka.Id_zakaznika " +
            "JOIN Zamestnanec ON Zamestnanec.Id_zamestnance = Objednavka.Id_zamestnance";
        public static string SQL_SELECT_ID = "SELECT Objednavka.Id_objednavky, Objednavka.Id_zakaznika, Objednavka.Id_zamestnance, Objednavka.Id_rozvazky, Objednavka.Datum_vytvoreni, Objednavka.Cena, Objednavka.Vyplacena, " +
        "Zakaznik.Jmeno, Zakaznik.prijmeni, " +
        "Zamestnanec.Jmeno, Zamestnanec.prijmeni " +
        "FROM \"Objednavka\" " +
        "JOIN Zakaznik ON Zakaznik.Id_zakaznika = Objednavka.Id_zakaznika " +
        "JOIN Zamestnanec ON Zamestnanec.Id_zamestnance = Objednavka.Id_zamestnance " +
        "WHERE Id_objednavky = @id";
        public static string SQL_INSERT = "INSERT INTO \"Objednavka\" VALUES (@id_objednavky, @id_zakaznika, @id_zamestnance, @id_rozvazky," +
            "@datum_vytvoreni, @cena, @vyplacena)";
        public static string SQL_DELETE_ID = "DELETE FROM \"Objednavka\" WHERE Id_objednavky = @id";
        public static string SQL_UPDATE = "UPDATE \"Objednavka\" SET Id_zakaznika = @id_zakaznika, Id_zamestnance = @id_zamestnance, Id_rozvazky = @id_rozvazky," +
            "Datum_vytvoreni = @datum_vytvoreni, Cena = @cena, Vyplacena = @vyplacena  WHERE Id_objednavky = @id";

        protected override int insert(Objednavka objednavka, DatabaseProxy pDb = null)
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
            PrepareCommand(command, objednavka);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override int update(Objednavka objednavka, DatabaseProxy pDb = null)
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
            PrepareCommand(command, objednavka);
            command.Parameters.AddWithValue("@id", objednavka.Id_objednavky);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override Collection<Objednavka> select(DatabaseProxy pDb = null)
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
            Collection<Objednavka> obj = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return obj;

        }

        protected override Objednavka select(int idObjednavky, DatabaseProxy pDb = null)
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
            command.Parameters.AddWithValue("@id", idObjednavky);
            SqlDataReader reader = db.Select(command);

            Collection<Objednavka> obj = Read(reader);
            Objednavka objednavka = null;
            if (obj.Count == 1)
            {
                objednavka = obj[0];
            }
            reader.Close();
            db.Close();
            return objednavka;
        }

        protected override int delete(int idObjednavky, DatabaseProxy pDb = null)
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

            command.Parameters.AddWithValue("@id", idObjednavky);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Objednavka objednavka)
        {
            command.Parameters.AddWithValue("@id_objednavky", objednavka.Id_objednavky);
            command.Parameters.AddWithValue("@id_zakaznika", objednavka.Zakaznik.Id_zakaznika);
            command.Parameters.AddWithValue("@id_zamestnance", objednavka.Zamestnanec.Id_zamestnance);
            command.Parameters.AddWithValue("@id_rozvazky", objednavka.Rozvazka.Id_rozvazky);
            command.Parameters.AddWithValue("@datum_vytvoreni", objednavka.Datum_vytvoreni);
            command.Parameters.AddWithValue("@cena", objednavka.Cena);
            command.Parameters.AddWithValue("@vyplacena", objednavka.Vyplacena);
        }

        private static Collection<Objednavka> Read(SqlDataReader reader)
        {
            Collection<Objednavka> obj = new Collection<Objednavka>();

            while (reader.Read())
            {
                int i = -1;
                Objednavka objednavka = new Objednavka();
                objednavka.Id_objednavky = reader.GetInt32(++i);
                objednavka.Zakaznik = new Zakaznik();
                objednavka.Zakaznik.Id_zakaznika = reader.GetInt32(++i);
                objednavka.Zamestnanec = new Zamestnanec();
                objednavka.Zamestnanec.Id_zamestnance = reader.GetInt32(++i);
                objednavka.Rozvazka = new Rozvazka();
                objednavka.Rozvazka.Id_rozvazky = reader.GetInt32(++i);
                objednavka.Datum_vytvoreni = reader.GetDateTime(++i);
                objednavka.Cena = reader.GetInt32(++i);
                objednavka.Vyplacena = char.Parse(reader.GetString(++i));

                objednavka.Zakaznik.Jmeno = reader.GetString(++i);
                objednavka.Zakaznik.Prijmeni = reader.GetString(++i);

                objednavka.Zamestnanec.Jmeno = reader.GetString(++i);
                objednavka.Zamestnanec.Prijmeni = reader.GetString(++i);
                obj.Add(objednavka);
            }

            return obj;
        }
    }
}
