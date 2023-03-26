#include <iostream>
#include <cmath>

using namespace std;

int main()
{
    double a, b, c;
    cout << "Zadejte parametry:" << endl;
    cin >> a;
    cin >> b;
    cin >> c;
    double D = b*b - 4*a*c;
    double koren1 = (-b - sqrt(D)) / (2*a);
    double koren2 = (-b + sqrt(D)) / (2*a);
    if (D < 0)
    {
        cout << "Rovnice nema reseni v R." << endl;
    }
    else
    {
        cout << "Koren 1: " << koren1 << endl;
        cout << "Koren 2: " << koren2 << endl;
    }
    return 0;
}
