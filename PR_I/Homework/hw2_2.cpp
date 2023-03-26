#include <iostream>

using namespace std;

int main()
{
    string name;
    int number;
    const int x = 3;
    cout << "Zadej svoje jmeno (bez diakritiky): ";
    getline(cin, name);
    cout << "Zadej cele cislo: ";
    cin >> number;
    cout << "Ahoj, " << name << "." << endl;
    int prvni = (number*x);
    int druhe = (number/x);
    cout << number << " x 3 = " << prvni << endl;
    cout << number << " / 3 = " << druhe << endl;
    return 0;
}
