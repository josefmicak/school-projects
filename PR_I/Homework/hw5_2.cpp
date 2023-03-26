#include <iostream>

using namespace std;

int main()
{
    int pocetschodu;
    cout << "Zadejte pocet schodu:" << endl;
    cin >> pocetschodu;
    if (cin.fail() || pocetschodu < 0)
    {
        cout << "Nespravny vstup." << endl;
    }
    else
    {
        for (int i = 0; i < pocetschodu; i++)
        {
            for (int j = 0; j < i; j++)
            {
                cout << "X";
            }
            cout << "_" << endl;
        }
    }
  /*  for (int i = 0; i < pocetschodu; i++)
    {

        for (int j = 0; j < i; j++)
        {
            cout << "X";
        }
        cout << "_" << endl;
    }*/
    return 0;
}
