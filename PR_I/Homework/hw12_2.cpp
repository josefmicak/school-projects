#include <iostream>

using namespace std;

struct Zaznamy
{
    string prijmeni;
    string jmeno;
    int rodneCislo;
    string diagnoza;
    int pojistovna;
};

void vypisPrijmeni(Zaznamy Pacient[])
{
    cout << "Prijmeni vsech pacientu jsou:" << endl;
    for (int i = 0; i < 5; i++)
    {
        cout << Pacient[i].prijmeni << endl;
    }
}

int main()
{
    Zaznamy Pacient[5];

    for (int i = 0; i < 5; i++)
    {
        cout << "Zadejte prijmeni, jmeno, rodne cislo, nemoc a zdravotni pojistovnu pacienta:" << endl;
        cin.clear();
        fflush(stdin);
        cin >> Pacient[i].prijmeni >> Pacient[i].jmeno >> Pacient[i].rodneCislo >> Pacient[i].diagnoza >> Pacient[i].pojistovna;
        cout<<Pacient[i].diagnoza<<endl;
    }

    for (int i = 0; i < 5; i++)
    {
        if (Pacient[i].diagnoza == "tbc")
        {
            cout << "Jmeno a prijmeni pacienta s tbc:" << endl;
            cout << Pacient[i].jmeno << " " << Pacient[i].prijmeni << endl;
        }

        if (Pacient[i].pojistovna == 211)
        {
            cout << "Jmeno a prijmeni pacientu s pojistovnou 211 je:" << endl;
            cout << Pacient[i].jmeno << " " << Pacient[i].prijmeni << endl;
        }
    }

    vypisPrijmeni(Pacient);

    return 0;
}
