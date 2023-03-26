#pragma once

namespace ADSLibrary
{
	namespace DataStructures
	{
		namespace LinkedStructures
		{
			namespace OOPTemplate
			{
				/**
				 * \brief Fronta implementovaná pomocí spojových struktur jako šablona (template) %OOP.
				 *
				 * @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
				 * @date	2010 - 2017
				 */
				template <class T>
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
					void Enqueue(const T X);

					/**
					 * Odebrání prvku z čela fronty.
					 *
					 * @return Prvek z čela fronty
					 */
					T Dequeue();

					/**
					 * Prvek na čele fronty.
					 * Prvek není z čela fronty odstraněn, jedná se o nedestruktivní variantu metody #Dequeue
					 *
					 * @return Prvek z čela fronty
					 */
					T Peek() const;

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
						T Value;
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


				template<class T> Queue<T>::Queue()
				{
					this->Head = nullptr;
					this->Tail = nullptr;
				}

				template<class T> Queue<T>::~Queue()
				{
					this->Clear();
				}

				template<class T> void Queue<T>::Enqueue(const T X)
				{
					QueueItem* n = new QueueItem();
					n->Value = X;
					n->Prev = nullptr;
					if (this->IsEmpty())
					{
						this->Head = n;
					}
					else
					{
						this->Tail->Prev = n;
					}
					this->Tail = n;
				}

				template<class T> T Queue<T>::Dequeue()
				{
					QueueItem* d = this->Head;
					T result = d->Value;
					this->Head = this->Head->Prev;
					if (this->IsEmpty())
					{
						this->Tail = nullptr;
					}
					delete d;
					return result;
				}

				template<class T> T Queue<T>::Peek() const
				{
					return this->Head->Value;
				}

				template<class T> bool Queue<T>::IsEmpty() const
				{
					return this->Head == nullptr;
				}

				template<class T> void Queue<T>::Clear()
				{
					while (!this->IsEmpty())
					{
						this->Dequeue();
					}
				}
			}
		}
	}
}
