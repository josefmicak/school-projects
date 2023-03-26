#include <iostream>

using namespace std;

int main(void)
{
	/*
	const int N = 5;
	int p[N];

	cout << sizeof(p) << endl;
	cout << &p << endl;
	cout << p << endl;
	*/

	/*
	int N = 10000000;
	int *p = new int[N];

	for (int i = 0; i < N; i++)
	{
		p[i] = i * i;
	}

	/*
	for (int i = 0; i < N; i++)
	{
		cout << p[i] << endl;
	}*/

	/*
	//Dvouroz. pole; naho�e jednoroz.
	int rows = 5;
	int cols = 4;

	int **p = new int *[rows];//Dynamicky alokuju pole pointeru na int
	for (int i = 0; i < rows; i++)
	{
		p[i] = new int[cols];
	}
	
	//pole(6)
	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			p[i][j] = 0;
		}
	}

	p[1][3] = 128;

	for (int i = 0; i < rows; i++)
	{
		for (int j = 0; j < cols; j++)
		{
			cout << p[i][j] << "\t";
		}
		cout << endl;
	}

	//Dealokace
	for (int i = 0; i < rows; i++)
	{
		delete[] p[i];
	}

	delete[] p;
	p = nullptr; = same nuly
	//p = NULL;
	//p = 0;//Tyto 2 radky stejne jako nullptr

	*/

	int rows = 5;
	int cols = 5;
	int **p;

	void allocate(int** &p, int rows, int cols)
	{
		p = new int*[rows];
	}

	void initialize(int** &p, int rows, int cols)
	{
		for (int i = 0; i < rows; i++)
		{
			for (int j = 0; j < cols; j++)
			{
				p[i][j] = 0;
			}
		}
	}

	void print()
	{

	}

	void deallocate()
	{

	}

	allocate(p, rows, cols);
	initialize(p, rows, cols);

	print(p, rows, cols);
	deallocate(p, rows);

	system("pause");
	return(0);
}