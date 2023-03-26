#pragma once

namespace ADSLibrary
{
	namespace DataStructures
	{
		namespace ArrayBasedStructures
		{
			namespace FixedMemory
			{
				namespace OOPTemplate
				{
					/**
					* \brief Zásobník pevné velikosti implementovaný v poli jako šablona (template) %OOP
					*
					* @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
					* @date	2010 - 2017
					*/
					template <class T>
					class Stack
					{
					public:
						/**
						* Konstruktor.
						*/
						Stack();

						/**
						* Vložení prvku na vrchol zásobníku.
						*
						* @param X Vkládaný prvek
						*/
						void Push(const T X);

						/**
						* Odebrání prvku z vrcholu zásobníku.
						*
						* @return Prvek z vrcholu zásobníku
						*/
						T Pop();

						/**
						* Prvek na vrcholu zásobníku.
						* Prvek není ze zásobníku odstraněn, jedná se tedy o nedestruktivní variantu funkce #Pop.
						*
						* @return Prvek z vrcholu zásobníku
						*/
						T Top() const;

						/**
						* Test, je-li zásobník prázdný.
						*
						* @return Funkce vrací true pokud je zásobník prázdný, jinak false.
						*/
						bool IsEmpty() const;

						/**
						* Test, je-li zásobník zaplněný.
						*
						* @return Funkce vrací true pokud je zásobník zaplněný, jinak false.
						*/
						bool IsFull() const;

						/**
						* Smazání celého obsahu zásobníku.
						*/
						void Clear();

					private:
						/**
						* Velikost zásobníku.
						*/
						static const int StackSize = 100;

						/**
						* Pole obsahující data uložená do zásobníku.
						*/
						T Items[StackSize];

						/**
						* Ukazatel zásobníku.
						*/
						int StackPointer;
					};

					template <class T> Stack<T>::Stack()
					{
						this->StackPointer = 0;
					}

					template <class T> void Stack<T>::Push(const T X)
					{
						this->Items[this->StackPointer] = X;
						this->StackPointer += 1;
					}

					template <class T> T Stack<T>::Pop()
					{
						this->StackPointer -= 1;
						return this->Items[this->StackPointer];
					}

					template <class T> T Stack<T>::Top() const
					{
						return this->Items[this->StackPointer - 1];
					}

					template <class T> bool Stack<T>::IsEmpty() const
					{
						return this->StackPointer == 0;
					}

					template <class T> bool Stack<T>::IsFull() const
					{
						return this->StackPointer >= this->StackSize;
					}

					template <class T> void Stack<T>::Clear()
					{
						this->StackPointer = 0;
					}
				}
			}
		}
	}
}
