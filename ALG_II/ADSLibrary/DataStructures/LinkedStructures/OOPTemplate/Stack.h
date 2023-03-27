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
				 * \brief Zásobník implementovaný pomocí spojových struktur jako šablona (template) %OOP.
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
					 * Destruktor.
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
					 * Prvek není za zásobníku odstraněn, jedná se tedy o nedestruktivní variantu funkce #Pop.
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
					 * Smazání celého obsahu zásobníku.
					 */
					void Clear();

				private:
					/**
					 * \brief Struktura reprezentující položku v zásobníku.
					 */
					struct StackItem
					{
						/**
						 * Hodnota obsažená v položce.
						 */
						T Value;
						/**
						 * Ukazatel na předchozí položku. Pokud taková položka neexistuje ukazatel má hodnotu nullptr.
						 */
						StackItem* Prev;
					};

					/**
					 * Ukazatel zásobníku.
					 */
					StackItem* StackPointer;
				};


				template <class T> Stack<T>::Stack()
				{
					this->StackPointer = nullptr;
				}

				template <class T> Stack<T>::~Stack()
				{
					this->Clear();
				}

				template <class T> void Stack<T>::Push(const T X)
				{
					StackItem* n = new StackItem();
					n->Value = X;
					n->Prev = this->StackPointer;
					this->StackPointer = n;
				}

				template <class T> T Stack<T>::Pop()
				{
					StackItem* d = this->StackPointer;
					T result = d->Value;
					this->StackPointer = this->StackPointer->Prev;
					delete d;
					return result;
				}

				template <class T> T Stack<T>::Top() const
				{
					return this->StackPointer->Value;
				}

				template <class T> bool Stack<T>::IsEmpty() const
				{
					return this->StackPointer == nullptr;
				}

				template <class T> void Stack<T>::Clear()
				{
					while (!this->IsEmpty())
					{
						this->Pop();
					}
				}
			}
		}
	}
}
