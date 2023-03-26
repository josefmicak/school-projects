#include <iostream>

using namespace std;

int main()
{
    double cislo;
    char x;
    cout << "Zadejte cislo:" << endl;
    cin >> cislo;
    x = cin.peek();

    if (x == '\n')
    {
        cout << cislo << " : Spravne zadane cislo." << endl;
    }
    else
    {
        cout << "Chybne zadani." << endl;
    }
    return 0;
}
