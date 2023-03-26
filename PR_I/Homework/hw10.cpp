#include <iostream>

using namespace std;

int main()
{
    int pocetA;

    cout << "Zadejte pocet prvku mnoziny A:" << endl;
    cin >> pocetA;

    if (cin.fail() || pocetA <= 0)
    {
        cout << "Nespravny vstup." << endl;
        return 0;
    }
    else
    {
        int* mnozinaA = new int[pocetA];
        cout << "Zadejte prvky mnoziny A:" << endl;
        for (int i = 0; i < pocetA; i++)
        {
            cin >> mnozinaA[i];

            if (cin.fail())
            {
                cout << "Nespravny vstup." << endl;
                return 0;
            }

            if (i >= 1)
            {
                for (int j = 0; j < i; j++)
                {
                    if (mnozinaA[i] == mnozinaA[j])
                    {
                        cout << "Nespravny vstup." << endl;
                        return 0;
                    }
                }
            }
        }

        int pocetB;

        cout << "Zadejte pocet prvku mnoziny B:" << endl;
        cin >> pocetB;

        if (cin.fail() || pocetB <= 0)
        {
            cout << "Nespravny vstup." << endl;
            return 0;
        }
        else
        {
            int* mnozinaB = new int[pocetB];
            cout << "Zadejte prvky mnoziny B:" << endl;
            for (int i = 0; i < pocetB; i++)
            {
                cin >> mnozinaB[i];

                if (cin.fail())
                {
                    cout << "Nespravny vstup." << endl;
                    return 0;
                }

                if (i >= 1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (mnozinaB[i] == mnozinaB[j])
                        {
                            cout << "Nespravny vstup." << endl;
                            return 0;
                        }
                    }
                }
            }

            cout << "Prunik mnozin:" << endl << "{";

            int pocet = 0;

            for (int i = 0; i < pocetA; i++)
            {
                for (int j = 0; j < pocetB; j++)
                {
                    if (mnozinaA[i] == mnozinaB[j])
                    {
                        if (pocet >= 1)
                        {
                            cout << ", ";
                        }
                        cout << mnozinaA[i];
                        pocet++;
                    }
                }
            }
            cout << "}";
            delete[] mnozinaB;
            mnozinaB = nullptr;
        }
        delete[] mnozinaA;
        mnozinaA = nullptr;
    }
    return 0;
}
