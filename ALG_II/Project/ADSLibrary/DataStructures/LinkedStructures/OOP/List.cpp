#include "List.h"

namespace ADSLibrary
{
	namespace DataStructures
	{
		namespace LinkedStructures
		{
			namespace OOP
			{
				List::List()
				{
					this->Head = nullptr;
					this->Tail = nullptr;
				}

				List::List(const string& InitValue)
				{
					InternalCreateSingleElementList(InitValue);
				}

				List::List(const string InitValues[], const int N) : List()
				{
					for (int i = 0; i < N; i++)
					{
						Append(InitValues[i]);
					}
				}

				List::List(const List& Other) : List()
				{
					for (ListItem* p = Other.Head; p != nullptr; p = p->Next)
					{
						Append(p->Value);
					}
				}

				List::ListItem* List::GetHead() const
				{
					return this->Head;
				}

				List::ListItem* List::GetTail() const
				{
					return this->Tail;
				}

				void List::Prepend(const string& NewValue)
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

				void List::Append(const string& NewValue)
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

				void List::InsertBefore(ListItem* CurrentItem, const string& NewValue)
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

				void List::InsertAfter(ListItem* CurrentItem, const string& NewValue)
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

				void List::RemoveHead()
				{
					if (!IsEmpty())
					{
						InternalRemove(this->Head);
					}
				}

				void List::RemoveTail()
				{
					if (!IsEmpty())
					{
						InternalRemove(this->Tail);
					}
				}

				void List::RemoveFirst(const string& ValueToRemove)
				{
					ListItem* p = Search(ValueToRemove);
					if (p != nullptr)
					{
						InternalRemove(p);
					}
				}

				void List::RemoveLast(const string& ValueToRemove)
				{
					ListItem* p = ReverseSearch(ValueToRemove);
					if (p != nullptr)
					{
						InternalRemove(p);
					}
				}

				void List::RemoveAll(const string& ValueToRemove)
				{
					ListItem* p;
					while ((p = Search(ValueToRemove)) != nullptr)
					{
						InternalRemove(p);
					}
				}

				void List::Remove(const ListItem* ItemToRemove)
				{
					if (ItemToRemove != nullptr)
					{
						InternalRemove(ItemToRemove);
					}
				}

				void List::Clear()
				{
					while (!IsEmpty())
					{
						InternalRemove(this->Head);
					}
				}

				List::ListItem* List::Search(const string& Value) const
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

				List::ListItem* List::ReverseSearch(const string& Value) const
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

				bool List::Contains(const string& Value) const
				{
					return Search(Value) != nullptr;
				}

				bool List::IsEmpty() const
				{
					return this->Head == nullptr;
				}

				int List::Count() const
				{
					int counter = 0;
					for (ListItem* p = this->Head; p != nullptr; p = p->Next)
					{
						counter += 1;
					}
					return counter;
				}

				void List::Report() const
				{
					for (ListItem* p = this->Head; p != nullptr; p = p->Next)
					{
						cout << p->Value << "\t";
					}
					cout << endl;
				}

				void List::ReportStructure() const
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

				void List::InternalCreateSingleElementList(const string& NewValue)
				{
					this->Head = this->Tail = new ListItem;
					this->Head->Value = NewValue;
					this->Head->Prev = nullptr;
					this->Head->Next = nullptr;
				}

				void List::InternalRemove(const ListItem* ItemToDelete)
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