#include <iostream>
#include <ctime>

using namespace std;

void print(int *p, int N)
{
	for (int i = 0; i < N; i++)
	{
		cout << p[i] << "\t";
	}
	cout << endl;
}

//Essential; RLT?
void bubbleSort(int *p, int N)
{
	for (int i = 0; i < N - 1; i++)//Vylepseni oproti i < N pouze rychlostni
	{
		bool terminate = false;

		for (int j = 0; j < N - 1; j++)
		{
			if (p[j] > p[j + 1])
			{
				terminate = false;
				int tmp = p[j];
				p[j] = p[j + 1];
				p[j + 1] = tmp;

				//swap(p[j], p[j + 1]); - Udela to same co 3 radky nad timhle

			}
		}

		if (terminate) break;
	}
}

void selectSort(int *p, int N)
{
	for (int i = 0; i < N - 1; i++)
	{
		int min = i;

		for (int j = i + 1; j < N; j++)
		{
			if (p[j] < p[min])
			{
				min = j;
			}
			swap(p[i], p[min]);
		}
	}
}

int main(void)
{
	int N = 50000;
	int *p = new int[N];

	srand((unsigned int)time(nullptr));

	for (int i = 0; i < N; i++)
	{
		p[i] = rand() % 100;
	}
	time_t start = time(nullptr);
	//print(p, N);
	bubbleSort(p, N);
	//print(p, N);
	time_t end = time(nullptr);

	cout << "Bubble sort time: " << end - start << " s" << endl;//Algoritmus funguje spatne

	//Muj select sort kod (mozna nefunkcni?)
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			if (p[i] < p[j])
			{
				swap(p[i], p[j]);
			}
		}
	}

	for (int i = 0; i < N; i++)
	{
		p[i] = rand() % 100;
	}

	start = time(nullptr);
	//print(p, N);
	selectSort(p, N);
	//print(p, N);
	end = time(nullptr);

	print(p, N);

	cout << "Select sort time: " << end - start << " s" << endl;//Algoritmus funguje spatne

	delete[] p;
	p = nullptr;

	system("pause");
	return(0);
}