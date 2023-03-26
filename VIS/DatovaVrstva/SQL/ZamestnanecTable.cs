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
    class ZamestnanecTable : ZamestnanecProxy
    {
        public static string TABLE_NAME = "Zamestnanec";

        public static string SQL_SELECT = "SELECT Id_zamestnance, Jmeno, Prijmeni, Adresa, Telefonni_cislo, Pohlavi, Datum_narozeni, Datum_nastupu, Pozice, Plat, Vyhozen FROM \"Zamestnanec\"";
        public static string SQL_SELECT_ID = "SELECT Id_zamestnance, Jmeno, Prijmeni, Adresa, Telefonni_cislo, Pohlavi, Datum_narozeni, Datum_nastupu, Pozice, Plat, Vyhozen FROM \"Zamestnanec\" WHERE Id_zamestnance = @id";
        public static string SQL_INSERT = "INSERT INTO \"Zamestnanec\" VALUES (@id_zamestnance, @jmeno, @prijmeni, @adresa," +
            "@telefonni_cislo, @pohlavi, @datum_narozeni, @datum_nastupu, @pozice, @plat, @vyhozen)";
        public static string SQL_DELETE_ID = "DELETE FROM \"Zamestnanec\" WHERE Id_zamestnance = @id";
        public static string SQL_UPDATE = "UPDATE \"Zamestnanec\" SET Jmeno = @jmeno, Prijmeni = @prijmeni, Adresa = @adresa," +
            "Telefonni_cislo = @telefonni_cislo, Pohlavi = @pohlavi, Datum_narozeni = @datum_narozeni, Datum_nastupu = @datum_nastupu, Pozice = @pozice, Plat = @plat, Vyhozen = @vyhozen  WHERE Id_zamestnance = @id";

        protected override int insert(Zamestnanec zamestnanec, DatabaseProxy pDb = null)
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
            PrepareCommand(command, zamestnanec);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override int update(Zamestnanec zamestnanec, DatabaseProxy pDb = null)
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
            PrepareCommand(command, zamestnanec);
            command.Parameters.AddWithValue("@id", zamestnanec.Id_zamestnance);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override Collection<Zamestnanec> select(DatabaseProxy pDb = null)
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
            Collection<Zamestnanec> zam = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return zam;
        }

        protected override Zamestnanec select(int idZamestnance, DatabaseProxy pDb = null)
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
            command.Parameters.AddWithValue("@id", idZamestnance);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zam = Read(reader);
            Zamestnanec zamestnanec = null;
            if (zam.Count == 1)
            {
                zamestnanec = zam[0];
            }
            reader.Close();
            db.Close();
            return zamestnanec;
        }

        protected override int delete(int idZamestnance, DatabaseProxy pDb = null)
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

            command.Parameters.AddWithValue("@id", idZamestnance);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Zamestnanec zamestnanec)
        {
            command.Parameters.AddWithValue("@id_zamestnance", zamestnanec.Id_zamestnance);
            command.Parameters.AddWithValue("@jmeno", zamestnanec.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", zamestnanec.Prijmeni);
            command.Parameters.AddWithValue("@adresa", zamestnanec.Adresa);
            command.Parameters.AddWithValue("@telefonni_cislo", zamestnanec.Telefonni_cislo);
            command.Parameters.AddWithValue("@pohlavi", zamestnanec.Pohlavi);
            command.Parameters.AddWithValue("@datum_narozeni", zamestnanec.Datum_narozeni);
            command.Parameters.AddWithValue("@datum_nastupu", zamestnanec.Datum_nastupu);
            command.Parameters.AddWithValue("@pozice", zamestnanec.Pozice);
            command.Parameters.AddWithValue("@plat", zamestnanec.Plat);
            command.Parameters.AddWithValue("@vyhozen", zamestnanec.Vyhozen == null ? DBNull.Value : (object)zamestnanec.Vyhozen);
        }

        private static Collection<Zamestnanec> Read(SqlDataReader reader)
        {
            Collection<Zamestnanec> zam = new Collection<Zamestnanec>();

            while (reader.Read())
            {
                int i = -1;
                Zamestnanec zamestnanec = new Zamestnanec();
                zamestnanec.Id_zamestnance = reader.GetInt32(++i);
                zamestnanec.Jmeno = reader.GetString(++i);
                zamestnanec.Prijmeni = reader.GetString(++i);
                zamestnanec.Adresa = reader.GetString(++i);
                zamestnanec.Telefonni_cislo = reader.GetString(++i);
                zamestnanec.Pohlavi = char.Parse(reader.GetString(++i));
                zamestnanec.Datum_narozeni = reader.GetDateTime(++i);
                zamestnanec.Datum_nastupu = reader.GetDateTime(++i);
                zamestnanec.Pozice = reader.GetString(++i);
                zamestnanec.Plat = reader.GetInt32(++i);

                if (reader.IsDBNull(++i))
                    zamestnanec.Vyhozen = null;
                else
                    zamestnanec.Vyhozen = reader.GetString(i);

                zam.Add(zamestnanec);
            }

            return zam;
        }
    }
}
