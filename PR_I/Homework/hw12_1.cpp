#include <iostream>

using namespace std;

struct Knihovna
{
    string nazev;
    string prijmeni;
    string jmeno;
    string zanr;
    int rok;
    int cena;
    int id;
};

void vypisRomanu(Knihovna Kniha[])
{
    cout << "Romany jsou:" << endl;
    for (int i = 0; i < 5; i++)
    {
        if (Kniha[i].zanr == "roman")
        {
            cout << Kniha[i].nazev << endl;
        }
    }
    cout << endl;
}

void vypisLevnych(Knihovna Kniha[])
{
    cout << "Knihy s cenou mensi nez 300,- Kc jsou:" << endl;
    for (int i = 0; i < 5; i++)
    {
        if (Kniha[i].cena < 300)
        {
            cout << Kniha[i].nazev << endl;
        }
    }
    cout << endl;
}

void vypisPrijmeni(Knihovna Kniha[])
{
    cout << "Prijmeni vsech autoru jsou:" << endl;
    for (int i = 0; i < 5; i++)
    {
        cout << Kniha[i].prijmeni << endl;
    }
}

int main()
{
    Knihovna Kniha[5];

    for (int i = 0; i < 5; i++)
    {
        cout << "Zadej nazev knihy, prijmeni autora, jmeno autora, zanr knihy, rok vydani, cenu a id:" << endl;
        cin >> Kniha[i].nazev >> Kniha[i].prijmeni >> Kniha[i].jmeno >> Kniha[i].zanr >> Kniha[i].rok >> Kniha[i].cena >> Kniha[i].id;
    }

    vypisRomanu(Kniha);
    vypisLevnych(Kniha);
    vypisPrijmeni(Kniha);

    return 0;
}
