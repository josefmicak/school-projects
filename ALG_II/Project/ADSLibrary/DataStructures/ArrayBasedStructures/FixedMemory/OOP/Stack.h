#pragma once

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
					* \brief Zásobník pevné velikosti implementovaný v poli s využitím %OOP
					*
					* @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
					* @date	2010 - 2017
					*/
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
						void Push(const char X);

						/**
						* Odebrání prvku z vrcholu zásobníku.
						*
						* @return Prvek z vrcholu zásobníku
						*/
						char Pop();

						/**
						* Prvek na vrcholu zásobníku.
						* Prvek není ze zásobníku odstraněn, jedná se tedy o nedestruktivní variantu funkce #Pop.
						*
						* @return Prvek z vrcholu zásobníku
						*/
						char Top() const;

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
						char Items[StackSize];

						/**
						* Ukazatel zásobníku (stack pointer).
						*/
						int StackPointer;
					};
				}
			}
		}
	}
}
