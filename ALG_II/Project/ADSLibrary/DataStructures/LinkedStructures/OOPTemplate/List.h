#pragma once

#include <iostream>
#include <string>

using namespace std;

namespace ADSLibrary
{
	namespace DataStructures
	{
		namespace LinkedStructures
		{
			namespace OOPTemplate
			{
				template <class T>
				class List
				{
				public:
					struct ListItem
					{
						T Value;
						ListItem* Prev;
						ListItem* Next;
					};

					List();
					List(const T& InitValue);
					List(const T InitValues[], const int N);
					List(const List& Other);

					ListItem* GetHead() const;
					ListItem* GetTail() const;

					void Prepend(const T& NewValue);
					void Append(const T& NewValue);
					void InsertBefore(ListItem* CurrentItem, const T& NewValue);
					void InsertAfter(ListItem* CurrentItem, const T& NewValue);

					void RemoveHead();
					void RemoveTail();
					void RemoveFirst(const T& ValueToRemove);
					void RemoveLast(const T& ValueToRemove);
					void RemoveAll(const T& ValueToRemove);
					void Remove(const ListItem* ItemToRemove);
					void Clear();

					ListItem* Search(const T& Value) const;
					ListItem* ReverseSearch(const T& Value) const;

					bool Contains(const T& Value) const;

					bool IsEmpty() const;
					int Count() const;

					void Report() const;
					void ReportStructure() const;

				private:
					ListItem* Head;
					ListItem* Tail;

					void InternalCreateSingleElementList(const T& NewValue);
					void InternalRemove(const ListItem* ItemToDelete);
				};

				template<class T> List<T>::List()
				{
					this->Head = nullptr;
					this->Tail = nullptr;
				}

				template<class T> List<T>::List(const T& InitValue)
				{
					InternalCreateSingleElementList(InitValue);
				}

				template<class T> List<T>::List(const T InitValues[], const int N) : List<T>()
				{
					for (int i = 0; i < N; i++)
					{
						Append(InitValues[i]);
					}
				}

				template<class T> List<T>::List(const List& Other) : List()
				{
					for (ListItem* p = Other.this->Head; p != nullptr; p = p->Next)
					{
						Append(p->Value);
					}
				}

				template<class T> typename List<T>::ListItem* List<T>::GetHead() const
				{
					return this->Head;
				}

				template<class T> typename List<T>::ListItem* List<T>::GetTail() const
				{
					return this->Tail;
				}

				template<class T> void List<T>::Prepend(const T& NewValue)
				{
					if (IsEmpty())
					{
						InternalCreateSingleElementList(NewValue);
					}
					else
					{
						ListItem* NewItem = new ListItem;
						NewItem->Value = NewValue;
						NewItem->Prev = nullptr;
						NewItem->Next = this->Head;
						this->Head->Prev = NewItem;
						this->Head = NewItem;
					}
				}

				template<class T> void List<T>::Append(const T& NewValue)
				{
					if (IsEmpty())
					{
						InternalCreateSingleElementList(NewValue);
					}
					else
					{
						ListItem* NewItem = new ListItem;
						NewItem->Value = NewValue;
						NewItem->Next = nullptr;
						this->Tail->Next = NewItem;
						NewItem->Prev = this->Tail;
						this->Tail = NewItem;
					}
				}

				template<class T> void List<T>::InsertBefore(ListItem* CurrentItem, const T& NewValue)
				{
					if (CurrentItem != nullptr)
					{
						if (CurrentItem == this->Head)
						{
							Prepend(NewValue);
						}
						else
						{
							ListItem* NewItem = new ListItem;
							NewItem->Value = NewValue;
							ListItem* P = CurrentItem->Prev;
							P->Next = NewItem;
							NewItem->Prev = P;
							CurrentItem->Prev = NewItem;
							NewItem->Next = CurrentItem;
						}
					}
				}

				template<class T> void List<T>::InsertAfter(ListItem* CurrentItem, const T& NewValue)
				{
					if (CurrentItem != nullptr)
					{
						if (CurrentItem == this->Tail)
						{
							Append(NewValue);
						}
						else
						{
							ListItem* NewItem = new ListItem;
							NewItem->Value = NewValue;
							ListItem* N = CurrentItem->Next;
							N->Prev = NewItem;
							NewItem->Next = N;
							CurrentItem->Next = NewItem;
							NewItem->Prev = CurrentItem;
						}
					}
				}

