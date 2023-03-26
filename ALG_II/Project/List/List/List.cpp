#include "List.h"
#include <vector>

namespace ADSLibrary
{
	namespace DataStructures
	{
		namespace LinkedStructures
		{
			namespace Procedural
			{
				void Init(SimpleSet& S)
				{
					S.Head = nullptr;
					S.Tail = nullptr;
				}

				void Init(SimpleSet& S, const string& InitValue)
				{
					InternalCreateSingleElementList(S, InitValue);
				}

				void Init(SimpleSet& S, const string InitValues[], const int N)
				{
					Init(S);
					for (int i = 0; i < N; i++)
					{
						Add(S, InitValues[i]);
					}
				}

				void Init(SimpleSet& S, const SimpleSet& Other)
				{
					Init(S);
					for (ListItem* p = Other.Head; p != nullptr; p = p->Next)
					{
						Add(S, p->Value);
					}
				}

				void Prepend(SimpleSet& S, const string& NewValue)
				{
					if (IsEmpty(S))
					{
						InternalCreateSingleElementList(S, NewValue);
					}
					else
					{
						ListItem* NewItem = new ListItem;
						NewItem->Value = NewValue;
						NewItem->Prev = nullptr;
						NewItem->Next = S.Head;
						S.Head->Prev = NewItem;
						S.Head = NewItem;
					}
				}

				void Add(SimpleSet& S, const string& NewValue)
				{
					if (!Contains(S, NewValue))
					{
						if (IsEmpty(S))
						{
							InternalCreateSingleElementList(S, NewValue);
						}
						else
						{
							ListItem* NewItem = new ListItem;
							NewItem->Value = NewValue;
							NewItem->Next = nullptr;
							S.Tail->Next = NewItem;
							NewItem->Prev = S.Tail;
							S.Tail = NewItem;
						}
					}
				}

				void InsertBefore(SimpleSet& S, ListItem* CurrentItem, const string& NewValue)
				{
					if (CurrentItem != nullptr)
					{
						if (CurrentItem == S.Head)
						{
							Prepend(S, NewValue);
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

				void InsertAfter(SimpleSet& S, ListItem* CurrentItem, const string& NewValue)
				{
					if (CurrentItem != nullptr)
					{
						if (CurrentItem == S.Tail)
						{
							Add(S, NewValue);
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

				void RemoveHead(SimpleSet& S)
				{
					if (!IsEmpty(S))
					{
						InternalRemove(S, S.Head);
					}
				}

				void RemoveTail(SimpleSet& S)
				{
					if (!IsEmpty(S))
					{
						InternalRemove(S, S.Tail);
					}
				}

				void RemoveFirst(SimpleSet& S, const string& ValueToRemove)
				{
					ListItem* p = Search(S, ValueToRemove);
					if (p != nullptr)
					{
						InternalRemove(S, p);
					}
				}

				void RemoveLast(SimpleSet& S, const string& ValueToRemove)
				{
					ListItem* p = ReverseSearch(S, ValueToRemove);
					if (p != nullptr)
					{
						InternalRemove(S, p);
					}
				}

				void Remove(SimpleSet& S, const string& ValueToRemove)
				{
					ListItem* p;
					while ((p = Search(S, ValueToRemove)) != nullptr)
					{
						InternalRemove(S, p);
					}
				}

				void RemoveItem(SimpleSet& S, const ListItem* ItemToRemove)
				{
					if (ItemToRemove != nullptr)
					{
						InternalRemove(S, ItemToRemove);
					}
				}

				void Clear(SimpleSet& S)
				{
					while (!IsEmpty(S))
					{
						InternalRemove(S, S.Head);
					}
				}

				ListItem* Search(const SimpleSet& S, const string& Value)
				{
					for (ListItem* p = S.Head; p != nullptr; p = p->Next)
					{
						if (p->Value == Value)
						{
							return p;
						}
					}
					return nullptr;
				}

				ListItem* ReverseSearch(const SimpleSet& S, const string& Value)
				{
					for (ListItem* p = S.Tail; p != nullptr; p = p->Prev)
					{
						if (p->Value == Value)
						{
							return p;
						}
					}
					return nullptr;
				}

				bool Contains(const SimpleSet& S, const string& Value)
				{
					return Search(S, Value) != nullptr;
				}

				bool IsEmpty(const SimpleSet& S)
				{
					return S.Head == nullptr;
				}

				int Count(const SimpleSet& S)
				{
					int counter = 0;
					for (ListItem* p = S.Head; p != nullptr; p = p->Next)
					{
						counter += 1;
					}
					return counter;
				}

				void Report(const SimpleSet& S)
				{
					for (ListItem* p = S.Head; p != nullptr; p = p->Next)
					{
						cout << p->Value << "\t";
					}
					cout << endl;
				}

				void ReportStructure(const SimpleSet& S)
				{
					cout << "S.Head: " << S.Head << endl;
					cout << "S.Tail: " << S.Tail << endl;
					for (ListItem* p = S.Head; p != nullptr; p = p->Next)
					{
						cout << "Item address: " << p << endl;
						cout << "Value: " << p->Value << endl;
						cout << "Prev: " << p->Prev << endl;
						cout << "Next: " << p->Next << endl;
						cout << endl;
					}
				}

				void InternalCreateSingleElementList(SimpleSet& S, const string& NewValue)
				{
					S.Head = S.Tail = new ListItem;
					S.Head->Value = NewValue;
					S.Head->Prev = nullptr;
					S.Head->Next = nullptr;
				}

				void InternalRemove(SimpleSet& S, const ListItem* ItemToDelete)
				{
					if (ItemToDelete == S.Head && ItemToDelete == S.Tail)
					{
						S.Head = nullptr;
						S.Tail = nullptr;
					}
					else
					{
						if (ItemToDelete == S.Head)
						{
							S.Head = S.Head->Next;
							S.Head->Prev = nullptr;
						}
						else
						{
							if (ItemToDelete == S.Tail)
							{
								S.Tail = S.Tail->Prev;
								S.Tail->Next = nullptr;
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

				void UnionWith(SimpleSet& S, const SimpleSet& Other)
				{
					vector<string> _union;
					for (ListItem* p = S.Head; p != nullptr; p = p->Next)
					{
						_union.push_back(p->Value);
					}

					for (ListItem* r = Other.Head; r != nullptr; r = r->Next)
					{
						if (Contains(S, r->Value) == false)
						{
							_union.push_back(r->Value);
						}
					}

					for (int i = 0; i < _union.size(); i++)
					{
						cout << _union.at(i) << "\t";
					}
					cout << endl;
				}

				void IntersectionWith(SimpleSet& S, const SimpleSet& Other)
				{
					vector<string> intersection;
					for (ListItem* p = S.Head; p != nullptr; p = p->Next)
					{
						if (Contains(Other, p->Value))
						{
							intersection.push_back(p->Value);
						}
					}

					for (int i = 0; i < intersection.size(); i++)
					{
						cout << intersection.at(i) << "\t";
					}
					cout << endl;
				}
			}
		}
	}
}
