#include <iostream>

using namespace std;

int main()
{
    string binary1, binary2;
    char znak;

    cout << "Zadejte dve binarni cisla:" << endl;

    //Rozdeleni vstupu na 2 stringy
    while((znak = cin.get()) != ' ')
    {
        binary1 += znak;
    }

    while((znak = cin.get()) != '\n')
    {
        binary2 += znak;
    }

    //Kontrola spravnosti vstupu
    for (int ch1 = 0; ch1 < binary1.length(); ch1++)
    {
        if (binary1[ch1] > '1' || binary1[ch1] < '0')
        {
            cout << "Nespravny vstup." << endl;
            return 0;
        }
    }

    for (int ch2 = 0; ch2 < binary2.length(); ch2++)
    {
        if (binary2[ch2] > '1' || binary2[ch2] < '0')
        {
            cout << "Nespravny vstup." << endl;
            return 0;
        }
    }

    int a1 = binary1.length();
    int b1 = binary2.length();

    if (b1 > a1)
    {
        string c = binary1;
        binary1 = binary2;
        a1 = b1;
        binary2 = c;
        b1 = binary2.length();
    }

    string d;
    int z = 0;
    for (int i = 0; i < a1; i++)
    {
        if (b1 - 1 - i >= 0)
        {
            int c = (binary1[a1 - 1 - i] - '0') + (binary2[b1 - 1 - i] - '0') + z;
            if (c == 3)
            {
                c = 1;
                z = 1;
            }
            else if (c == 2)
            {
                c = 0;
                z = 1;
            }
            else
            {
                z = 0;
            }
            if (c == 0)
            {
                d = '0' + d;
            }
            else
            {
                d = '1' + d;
            }
        }
        else
        {
            int c = (binary1[a1 - 1 - i] - '0') + z;
            if (c == 2)
            {
                c = 0;
                z = 1;
            }
            else
            {
                z = 0;
            }
            if (c == 0)
            {
                d = '0' + d;
            }
            else
            {
                d = '1' + d;
            }
        }
    }
    if (z == 1)
    {
        d = '1' + d;
    }
    cout << "Soucet: " << d << endl;

    return 0;
}
