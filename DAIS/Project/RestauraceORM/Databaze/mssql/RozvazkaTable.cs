using System;
using System.Data;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using RestauraceORM.Databaze.Proxy;

namespace RestauraceORM.Databaze.mssql
{
    class RozvazkaTable : RozvazkaProxy
    {
        public static string TABLE_NAME = "Rozvazka";

        //Dotaz psan s durazem na minimalizaci poctu operaci.
        public static string SQL_SELECT = "SELECT Rozvazka.Id_rozvazky, Rozvazka.Id_zamestnance, Rozvazka.Id_vozidla, Rozvazka.Cas_odjezdu, Rozvazka.Cas_prijezdu, " +
            "Zamestnanec.Jmeno, Zamestnanec.Prijmeni, Zamestnanec.Adresa, Zamestnanec.Telefonni_cislo, Zamestnanec.Pohlavi, Zamestnanec.Datum_narozeni, Zamestnanec.Datum_nastupu, Zamestnanec.Pozice, Zamestnanec.Plat, Zamestnanec.Vyhozen, " +
            "Vozidlo.Datum_porizeni, Vozidlo.Cena, Vozidlo.Objem_kufru, Vozidlo.Znacka, Vozidlo.Pocet_ujetych_km " + 
            "FROM \"Rozvazka\" " +
            "JOIN Zamestnanec ON Zamestnanec.Id_zamestnance = Rozvazka.Id_zamestnance " +
            "JOIN Vozidlo ON Vozidlo.Id_vozidla = Rozvazka.Id_vozidla";
        public static string SQL_SELECT_ID = "SELECT Rozvazka.Id_rozvazky, Rozvazka.Id_zamestnance, Rozvazka.Id_vozidla, Rozvazka.Cas_odjezdu, Rozvazka.Cas_prijezdu, " +
        "Zamestnanec.Jmeno, Zamestnanec.Prijmeni, Zamestnanec.Adresa, Zamestnanec.Telefonni_cislo, Zamestnanec.Pohlavi, Zamestnanec.Datum_narozeni, Zamestnanec.Datum_nastupu, Zamestnanec.Pozice, Zamestnanec.Plat, Zamestnanec.Vyhozen, " +
        "Vozidlo.Datum_porizeni, Vozidlo.Cena, Vozidlo.Objem_kufru, Vozidlo.Znacka, Vozidlo.Pocet_ujetych_km " +
        "FROM \"Rozvazka\" " +
        "JOIN Zamestnanec ON Zamestnanec.Id_zamestnance = Rozvazka.Id_zamestnance " +
        "JOIN Vozidlo ON Vozidlo.Id_vozidla = Rozvazka.Id_vozidla " +
        "WHERE Id_rozvazky = @id";
        public static string SQL_INSERT = "INSERT INTO \"Rozvazka\" VALUES (@id_rozvazky, @id_zamestnance, @id_vozidla," +
            "@cas_odjezdu, @cas_prijezdu)";
        public static string SQL_DELETE_ID = "DELETE FROM \"Rozvazka\" WHERE Id_rozvazky = @id";
        public static string SQL_UPDATE = "UPDATE \"Rozvazka\" SET Id_zamestnance = @id_zamestnance, Id_vozidla = @id_vozidla," +
            "Cas_odjezdu = @cas_odjezdu, Cas_prijezdu = @cas_prijezdu WHERE Id_rozvazky = @id";


        protected override int insert(Rozvazka rozvazka, DatabaseProxy pDb = null)
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
            PrepareCommand(command, rozvazka);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override int update(Rozvazka rozvazka, DatabaseProxy pDb = null)
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
            PrepareCommand(command, rozvazka);
            command.Parameters.AddWithValue("@id", rozvazka.Id_rozvazky);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override Collection<Rozvazka> select(DatabaseProxy pDb = null)
        {
      //      helper = true;
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
            Collection<Rozvazka> roz = Read(reader);
            reader.Close();
            if (pDb == null)
            {
                db.Close();
            }
            return roz;

        }

