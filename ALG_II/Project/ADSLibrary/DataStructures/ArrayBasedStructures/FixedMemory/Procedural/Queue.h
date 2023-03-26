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
				namespace Procedural
				{
					/**
					* \brief Velikost kruhového bufferu ve kterém je fronta implementována.
					*/
					const int CircularBufferSize = 5;

					/**
					* \brief Maximální velikost fronty.
					*/
					const int MaxQueueSize = CircularBufferSize - 1;

					/**
					* \brief Fronta pevné velikosti implementovaná v poli jako kruhový buffer
					*
					* Implementace fronty v poli.
					* Implementace v poli znamená, že ukazatel je v tomto případě realizován jako číslo typu int
					* a ukazatel je tudíž běžný index v poli.
					*
					* @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
					* @date	2010 - 2017
					*/
					struct Queue
					{
						/**
						* Pole, kruhový buffer, obsahující data uložená do fronty.
						*/
						int Items[CircularBufferSize];
						/**
						* Hlava fronty. Hlava fronty ukazuje na první prvek fronty.
						* První prvek fronty nazýváme také čelo fronty.
						*/
						int Head;
						/**
						* Ocas fronty. Tento ukazatel běžně ukazuje na poslední prvek ve frontě.
						* Při implementaci pomocí kruhového bufferu v poli, je výhodnější, aby tento
						* ukazatel ukazoval až za poslední prvek ve frontě. Ocas fronty bude tak ukazovat
						* na první volný prvek v poli {@link #Items}.
						*/
						int Tail;
					};

					/**
					* Inicializace fronty.
					*
					* @param Q Inicializovaná fronta
					*/
					void Init(Queue& Q);

					/**
					* Vložení prvku na konec fronty.
					*
					* @param Q Fronta
					* @param X Vkládaný prvek
					*/
					void Enqueue(Queue& Q, const int X);

					/**
					* Odebrání prvku z čela fronty.
					*
					* @param Q Fronta
					* @return Prvek z čela fronty
					*/
					int Dequeue(Queue& Q);

					/**
					* Prvek na čele fronty.
					* Prvek není z čela fronty odstraněn, jedná se o nedestruktivní variantu metody #Dequeue
					*
					* @param Q Fronta
					* @return Prvek z čela fronty
					*/
					int Peek(const Queue& Q);

					/**
					* Test, je-li fronta prázdná.
					*
					* @param Q Fronta
					* @return Funkce vrací true pokud je fronta prázdná, jinak false.
					*/
					bool IsEmpty(const Queue& Q);

					/**
					* Test, je-li fronta plná, tj. nelze vložit další prvek.
					*
					* @param Q Fronta
					* @return Funkce vrací true pokud je fronta plná, jinak false.
					*/
					bool IsFull(const Queue& Q);

					/**
					* Smazání celého obsahu fronty.
					*
					* @param Q Fronta
					*/
					void Clear(Queue& Q);

					/**
					* Pomocná funkce, která zobrazuje vnitřní strukturu fronty.
					*
					* @param Q Fronta
					*/
					void Report(const Queue& Q);
				}
			}
		}
	}
}
