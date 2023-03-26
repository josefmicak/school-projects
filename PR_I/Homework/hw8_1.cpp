#include <iostream>

using namespace std;

int factorial(const int n)
{
    if(n == 0)
    {
        return 1;
    }
    return n * factorial(n - 1);
}

int main()
{
    int n, k, vysledek;
    cout << "Zadejte n a k:" << endl;
    cin >> n >> k;
    if(cin.fail() || k > n || k < 0 || n < 0)
    {
        cout << "Nespravny vstup." << endl;
        return 0;
    }
    vysledek = factorial(n) / (factorial(k) * factorial(n-k));
    cout << "c = " << vysledek << endl;;
    return 0;
}
