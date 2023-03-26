#include <iostream>

using namespace std;

int main()
{
    double a, b;
    cout << "Zadej 1. cislo:" << endl;
    cin >> a;
    cout << "Zadej 2. cislo:" << endl;
    cin >> b;
    cout << "Zadali jste:" << endl << a << " a " << b << endl;
    cout << a << " + " << b << " = " << (a+b) << endl;
    cout << a << " - " << b << " = " << (a-b) << endl;
    cout << a << " * " << b << " = " << (a*b) << endl;
    cout << a << " / " << b << " = " << (a/b) << endl;
    return 0;
}
