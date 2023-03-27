#pragma once

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
					* \brief Zásobník implementovaný v poli jako šablona (template) %OOP.
					*
					* Velikost zásobníku lze specifikovat v konstruktoru.
					*
					* @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
					* @date	2010 - 2017
					*/
					template <class T>
					class Stack
					{
					public:
						/**
						* Konstruktor. Velikost zásobníku bude nastavena na výchozí velikost.
						*/
						Stack();

						/**
						* Konstruktor. Velikost zásobníku lze zvolit.
						*
						* @param StackSize Velikost zásobníku
						*/
						Stack(const int StackSize);

						/**
						* Destruktor
						*/
						~Stack();

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
						* Test je-li zásobník prázdný.
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
						* Výchozí (default) velikost zásobníku.
						*/
						static const int DefaultStackSize = 100;

						/**
						* Velikost zásobníku.
						*/
						int StackSize;

						/**
						* Pole obsahující data uložená do zásobníku.
						*/
						T* Items;

						/**
						* Ukazatel zásobníku.
						*/
						int StackPointer;
					};


					template <class T> Stack<T>::Stack()
					{
						this->StackSize = DefaultStackSize;
						this->Items = new T[DefaultStackSize];
						this->StackPointer = 0;
					}

					template <class T> Stack<T>::Stack(const int StackSize)
					{
						this->StackSize = StackSize <= 0 ? DefaultStackSize : StackSize;
						this->Items = new T[this->StackSize];
						this->StackPointer = 0;
					}

					template <class T> Stack<T>::~Stack()
					{
						delete[] this->Items;
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
