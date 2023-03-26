using DatovaVrstva.Proxy;
using DomenovyModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessVrstva.Logika
{
    public class ZakaznikLogika
    {
        static Collection<Zakaznik> seznamZakazniku;
        public Collection<Zakaznik> Select()
        {
            return ZakaznikProxy.Select();
        }

        public Zakaznik Select(int idZakaznika)
        {
            return ZakaznikProxy.Select(idZakaznika);
        }

        public int? Insert(Zakaznik zakaznik)
        {
            if (jeAdresaJedinecna(zakaznik))
            {
                seznamZakazniku.Add(zakaznik);
                return ZakaznikProxy.Insert(zakaznik);
            }
            else
            {
                throw new Exception("Tato Emailová adresa je již přiřazena k jinému zákazníkovi. Vyberte prosím jinou adresu");
            }
        }

        public int? Update(Zakaznik zakaznik)
        {
            if (jeAdresaJedinecna(zakaznik))
            {
                return ZakaznikProxy.Update(zakaznik);
            }
            else
            {
                throw new Exception("Tato Emailová adresa je již přiřazena k jinému zákazníkovi. Vyberte prosím jinou adresu");
            }
        }

        public int? Delete(int vybranyZakaznik)
        {
            return ZakaznikProxy.Delete(vybranyZakaznik);
        }

        public Collection<Zakaznik> getSeznamZakazniku()
        {
            if (seznamZakazniku == null)
            {
                seznamZakazniku = ZakaznikProxy.Select();
            }
            return seznamZakazniku;
        }

        public Zakaznik Login(string email, string heslo)
        {
            if(seznamZakazniku == null)
            {
                seznamZakazniku = getSeznamZakazniku();
            }
            Zakaznik zakaznik = new Zakaznik();
            for (int i = 0; i < seznamZakazniku.Count; i++)
            {
                if (seznamZakazniku[i].Email == email)
                {
                    zakaznik = seznamZakazniku[i];
                }
            }
            if (zakaznik.Email == null)
            {
                throw new Exception("Nenalezli jsme zákazníka s takovým emailem. Zkuste to prosím znovu");
            }
            else
            {
                if (zakaznik.Heslo == heslo)
                {
                    return zakaznik;
                }
                else
                {
                    throw new Exception("Špatné heslo. Zkuste to prosím znovu");
                }
            }
        }

        public Zakaznik upravitHeslo(Zakaznik zakaznik, string stareHeslo, string noveHeslo, string noveHesloPotvrzeni)
        {
            if (zakaznik.Heslo != stareHeslo)
            {
                throw new Exception("Špatně jste zadali vaše současné heslo. Zkuste to prosím znovu.");
            }
            else if (noveHeslo != noveHesloPotvrzeni)
            {
                throw new Exception("Zadaná nová hesla se neshodují. Zkuste to prosím znovu.");
            }
            else if (noveHeslo.Length < 5)
            {
                throw new Exception("Heslo musí mít alespoň 5 znaků. Zkuste to prosím znovu.");
            }
            else
            {
                return zakaznik;
            }
        }

        public bool jeAdresaJedinecna(Zakaznik zakaznik)
        {
            for (int i = 0; i < seznamZakazniku.Count; i++)
            {
                if (seznamZakazniku[i].Id_zakaznika == zakaznik.Id_zakaznika)
                {
                    continue;
                }
                if (seznamZakazniku[i].Email == zakaznik.Email)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
