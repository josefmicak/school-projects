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
			namespace DynamicMemory
			{
				namespace OOPTemplate
				{
					/**
					* \brief Fronta implementovaná v poli jako šablona (template) %OOP
					*
					* Implementace fronty v poli jako kruhový buffer.
					* Implementace v poli znamená, že ukazatel je v tomto případě realizován jako číslo typu int
					* a ukazatel je tudíž běžný index v poli.
					* Velikost fronty lze specifikovat v konstruktoru.
					*
					* @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
					* @date	2010 - 2017
					*/
					template <class T>
					class Queue
					{
					public:
						/**
						* Konstruktor. Velikost fronty bude nastavena na výchozí velikost.
						*/
						Queue();

						/**
						* Konstruktor
						*
						* @param QueueSize Velikost fronty
						*/
						Queue(const int QueueSize);

						/**
						* Destruktor.
						*/
						~Queue();

						/**
						* Vložení prvku na konec fronty.
						*
						* @param X Vkládaný prvek
						*/
						void Enqueue(const T X);

						/**
						* Vyjmutí prvku z čela fronty.
						*
						* @return Prvek z hlavy fronty
						*/
						T Dequeue();

						/**
						* Prvek na čele fronty.
						* Prvek není z čela fronty odstraněn, jedná se o nedestruktivní variantu metody #Dequeue
						*
						* @return Prvek z hlavy fronty
						*/
						T Peek() const;

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

					private:
						/**
						* Výchozí (default) velikost fronty.
						*/
						const int DefaultQueueSize = 100;

						/**
						* Velikost fronty.
						*/
						int QueueSize;

						/**
						* Pole obsahující data uložená do fronty.
						*/
						T* Items;

						/**
						* Hlava fronty tj. ukazatel na první prvek fronty v poli {@link #Items}.
						*/
						int Head;

						/**
						* Ocas fronty tj. ukazatel na první volný prvek za koncem fronty v poli {@link #Items}.
						*/
						int Tail;
					};


					template<class T> Queue<T>::Queue()
					{
						this->QueueSize = this->DefaultQueueSize;
						this->Items = new T[this->DefaultQueueSize];
						this->Head = 0;
						this->Tail = 0;
					}

					template<class T> Queue<T>::Queue(const int QueueSize)
					{
						if (QueueSize <= 0)
						{
							this->QueueSize = this->DefaultQueueSize;
						}
						else
						{
							this->QueueSize = QueueSize;
						}
						this->Items = new T[this->QueueSize];
						this->Head = 0;
						this->Tail = 0;
					}

					template<class T> Queue<T>::~Queue()
					{
						delete[] this->Items;
					}

					template<class T> void Queue<T>::Enqueue(const T X)
					{
						this->Items[this->Tail] = X;
						this->Tail = (this->Tail + 1) % this->QueueSize;
					}

					template<class T> T Queue<T>::Dequeue()
					{
						T x = this->Items[this->Head];
						this->Head = (this->Head + 1) % this->QueueSize;
						return x;
					}

					template<class T> T Queue<T>::Peek() const
					{
						return this->Items[this->Head];
					}

					template<class T> bool Queue<T>::IsEmpty() const
					{
						return this->Head == this->Tail;
					}

					template<class T> bool Queue<T>::IsFull() const
					{
						return this->Head == (this->Tail + 1) % this->QueueSize;
					}

					template<class T> void Queue<T>::Clear()
					{
						this->Head = 0;
						this->Tail = 0;
					}
				}
			}
		}
	}
}
