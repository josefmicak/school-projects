#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    int horniMez, dolniMez, vysledek;
    bool test;
    cout << "Zadejte interval:" << endl;
    cin >> dolniMez >> horniMez;

    if (cin.fail() || horniMez <= dolniMez)
    {
        cout << "Nespravny vstup." << endl;
    }

    while(dolniMez <= horniMez)
    {
        if(dolniMez < 0)
        {
            vysledek = 0;
        }
        else
        {
            vysledek = dolniMez;
        }

        for(int i = 0; i < sqrt(horniMez); i++)
        {
                if( num % i == 0 )
            {
                correct = false;
                break;
            }
        }
    }
    return 0;
}
