#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    int x, y, z;
    cout << "Zadejte prvni cislo:" << endl
    cin >> x;
    cout << "Zadejte druhe cislo:" << endl;
    cin >> y;
    cout << "Zadejte treti cislo:" << endl;
    cin >> z;
    int soucet = x + y + z;
    int rozdil = x - y - z;
    int soucin = x * y * z;
    cout << "Soucet je:" << endl << soucet << endl;
    cout << "Soucin je:" << endl << soucin << endl;
    cout << "Rozdil je:" << endl << rozdil << endl;
    return 0;
}
