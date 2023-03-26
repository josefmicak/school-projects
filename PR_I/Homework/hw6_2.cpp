#include <iostream>
#include <cmath>

using namespace std;

int main()
{
	cout << "Zadej cislo ve dvojkove soustave:" << endl;

	//Kontrola vstupu
	string retezec;
	char znak;

	while ((znak = cin.get()) != '\n')
	{
		if (znak == '0' || znak == '1')
		{
			retezec += znak;
		}
        else
		{
			cout << "Nespravny vstup." << endl;
			return 0;
		}
	}

    if(retezec == "")
    {
        cout << "Nespravny vstup." << endl;
        return 0;
    }

	int vysledek = 0;
	int i = retezec.length() - 1;

	while (i >= 0)
	{
		vysledek += (retezec[retezec.length() -1 - i] - '0') * pow(2, i);
		i--;
	}

	cout << "Desitkove cislo je: " << vysledek << endl;
	return 0;
}
