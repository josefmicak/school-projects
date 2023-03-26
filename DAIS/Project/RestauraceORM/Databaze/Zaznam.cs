using System;

namespace RestauraceORM.Databaze
{
    class Zaznam
    {
        public int Id_zaznamu { get; set; }
        public Vozidlo Vozidlo { get; set; }
        public DateTime Datum_zaznamu { get; set; }        
        public int Pocet_ujetych_km { get; set; }

        public override string ToString()
        {
            return "ID zaznamu: " + Id_zaznamu + " ID vozidla: " + Vozidlo.Id_vozidla + " Datum_zaznamu: " + Datum_zaznamu + " Pocet_ujetych_km: " + Pocet_ujetych_km;
        }
    }
}
