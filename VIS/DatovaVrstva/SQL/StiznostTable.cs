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
    class StiznostTable : StiznostProxy
    {
        public static string TABLE_NAME = "Stiznost";

        public static string SQL_SELECT = "SELECT Stiznost.Id_stiznosti, Stiznost.Id_zakaznika, Stiznost.Id_zamestnance, Stiznost.Id_objednavky, Stiznost.Datum, Stiznost.Typ_stiznosti, Stiznost.Vyrizena, " +
            "Zamestnanec.Jmeno, Zamestnanec.Prijmeni " +
            "FROM \"Stiznost\" " +
            "JOIN Zamestnanec ON Zamestnanec.Id_zamestnance = Stiznost.Id_zamestnance";
        public static string SQL_SELECT_ID = "SELECT Stiznost.Id_stiznosti, Stiznost.Id_zakaznika, Stiznost.Id_zamestnance, Stiznost.Id_objednavky, Stiznost.Datum, Stiznost.Typ_stiznosti, Stiznost.Vyrizena, " +
            "Zamestnanec.Jmeno, Zamestnanec.Prijmeni " +
            "FROM \"Stiznost\" " +
            "JOIN Zamestnanec ON Zamestnanec.Id_zamestnance = Stiznost.Id_zamestnance " +
            "WHERE Id_stiznosti = @id";
        public static string SQL_SELECT_BY_ZAK = "SELECT Stiznost.Id_stiznosti, Stiznost.Id_zakaznika, Stiznost.Id_zamestnance, Stiznost.Id_objednavky, Stiznost.Datum, Stiznost.Typ_stiznosti, Stiznost.Vyrizena, " +
            "Zamestnanec.Jmeno, Zamestnanec.Prijmeni " +
            "FROM \"Stiznost\" " +
            "JOIN Zamestnanec ON Zamestnanec.Id_zamestnance = Stiznost.Id_zamestnance " +
            "WHERE Stiznost.Id_zakaznika = @id";
        public static string SQL_INSERT = "INSERT INTO \"Stiznost\" VALUES (@id_stiznosti, @id_zakaznika, @id_zamestnance, @id_objednavky," +
            "@datum, @typ_stiznosti, @vyrizena)";
        public static string SQL_DELETE_ID = "DELETE FROM \"Stiznost\" WHERE Id_stiznosti = @id";
        public static string SQL_UPDATE = "UPDATE \"Stiznost\" SET Id_zakaznika = @id_zakaznika, Id_zamestnance = @id_zamestnance, Id_objednavky = @id_objednavky, Datum = @datum," +
            "Typ_stiznosti = @typ_stiznosti, Vyrizena = @vyrizena WHERE Id_stiznosti = @id";
        public static string SQL_MAX_ID = "SELECT MAX(Id_stiznosti) FROM Stiznost";

        protected override int insert(Stiznost stiznost, DatabaseProxy pDb = null)
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
            PrepareCommand(command, stiznost);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override int update(Stiznost stiznost, DatabaseProxy pDb = null)
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
            PrepareCommand(command, stiznost);
            command.Parameters.AddWithValue("@id", stiznost.Id_stiznosti);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override Collection<Stiznost> select(DatabaseProxy pDb = null)
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
            Collection<Stiznost> sti = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return sti;

        }

        protected override Stiznost select(int idStiznosti, DatabaseProxy pDb = null)
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
            command.Parameters.AddWithValue("@id", idStiznosti);
            SqlDataReader reader = db.Select(command);

            Collection<Stiznost> sti = Read(reader);
            Stiznost stiznost = null;
            if (sti.Count == 1)
            {
                stiznost = sti[0];
            }
            reader.Close();
            db.Close();
            return stiznost;
        }

        private static void PrepareCommand(SqlCommand command, Stiznost stiznost)
        {
            command.Parameters.AddWithValue("@id_stiznosti", stiznost.Id_stiznosti);
            command.Parameters.AddWithValue("@id_zakaznika", stiznost.Zakaznik.Id_zakaznika);
            command.Parameters.AddWithValue("@id_zamestnance", stiznost.Zamestnanec.Id_zamestnance);
            command.Parameters.AddWithValue("@id_objednavky", stiznost.Objednavka.Id_objednavky);
            command.Parameters.AddWithValue("@datum", stiznost.Datum);
            command.Parameters.AddWithValue("@typ_stiznosti", stiznost.Typ_stiznosti);
            command.Parameters.AddWithValue("@vyrizena", stiznost.Vyrizena);
        }

        private static Collection<Stiznost> Read(SqlDataReader reader)
        {
            Collection<Stiznost> sti = new Collection<Stiznost>();

            while (reader.Read())
            {
                int i = -1;
                Stiznost stiznost = new Stiznost();
                stiznost.Id_stiznosti = reader.GetInt32(++i);
                stiznost.Zakaznik = new Zakaznik();
                stiznost.Zakaznik.Id_zakaznika = reader.GetInt32(++i);
                stiznost.Zamestnanec = new Zamestnanec();
                stiznost.Zamestnanec.Id_zamestnance = reader.GetInt32(++i);
                stiznost.Objednavka = new Objednavka();
                stiznost.Objednavka.Id_objednavky = reader.GetInt32(++i);
                stiznost.Datum = reader.GetDateTime(++i);
                stiznost.Typ_stiznosti = reader.GetInt32(++i);
                stiznost.Vyrizena = char.Parse(reader.GetString(++i));

                stiznost.Zamestnanec.Jmeno = reader.GetString(++i);
                stiznost.Zamestnanec.Prijmeni = reader.GetString(++i);
                sti.Add(stiznost);
            }

            return sti;
        }
    }
}
