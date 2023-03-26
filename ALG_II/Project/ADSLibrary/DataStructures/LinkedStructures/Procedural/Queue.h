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
			namespace Procedural
			{
				/**
				 * \brief Struktura reprezentující položku ve frontě {@link #ADSLibrary::DataStructures::LinkedStructures::Procedural::Queue}
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
				 * \brief Fronta implementovaná pomocí spojových struktur procedurálním způsobem.
				 *
				 * @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
				 * @date	2010 - 2017
				 */
				struct Queue
				{
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