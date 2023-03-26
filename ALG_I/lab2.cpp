#include <iostream>

using namespace std;
/*
//Predavani hodnotou
void calc(int a)
{
	cout << a << endl;
}*/

//Predavani referenci
void calc(int &a)
{
	//a = 10;
	cout << a << endl;
}
/*
//Predavani pointerem
void calc(int *p)
{
	cout << *p << endl;
	//cout << &p << endl;
}*/
/*
//Kombo
void calc(int *&p)
{
	//cout << p << endl;
	cout << &p << endl;
}
*/

int main(void)
{
	int a = 5;
	//int *p = nullptr;
	int *p = &a;
	int **q = &p;
	//cout << "*q" << *q << endl;

	//cout << a << endl;//= &a
	//cout << *p << endl;
	//cout << **q << endl;
	cout << *&**&*&*q << endl << endl;// = a; nau�it 
	cout << "p = &a = " << &a << endl;
	cout << "q = &p = " << &p << endl << endl;
	cout << "q - " << q << endl;
	cout << "*q - " << *q << endl;
	cout << "&*q - " << &*q << endl;
	cout << "*&*q - " << *&*q << endl;
	cout << "&*&*q - " << &*&*q << endl;
	cout << "*&*&*q - " << *&*&*q << endl;
	cout << "**&*&*q - " << **&*&*q << endl;
	cout << "&**&*&*q - " << &**&*&*q << endl;
	cout << "*&**&*&*q - " << *&**&*&*q << endl;
	cout << q << &*q << endl;
//	cout << "*&p" << *&p << "&a" << &a << endl;

	calc(a);//referenci
	//calc(p);//pointerem

	//cout << a << endl;
//	cout << p << endl;
	//cout << *p << endl;

	system("pause");
	return(0);
}