				template<class T> void List<T>::RemoveHead()
				{
					if (!IsEmpty())
					{
						InternalRemove(this->Head);
					}
				}

				template<class T> void List<T>::RemoveTail()
				{
					if (!IsEmpty())
					{
						InternalRemove(this->Tail);
					}
				}

				template<class T> void List<T>::RemoveFirst(const T& ValueToRemove)
				{
					ListItem* p = Search(ValueToRemove);
					if (p != nullptr)
					{
						InternalRemove(p);
					}
				}

				template<class T> void List<T>::RemoveLast(const T& ValueToRemove)
				{
					ListItem* p = ReverseSearch(ValueToRemove);
					if (p != nullptr)
					{
						InternalRemove(p);
					}
				}

				template<class T> void List<T>::RemoveAll(const T& ValueToRemove)
				{
					ListItem* p;
					while ((p = Search(ValueToRemove)) != nullptr)
					{
						InternalRemove(p);
					}
				}

				template<class T> void List<T>::Remove(const ListItem* ItemToRemove)
				{
					if (ItemToRemove != nullptr)
					{
						InternalRemove(ItemToRemove);
					}
				}

				template<class T> void List<T>::Clear()
				{
					while (!IsEmpty())
					{
						InternalRemove(this->Head);
					}
				}

				template<class T> typename List<T>::ListItem* List<T>::Search(const T& Value) const
				{
					for (ListItem* p = this->Head; p != nullptr; p = p->Next)
					{
						if (p->Value == Value)
						{
							return p;
						}
					}
					return nullptr;
				}

				template<class T> typename List<T>::ListItem* List<T>::ReverseSearch(const T& Value) const
				{
					for (ListItem* p = this->Tail; p != nullptr; p = p->Prev)
					{
						if (p->Value == Value)
						{
							return p;
						}
					}
					return nullptr;
				}

				template<class T> bool List<T>::Contains(const T& Value) const
				{
					return Search(Value) != nullptr;
				}

				template<class T> bool List<T>::IsEmpty() const
				{
					return this->Head == nullptr;
				}

				template<class T> int List<T>::Count() const
				{
					int counter = 0;
					for (ListItem* p = this->Head; p != nullptr; p = p->Next)
					{
						counter += 1;
					}
					return counter;
				}

				template<class T> void List<T>::Report() const
				{
					for (ListItem* p = this->Head; p != nullptr; p = p->Next)
					{
						cout << p->Value << "\t";
					}
					cout << endl;
				}

				template<class T> void List<T>::ReportStructure() const
				{
					cout << "Head: " << this->Head << endl;
					cout << "Tail: " << this->Tail << endl;
					for (ListItem* p = this->Head; p != nullptr; p = p->Next)
					{
						cout << "Item address: " << p << endl;
						cout << "Value: " << p->Value << endl;
						cout << "Prev: " << p->Prev << endl;
						cout << "Next: " << p->Next << endl;
						cout << endl;
					}
				}

				template<class T> void List<T>::InternalCreateSingleElementList(const T& NewValue)
				{
					this->Head = this->Tail = new ListItem;
					this->Head->Value = NewValue;
					this->Head->Prev = nullptr;
					this->Head->Next = nullptr;
				}

				template<class T> void List<T>::InternalRemove(const ListItem* ItemToDelete)
				{
					if (ItemToDelete == this->Head && ItemToDelete == this->Tail)
					{
						this->Head = nullptr;
						this->Tail = nullptr;
					}
					else
					{
						if (ItemToDelete == this->Head)
						{
							this->Head = this->Head->Next;
							this->Head->Prev = nullptr;
						}
						else
						{
							if (ItemToDelete == this->Tail)
							{
								this->Tail = this->Tail->Prev;
								this->Tail->Next = nullptr;
							}
							else
							{
								ListItem* P = ItemToDelete->Prev;
								ListItem* N = ItemToDelete->Next;
								P->Next = N;
								N->Prev = P;
							}
						}
					}
					delete ItemToDelete;
				}
			}
		}
	}
}
