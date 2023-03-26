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
    class ZakaznikTable : ZakaznikProxy
    {
        public static string TABLE_NAME = "Zakaznik";

        public static string SQL_SELECT = "SELECT Id_zakaznika, Jmeno, Prijmeni, Adresa, Telefonni_cislo, Neaktivni, Kategorie, V_blacklistu, Zrusen, Email, Heslo FROM \"Zakaznik\"";
        public static string SQL_SELECT_ID = "SELECT Id_zakaznika, Jmeno, Prijmeni, Adresa, Telefonni_cislo, Neaktivni, Kategorie, V_blacklistu, Zrusen, Email, Heslo  FROM \"Zakaznik\" WHERE Id_zakaznika = @id";
        public static string SQL_INSERT = "INSERT INTO \"Zakaznik\" VALUES (@id_zakaznika, @jmeno, @prijmeni, @adresa," +
            "@telefonni_cislo, @neaktivni, @kategorie, @v_blacklistu, @zrusen, @email, @heslo)";
        public static string SQL_DELETE_ID = "DELETE FROM \"Zakaznik\" WHERE Id_zakaznika = @id";
        public static string SQL_UPDATE = "UPDATE \"Zakaznik\" SET Jmeno = @jmeno, Prijmeni = @prijmeni, Adresa = @adresa," +
            "Telefonni_cislo = @telefonni_cislo, Neaktivni = @neaktivni, Kategorie = @kategorie, V_blacklistu = @v_blacklistu, Zrusen = @zrusen, Email = @email, Heslo = @heslo WHERE Id_zakaznika = @id";
        public static string SQL_GET_ID = "SELECT Id_zakaznika, Jmeno, Prijmeni, Adresa, Telefonni_cislo, Neaktivni, Kategorie, V_blacklistu, Zrusen, Email, Heslo FROM \"Zakaznik\" WHERE Id_zakaznika = @id";

        protected override int insert(Zakaznik zakaznik, DatabaseProxy pDb = null)
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
            PrepareCommand(command, zakaznik);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override int update(Zakaznik zakaznik, DatabaseProxy pDb = null)
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
            PrepareCommand(command, zakaznik);
            command.Parameters.AddWithValue("@id", zakaznik.Id_zakaznika);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override Collection<Zakaznik> select(DatabaseProxy pDb = null)
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
            Collection<Zakaznik> zak = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return zak;

        }

        protected override Zakaznik select(int idZakaznika, DatabaseProxy pDb = null)
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
            command.Parameters.AddWithValue("@id", idZakaznika);
            SqlDataReader reader = db.Select(command);

            Collection<Zakaznik> zak = Read(reader);
            Zakaznik zakaznik = null;
            if (zak.Count == 1)
            {
                zakaznik = zak[0];
            }
            reader.Close();
            db.Close();
            return zakaznik;
        }

        protected override int delete(int idZakaznika, DatabaseProxy pDb = null)
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

            command.Parameters.AddWithValue("@id", idZakaznika);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        private static void PrepareCommand(SqlCommand command, Zakaznik zakaznik)
        {
            command.Parameters.AddWithValue("@id_zakaznika", zakaznik.Id_zakaznika);
            command.Parameters.AddWithValue("@jmeno", zakaznik.Jmeno);
            command.Parameters.AddWithValue("@prijmeni", zakaznik.Prijmeni);
            command.Parameters.AddWithValue("@adresa", zakaznik.Adresa);
            command.Parameters.AddWithValue("@telefonni_cislo", zakaznik.Telefonni_cislo);
            command.Parameters.AddWithValue("@neaktivni", zakaznik.Neaktivni);
            command.Parameters.AddWithValue("@kategorie", zakaznik.Kategorie);
            command.Parameters.AddWithValue("@v_blacklistu", zakaznik.V_blacklistu == null ? DBNull.Value : (object)zakaznik.V_blacklistu);
            command.Parameters.AddWithValue("@zrusen", zakaznik.Zrusen == null ? DBNull.Value : (object)zakaznik.Zrusen);
            command.Parameters.AddWithValue("@email", zakaznik.Email);
            command.Parameters.AddWithValue("@heslo", zakaznik.Heslo);
        }

        private static Collection<Zakaznik> Read(SqlDataReader reader)
        {
            Collection<Zakaznik> zak = new Collection<Zakaznik>();

            while (reader.Read())
            {
                int i = -1;
                Zakaznik zakaznik = new Zakaznik();
                zakaznik.Id_zakaznika = reader.GetInt32(++i);
                zakaznik.Jmeno = reader.GetString(++i);
                zakaznik.Prijmeni = reader.GetString(++i);
                zakaznik.Adresa = reader.GetString(++i);
                zakaznik.Telefonni_cislo = reader.GetString(++i);
                zakaznik.Neaktivni = char.Parse(reader.GetString(++i));
                zakaznik.Kategorie = reader.GetInt32(++i);

                if (reader.IsDBNull(++i))
                    zakaznik.V_blacklistu = "";
                else
                    zakaznik.V_blacklistu = reader.GetString(i);

                if (reader.IsDBNull(++i))
                    zakaznik.Zrusen = "";
                else
                    zakaznik.Zrusen = reader.GetString(i);

                zakaznik.Email = reader.GetString(++i);
                zakaznik.Heslo = reader.GetString(++i);


                zak.Add(zakaznik);
            }

            return zak;
        }
    }
}
