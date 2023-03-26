#include <iostream>

using namespace std;

unsigned long long int fac(unsigned int n)
{
	if (n > 20)
	{
		cout << "wrong n!" << endl;
		return(0);
	}
	if (n <= 1)
		return(1);

	return(n * fac(n - 1));
}

/*
int sum(int *p, int N, int i)
{
	//na zacatku je ukoncovaci podminka
	if (i >= N)
	{
		return(0);
	}

	return(p[i] + sum(p, N, i + 1));
}
*/

//Vylepseni
int sum(int *p, int N)
{
	//na zacatku je ukoncovaci podminka
	if (N <= 0)
	{
		return(0);
	}

	return(p[N - 1] + sum(p, N - 1));
}

bool findElement(int *p, int N, int v)
{
	int l = 0;
	int r = N - 1;
	int M;

	while(l <= r)
	{
		M = (l + r) / 2;

		if (v == p[M])
		{
			return true;
		}

		if (v < p[M]) r = M - 1;
		if (v > p[M]) l = M + 1;
	}

	return false;
}

/*
bool findElement_rec(int *p, int N, int v, int l, int r)
{
	if (r < l)
	{
		return false;
	}

	int M = (l + r) / 2;

	if (v == p[M])
	{
		return true;
	}

	if (v < p[M]) return(findElement_rec(p, N, v, l, M - 1));
	if (v > p[M]) return(findElement_rec(p, N, v, M + 1, r));
}
*/

//Vylepseni - vypusteni velikosti N
bool findElement_rec(int *p, int v, int l, int r)
{
	if (r < l)
	{
		return false;
	}

	int M = (l + r) / 2;

	if (v == p[M])
	{
		return true;
	}

	if (v < p[M]) return(findElement_rec(p, v, l, M - 1));
	if (v > p[M]) return(findElement_rec(p, v, M + 1, r));
}

bool findElement_rec(int *p, int N, int v)
{
	return(findElement_rec(p, v, 0, N - 1));
}

int main(void)
{
	//int n = 5;
	unsigned int N = 8;

	int result = 1;

/*	for (int i = 2; i <= n; i++)//i muze byt cokoli
	{
		result *= i;
	}*/

	/*cout << result << endl;
	cout << fac(n) << endl;*/

	int *p = new int[N];

	for (int i = 0; i < N; i++)
	{
		p[i] = i;
	}

	//cout << sum(p, N, 0) << endl;

	cout << sum(p, N) << endl;

	int v = 5;// = 1; 13 = 0

	cout << findElement(p, N, v) << endl;

	//cout << findElement_rec(p, N, v, 0, N - 1) << endl;

	cout << findElement_rec(p, v, 0, N - 1) << endl;
	cout << findElement_rec(p, N, v) << endl;//Pretizeni funkce
	//Pozna se podle toho, kolik argumentu posilam (kdyz 4, vykona se 1., kdyz 3, vykona se 2.)

	system("pause");
	return(0);
}