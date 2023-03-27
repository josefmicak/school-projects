#pragma once

#include <iostream>
#include <iomanip>

using namespace std;

namespace ADSLibrary
{
	namespace DataStructures
	{
		namespace ArrayBasedStructures
		{
			namespace FixedMemory
			{
				namespace OOP
				{
					/**
					* \brief Fronta pevné velikosti implementovaná v poli s využitím %OOP
					*
					* Implementace fronty v poli jako kruhový buffer.
					* Implementace v poli znamená, že ukazatel je v tomto případě realizován jako číslo typu int
					* a ukazatel je tudíž běžný index v poli.
					*
					* @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
					* @date	2010 - 2017
					*/
					class Queue
					{
					public:
						/**
						* Konstruktor.
						*/
						Queue();

						/**
						* Vložení prvku na konec fronty.
						*
						* @param X Vkládaný prvek
						*/
						void Enqueue(const int X);

						/**
						* Vyjmutí prvku z čela fronty.
						*
						* @return Prvek z hlavy fronty
						*/
						int Dequeue();

						/**
						* Prvek na čele fronty.
						* Prvek není z čela fronty odstraněn, jedná se o nedestruktivní variantu metody #Dequeue
						*
						* @return Prvek z hlavy fronty
						*/
						int Peek() const;

						/**
						* Test je-li fronta prázdná.
						*
						* @return Funkce vrací true pokud je fronta prázdná, jinak false.
						*/
						bool IsEmpty() const;

						/**
						* Test je-li fronta plná, tj. nelze vložit další prvek.
						*
						* @return Funkce vrací true pokud je fronta plná, jinak false.
						*/
						bool IsFull() const;

						/**
						* Smazání celého obsahu fronty.
						*/
						void Clear();

						/**
						* Pomocná funkce, která zobrazuje vnitřní strukturu fronty.
						*/
						void Report() const;

					private:
						/**
						* Velikost fronty.
						*/
						static const int QueueSize = 5;

						/**
						* Pole obsahující data uložená do fronty.
						*/
						int Items[QueueSize];

						/**
						* Hlava fronty tj. ukazatel na první prvek fronty v poli {@link #Items}.
						*/
						int Head;

						/**
						* Ocas fronty tj. ukazatel na první volný prvek za koncem fronty v poli {@link #Items}.
						*/
						int Tail;
					};
				}
			}
		}
	}
}
