#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    double Ax, Ay, Bx, By;
    cout << "Zadejte souradnice bodu A a B:" << endl;
    cin >> Ax;
    cin >> Ay;
    cin >> Bx;
    cin >> By;
    double Sx = (Ax + Bx) / 2;
    double Sy = (Ay + By) / 2;
    double vektor = sqrt((Bx - Ax) * (Bx - Ax) + (By - Ay) * (By - Ay));
    double polomer = vektor / 2;
    cout << "X-ova souradnice stredu S je: " << Sx << endl;
    cout << "Y-ova souradnice stredu S je: " << Sy << endl;
    cout << "Smerovy vektor u ma delku: " << vektor << endl;
    cout << "Polomer kruznice r ma hodnotu: " << polomer << endl;
    return 0;
}
