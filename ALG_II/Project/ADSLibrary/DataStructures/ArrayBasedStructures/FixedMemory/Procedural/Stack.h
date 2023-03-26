#pragma once

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
					* \brief Velikost zásobníku.
					*/
					const int StackSize = 100;

					/**
					* \brief Zásobník pevné velikosti implementovaný v poli procedurálním způsobem.
					*
					* @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
					* @date	2010 - 2017
					*/
					struct Stack
					{
						/**
						* \brief Pole obsahující položky zásobníku.
						*/
						char Items[StackSize];
						/**
						* \brief Ukazatel zásobníku.
						* Ukazatel zásobníku ukazuje na první volnou pozici v poli #Items.
						*/
						int StackPointer;
					};

					/**
					* Inicializace zásobníku. Zásobník je po inicializaci prázdný.
					*
					* @param S Inicializovaný zásobník
					*/
					void Init(Stack& S);

					/**
					* Vložení prvku na vrchol zásobníku.
					*
					* @param S Zásobník
					* @param X Vkládaný prvek
					*/
					void Push(Stack& S, const char X);

					/**
					* Odebrání prvku z vrcholu zásobníku.
					*
					* @param S Zásobník
					* @return Prvek z vrcholu zásobníku
					*/
					char Pop(Stack& S);

					/**
					* Prvek na vrcholu zásobníku.
					* Prvek není ze zásobníku odstraněn, jedná se tedy o nedestruktivní variantu funkce #Pop.
					*
					* @param S Zásobník
					* @return Prvek z vrcholu zásobníku
					*/
					char Top(const Stack& S);

					/**
					* Test, je-li zásobník prázdný.
					*
					* @param S Zásobník
					* @return Funkce vrací true pokud je zásobník prázdný, jinak false.
					*/
					bool IsEmpty(const Stack& S);

					/**
					* Test, je-li zásobník zaplněný.
					*
					* @param S Zásobník
					* @return Funkce vrací true pokud je zásobník zaplněný, jinak false.
					*/
					bool IsFull(const Stack& S);

					/**
					* Smazání celého obsahu zásobníku.
					*
					* @param S Zásobník
					*/
					void Clear(Stack& S);
				}
			}
		}
	}
}
