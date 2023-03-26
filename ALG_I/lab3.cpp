#include <iostream>

using namespace std;

int main(void)
{
	const int N = 5;
	//int p[N];
	/*
	p[3] = 4;
	p[0] = 15;
	p[1] = 15;
	cout << p << endl;//Ukaze adresu prvniho prvku
	cout << *p << endl;//Ukaze prvni prvek
	cout << &p << endl;
	cout << &p[0] << " = " << p << endl;
	cout << &p[1] << endl;//Podobna adresa
	cout << *(p + 1) << endl;
	*/
	const int rows = 5;
	const int cols = 4;
	int p[rows][cols];

	int count = 0;

	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
		//	p[i][j] = 0;
		//	p[i][j] = count++;//ne ++count !
			p[i][j] = j + i * cols;//druhy postup, tzn. bez promenne; muzu z jednorozmerneho do dvojrozmerneho(?)
		}
	}

	p[4][1] = 6;

	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			cout << p[i][j] << "\t";
		}
	}

	for (int i = 0; i < N; i++)
	{
		p[i] = i + 1;
		cout << p[i] << endl;
	}

	system("pause");
	return(0);
}