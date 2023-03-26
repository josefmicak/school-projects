#include <iostream>
#include <cmath>
#include <iomanip>

#define _USE_MATH_DEFINES

using namespace std;

int main()
{
    double a, b, c, d;
    char obrazec;
    cout << "Zadejte rovinny obrazec, jehoz obsah a obvod chcete spocitat: a - ctverec, b - obdelnik, c - kruh" << endl;
    cin >> obrazec;
    if (obrazec == 'a')
    {
        cout << "Zadejte stranu ctverce:" << endl;
        cin >> a;
        if (cin.good() && a > 0)
        {
            cout << "Obsah ctverce je: " << fixed << setprecision(4) << a*a << endl;
            cout << "Obvod ctverce je: " << fixed << setprecision(4) << 4*a << endl;
        }
        else
        {
            cout << "Nespravny vstup." << endl;
        }
    }
    else if (obrazec == 'b')
    {
        cout << "Zadejte strany obdelniku:" << endl;
        cin >> b >> c;
        if (cin.good() && b > 0 && c > 0)
        {
            cout << "Obsah obdelniku je: " << fixed << setprecision(4) << b*c << endl;
            cout << "Obvod obdelniku je: " << fixed << setprecision(4) << 2*(b+c) << endl;
        }
        else
        {
            cout << "Nespravny vstup." << endl;
        }
    }
    else if (obrazec == 'c')
    {
        cout << "Zadejte polomer kruznice:" << endl;
        cin >> d;
        if (cin.good() && d > 0)
        {
            cout << "Obsah kruznice je: " << fixed << setprecision(4) << M_PI*pow(10, 2) << endl;
            cout << "Obvod kruznice je: " << fixed << setprecision(4) << 2 * M_PI * d << endl;
        }
        else
        {
            cout << "Nespravny vstup." << endl;
        }
    }
    else
    {
        cout << "Nespravny vstup." << endl;
    }
    return 0;
}