        protected override Rozvazka select(int idRozvazky, DatabaseProxy pDb = null)
        {
      //      helper = false;
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
            command.Parameters.AddWithValue("@id", idRozvazky);
            SqlDataReader reader = db.Select(command);

            Collection<Rozvazka> roz = Read(reader);
            Rozvazka rozvazka = null;
            if (roz.Count == 1)
            {
                rozvazka = roz[0];
            }
            reader.Close();
            db.Close();
            return rozvazka;
        }

        protected override int delete(int idRozvazky, DatabaseProxy pDb = null)
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

            command.Parameters.AddWithValue("@id", idRozvazky);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        protected override DatabaseProxy kontrolaDostupnostiZamestnance(int idZamestnance, DatabaseProxy pDb = null)
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

            SqlCommand command = db.CreateCommand("kontrola_dostupnosti_zamestnance");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_zamestnance", idZamestnance);
            db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return pDb;
        }


        private static void PrepareCommand(SqlCommand command, Rozvazka rozvazka)
        {
            command.Parameters.AddWithValue("@id_rozvazky", rozvazka.Id_rozvazky);
            command.Parameters.AddWithValue("@id_zamestnance", rozvazka.Zamestnanec.Id_zamestnance);
            command.Parameters.AddWithValue("@id_vozidla", rozvazka.Vozidlo.Id_vozidla);
            command.Parameters.AddWithValue("@cas_odjezdu", rozvazka.Cas_odjezdu);
            command.Parameters.AddWithValue("@cas_prijezdu", rozvazka.Cas_prijezdu);
        }

        private static Collection<Rozvazka> Read(SqlDataReader reader)
        {
            Collection<Rozvazka> roz = new Collection<Rozvazka>();

            while (reader.Read())
            {
                int i = -1;
                Rozvazka rozvazka = new Rozvazka();
                rozvazka.Id_rozvazky = reader.GetInt32(++i);
                rozvazka.Zamestnanec = new Zamestnanec();
                rozvazka.Zamestnanec.Id_zamestnance = reader.GetInt32(++i);
                rozvazka.Vozidlo = new Vozidlo();
                rozvazka.Vozidlo.Id_vozidla = reader.GetInt32(++i);
                rozvazka.Cas_odjezdu = reader.GetDateTime(++i);
                rozvazka.Cas_prijezdu = reader.GetDateTime(++i);

                rozvazka.Zamestnanec.Jmeno = reader.GetString(++i);
                rozvazka.Zamestnanec.Prijmeni = reader.GetString(++i);
                rozvazka.Zamestnanec.Adresa = reader.GetString(++i);
                rozvazka.Zamestnanec.Telefonni_cislo = reader.GetString(++i);
                rozvazka.Zamestnanec.Pohlavi = char.Parse(reader.GetString(++i));
                rozvazka.Zamestnanec.Datum_narozeni = reader.GetDateTime(++i);
                rozvazka.Zamestnanec.Datum_nastupu = reader.GetDateTime(++i);
                rozvazka.Zamestnanec.Pozice = reader.GetString(++i);
                rozvazka.Zamestnanec.Plat = reader.GetInt32(++i);

                if (reader.IsDBNull(++i))
                    rozvazka.Zamestnanec.Vyhozen = null;
                else
                    rozvazka.Zamestnanec.Vyhozen = reader.GetString(i);

                rozvazka.Vozidlo.Datum_porizeni = reader.GetDateTime(++i);
                rozvazka.Vozidlo.Cena = reader.GetInt32(++i);
                rozvazka.Vozidlo.Objem_kufru = reader.GetInt32(++i);
                rozvazka.Vozidlo.Znacka = reader.GetString(++i);
                rozvazka.Vozidlo.Pocet_ujetych_km = reader.GetInt32(++i);
            
                roz.Add(rozvazka);
            }

            return roz;
        }
    }
}
