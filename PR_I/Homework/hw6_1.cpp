#include <iostream>

using namespace std;

int main()
{
    double x = 0;
    double vysledek = 0;
    cout << "Zadavejte cisla, posledni bude 1000:" << endl;
  //  cin >> x;
    while (x != 1000)
    {
        cin >> x;
        if (x == 1000)
        {
            break;
        }
        vysledek += x;
        x = 0;
    //    continue;
    }
    cout << "Vysledek souctu cisel je: " << (vysledek + 1000) << endl;
    return 0;
}
