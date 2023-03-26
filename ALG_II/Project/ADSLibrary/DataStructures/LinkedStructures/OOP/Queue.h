#pragma once

#include <iostream>
#include <iomanip>

using namespace std;

namespace ADSLibrary
{
	namespace DataStructures
	{
		namespace LinkedStructures
		{
			namespace OOP
			{
				/**
				* \brief Fronta implementovaná pomocí spojových struktur s využitím %OOP.
				*
				* @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
				* @date	2010 - 2017
				*/
				class Queue
				{
				public:
					/**
					* Konstruktor
					*/
					Queue();

					/**
					* Destuktor
					*/
					~Queue();

					/**
					* Vložení prvku na konec fronty.
					*
					* @param X Vkládaný prvek
					*/
					void Enqueue(const int X);

					/**
					* Odebrání prvku z čela fronty.
					*
					* @return Prvek z čela fronty
					*/
					int Dequeue();

					/**
					* Prvek na čele fronty.
					* Prvek není z čela fronty odstraněn, jedná se o nedestruktivní variantu metody #Dequeue
					*
					* @return Prvek z čela fronty
					*/
					int Peek() const;

					/**
					* Test, je-li fronta prázdná.
					*
					* @return Funkce vrací true pokud je fronta prázdná, jinak false.
					*/
					bool IsEmpty() const;

					/**
					* Smazání celého obsahu fronty.
					*
					*/
					void Clear();

				private:
					/**
					* \brief Struktura reprezentující položku ve frontě.
					*/
					struct QueueItem
					{
						/**
						* Hodnota obsažená v položce.
						*/
						int Value;
						/**
						* Ukazatel na předchozí položku. Pokud taková položka neexistuje ukazatel má hodnotu nullptr.
						*/
						QueueItem* Prev;
					};

					/**
					* Hlava fronty. Hlava fronty ukazuje na první prvek fronty.
					* První prvek fronty nazýváme také čelo fronty.
					*/
					QueueItem* Head;

					/**
					* Ocas fronty. Tento ukazatel běžně ukazuje na poslední prvek ve frontě.
					*/
					QueueItem* Tail;
				};
			}
		}
	}
}
