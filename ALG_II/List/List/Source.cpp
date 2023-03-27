#include <iostream>
#include "List.h"

using namespace ADSLibrary::DataStructures::LinkedStructures::Procedural;

int main(void)
{
	SimpleSet simpleset;
	SimpleSet other;
	const int N = 5;
	const int M = 10;
	string p[N] = { "a", "A", "c", "c", "1" };
	string r[M] = { "x", "y", "z", "z", "1", "2", "2", "a", "A", "c" };
	Init(simpleset, p, N);
	Init(other, r, M);

	Report(simpleset);
	Report(other);

	cout << "==========================================" << endl;

	UnionWith(simpleset, other);
	IntersectionWith(simpleset, other);

	cout << endl << "Pocet prvku v mnozine S: " << Count(simpleset) << endl;

	if (IsEmpty(simpleset))
	{
		cout << "Mnozina S je prazdna." << endl;
	}
	else
	{
		cout << "Mnozina S neni prazdna." << endl;
	}

	string x = "a";
	if (Contains(simpleset, x))
	{
		cout << "Mnozina S zahrnuje prvek " << x << endl;
	}
	else
	{
		cout << "Mnozina S nezahrnuje prvek " << x << endl;
	}

	Clear(simpleset);
	if (IsEmpty(simpleset))
	{
		cout << "Mnozina S je prazdna." << endl;
	}
	else
	{
		cout << "Mnozina S neni prazdna." << endl;
	}

	system("pause");
	return(0);
}
