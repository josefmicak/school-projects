#include <iostream>

using namespace std;

/*
for (int i = 0; i < 32; i++)
{
cout << ((a >> i) & 1);
}
*/

int main(void)
{
	int a = 172;
	int N = 7;
	unsigned int intSize = sizeof(int) * 8;
	cout << (a | (1 << (N - 1))) << endl;//Nahrazeni 7. bitu v cisle 172; vysl. 236

	//Vypis binarniho zapisu cisla
	for (int i = 31; i >= 0; i--)//int i = intSize - 1
	{
		cout << ((a >> i) & 1);//otoceni cyklu
	}

	cout << endl;

	if (0.15)
	{
		cout << "Cisla jsou automaticky true" << endl;
	}

	cout << ~4 << "+" << !!4 << endl;

	//Resetovani bitu
	N = 6;
	cout << (a & ~(1 << (N - 1))) << endl;//Resetovani 6. bitu v cisle 172; vysl. 140

	N = 7;
	//Umi prepnout z 0 na 1 i z 1 na 0
	cout << (a ^ (1 << (N - 1))) << endl;//Prepnuti 7. bitu v cisle 140; vysl 236(spatne, asi souvisi s predchozimi vypocty

	int xx = 172;

	cout << (xx ^ (1 << (8 - 1))) << endl;

	cout << (0 & 1) << (2 & 1) << endl;
	cout << (3 & 1) << endl;

	system("pause");
	return (0);
}