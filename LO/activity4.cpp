#include <iostream>

using namespace std;

int main()
{
    string cislo;
    cout<<"Zadejte cislo"<<endl;
    cin>>cislo;
    int pocetJ = 0;
    for (int i = 0; i < cislo.length(); i++)
    {
        if (cislo[i] == '1')
        {
            pocetJ++;
        }
    }
    cout << pocetJ << endl;

    switch(pocetJ % 2)
    {
        case 0:
            cout << "Sudy pocet jednicek." << endl;
            break;
        default:
            cout << "Lichy pocet jednicek." << endl;
            break;
    }

    return 0;
}
