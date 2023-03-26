#include <iostream>

using namespace std;

int main()
{
    cout << "Zadejte hexadecimalni cislo:" << endl;
    string cislo;
    cin >> cislo;
    int ex = 1;
    int vysledek = 0;
    for (int i = cislo.length()-1; i >= 0; --i, ex *= 16)
    {
        if (cislo[i] >= 'a' && cislo[i] <= 'f')
        {
           vysledek += ex * (cislo[i] - 'a' + 10);
        }
        else if (cislo[i] >= 'A' && cislo[i] <= 'F')
        {
            vysledek += ex * (cislo[i] - 'A' + 10);
        }
        else if (cislo[i] >= '0' && cislo[i] <= '9')
        {
            vysledek += ex * (cislo[i] - '0');
        }
        else
        {
            cout << "Nespravny vstup." << endl;
            return 0;
        }
    }
    cout << "Vysledek: " << vysledek << endl;
    return 0;
}
