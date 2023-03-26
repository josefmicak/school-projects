#include <iostream>
#include <ctime>

using namespace std;

int main(void)
{
	srand(time(0));//zajisti nahodne hodnoty v rand, seed rand, pokud progam nespustime vickrat za sekundu tak budou hodnoty stejne
	//jsou to sekundy uplnyul� od 1.1.1970

	int N = 7;
	int R = 10;
	int *p = new int[N];
	bool *used = new bool[R];

	for (int i = 0; i < R; i++)
	{
		used[i] = false;
	}
	
	for (int i = 0; i < N; i++)
	{
	//	p[i] = i * i;
		int n = rand() % R;

		if (!used[n])
		{
			p[i] = n;
			used[n] = true;
		}
		else
		{
			i--;
		}
	//	p[i] = rand() % R;// + 5; to za rand mi rekne jak unikatni hodnoty chci, + rika od jake hodnoty chci zacit
	}

	for (int i = 0; i < N; i++)
	{
	//	cout << p[i] << "\t";
	}
	
	cout << endl;

	/*
	//Algoritmus proti duplicitam
	for (int i = 0; i < N; i++)
	{
		p[i] = rand() % 10;// + 5; to za rand mi rekne jak unikatni hodnoty chci, + rika od jake hodnoty chci zacit
		for (int j = 0; j < i; j++)
		{
			if (p[i] == p[j])
			{
				i--;
				break;//pripsano, ale nemusi tam byt
			}
		}
	}*/


	for (int i = 0; i < N; i++)
	{
		cout << p[i] << "\t";
	}

	cout << endl;

	int v = 8;

	//Sekvencni (linearni) vyhledavani v poli
//	bool found = false; (dalsi moznost)
	{//tyhle zavorky zpusobi ze i existuje pouze zde
		int i;
		for (i = 0; i < N; i++)
		{
			if (p[i] == v)
			{
				break;
			}
		}

		if (i < N)
		{
		//	cout << "nalezeno" << endl;
		}
		else
		{
		//	cout << "nenalezeno" << endl;
		}
	}

	int l = 0;
	int r = N - 1;//posledni index o 1 mensi
	int M;//middle

	while (l <= r)
	{
		M = (l + r) / 2;

		if (p[M] == v)
		{
			cout << "nalezeno" << endl;
			break;
		}

		if (v < p[M]) r = M - 1;
		if (v > p[M]) l = M + 1;
	}

	delete[] p;
	p = nullptr;

	delete[]used;
	used = nullptr;

	system("pause");
	return (0);
}