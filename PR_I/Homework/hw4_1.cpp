#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    double a, b, c, s;
    cout << "Zadejte delky stran trojuhelnika a, b, c:" << endl;
    cin >> a;
    cin >> b;
    cin >> c;
    s = (a + b + c) / 2;
    double S = sqrt(s * (s - a) * (s - b) * (s - c));
    if ((s * (s - a) * (s - b) * (s - c)) <= 0 || a <= 0 || b <= 0 || c <= 0)
    {
        cout << "Nejedna se o platny trojuhelnik." << endl;
    }
    else
    {
        cout << "Obsah trojuhelnika je " << S << endl;
    }

    return 0;
}
