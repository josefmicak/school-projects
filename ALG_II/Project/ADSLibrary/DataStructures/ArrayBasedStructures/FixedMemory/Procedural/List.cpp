#include "List.h"

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
					void Init(List& L)
					{
						Clear(L);
					}

					void Init(List& L, const string& InitValue)
					{
						Init(L);
						InternalCreateSingleElementList(L, InitValue);
					}

					void Init(List& L, const string InitValues[], const int N)
					{
						Init(L);
						for (int i = 0; i < N; i++)
						{
							Append(L, InitValues[i]);
						}
					}

					void Init(List& L, const List& Other)
					{
						Init(L);
						for (int p = Other.Head; p != Nothing; p = Other.Items[p].Next)
						{
							Append(L, Other.Items[p].Value);
						}
					}

					void Prepend(List& L, const string& NewValue)
					{
						if (IsEmpty(L))
						{
							InternalCreateSingleElementList(L, NewValue);
						}
						else
						{
							int NewItemIndex = InternalAllocateItem(L);
							L.Items[NewItemIndex].Value = NewValue;
							L.Items[NewItemIndex].Prev = Nothing;
							L.Items[NewItemIndex].Next = L.Head;
							L.Items[L.Head].Prev = NewItemIndex;
							L.Head = NewItemIndex;
						}
					}

					void Append(List& L, const string& NewValue)
					{
						if (IsEmpty(L))
						{
							InternalCreateSingleElementList(L, NewValue);
						}
						else
						{
							int NewItemIndex = InternalAllocateItem(L);
							L.Items[NewItemIndex].Value = NewValue;
							L.Items[NewItemIndex].Prev = L.Tail;
							L.Items[NewItemIndex].Next = Nothing;
							L.Items[L.Tail].Next = NewItemIndex;
							L.Tail = NewItemIndex;
						}
					}

					void InsertBefore(List& L, const int CurrentItem, const string& NewValue)
					{
						if (CurrentItem != Nothing)
						{
							if (CurrentItem == L.Head)
							{
								Prepend(L, NewValue);
							}
							else
							{
								int NewItemIndex = InternalAllocateItem(L);
								L.Items[NewItemIndex].Value = NewValue;
								int P = L.Items[CurrentItem].Prev;
								L.Items[P].Next = NewItemIndex;
								L.Items[NewItemIndex].Prev = P;
								L.Items[CurrentItem].Prev = NewItemIndex;
								L.Items[NewItemIndex].Next = CurrentItem;
							}
						}
					}

					void InsertAfter(List& L, const int CurrentItem, const string& NewValue)
					{
						if (CurrentItem != Nothing)
						{
							if (CurrentItem == L.Tail)
							{
								Append(L, NewValue);
							}
							else
							{
								int NewItemIndex = InternalAllocateItem(L);
								L.Items[NewItemIndex].Value = NewValue;
								int N = L.Items[CurrentItem].Next;
								L.Items[N].Prev = NewItemIndex;
								L.Items[NewItemIndex].Next = N;
								L.Items[CurrentItem].Next = NewItemIndex;
								L.Items[NewItemIndex].Prev = CurrentItem;
							}
						}
					}

					void RemoveHead(List& L)
					{
						if (!IsEmpty(L))
						{
							InternalRemove(L, L.Head);
						}
					}

					void RemoveTail(List& L)
					{
						if (!IsEmpty(L))
						{
							InternalRemove(L, L.Tail);
						}
					}

					void RemoveFirst(List& L, const string& ValueToRemove)
					{
						int p = Search(L, ValueToRemove);
						if (p != Nothing)
						{
							InternalRemove(L, p);
						}
					}

					void RemoveLast(List& L, const string& ValueToRemove)
					{
						int p = ReverseSearch(L, ValueToRemove);
						if (p != Nothing)
						{
							InternalRemove(L, p);
						}
					}

					void RemoveAll(List& L, const string& ValueToRemove)
					{
						int p;
						while ((p = Search(L, ValueToRemove)) != Nothing)
						{
							InternalRemove(L, p);
						}
					}

					void Remove(List& L, const int ItemToRemove)
					{
						if (ItemToRemove != Nothing)
						{
							InternalRemove(L, ItemToRemove);
						}
					}

					void Clear(List& L)
					{
						L.Head = Nothing;
						L.Tail = Nothing;
						for (int i = 0; i < ListSize; i++)
						{
							L.Items[i].Next = i + 1;
						}
						L.Items[ListSize - 1].Next = Nothing;
						L.Free = 0;
					}

					int Search(const List& L, const string& Value)
					{
						for (int p = L.Head; p != Nothing; p = L.Items[p].Next)
						{
							if (L.Items[p].Value == Value)
							{
								return p;
							}
						}
						return Nothing;
					}

					int ReverseSearch(const List& L, const string& Value)
					{
						for (int p = L.Tail; p != Nothing; p = L.Items[p].Prev)
						{
							if (L.Items[p].Value == Value)
							{
								return p;
							}
						}
						return Nothing;
					}

					bool Contains(const List& L, const string& Value)
					{
						return Search(L, Value) != Nothing;
					}

					bool IsEmpty(const List& L)
					{
						return L.Head == Nothing;
					}

					int Count(const List& L)
					{
						int counter = 0;
						for (int p = L.Head; p != Nothing; p = L.Items[p].Next)
						{
							counter += 1;
						}
						return counter;
					}

					void Report(const List& L)
					{
						for (int p = L.Head; p != Nothing; p = L.Items[p].Next)
						{
							cout << L.Items[p].Value << "\t";
						}
						cout << endl;
					}

					void ReportStructure(const List& L)
					{
						cout << "L.Head: " << L.Head << endl;
						cout << "L.Tail: " << L.Tail << endl;
						for (int p = L.Head; p != Nothing; p = L.Items[p].Next)
						{
							cout << "Item address: " << p << endl;
							cout << "Value: " << L.Items[p].Value << endl;
							cout << "Prev: " << L.Items[p].Prev << endl;
							cout << "Next: " << L.Items[p].Next << endl;
							cout << endl;
						}
					}

					void InternalCreateSingleElementList(List& L, const string& NewValue)
					{
						L.Head = L.Tail = InternalAllocateItem(L);
						L.Items[L.Head].Value = NewValue;
						L.Items[L.Head].Prev = Nothing;
						L.Items[L.Head].Next = Nothing;
					}

					void InternalRemove(List& L, const int ItemToDeleteIndex)
					{
						if (ItemToDeleteIndex == L.Head && ItemToDeleteIndex == L.Tail)
						{
							L.Head = Nothing;
							L.Tail = Nothing;
						}
						else
						{
							if (ItemToDeleteIndex == L.Head)
							{
								L.Head = L.Items[L.Head].Next;
								L.Items[L.Head].Prev = Nothing;
							}
							else
							{
								if (ItemToDeleteIndex == L.Tail)
								{
									L.Tail = L.Items[L.Tail].Prev;
									L.Items[L.Tail].Next = Nothing;
								}
								else
								{
									int P = L.Items[ItemToDeleteIndex].Prev;
									int N = L.Items[ItemToDeleteIndex].Next;
									L.Items[P].Next = N;
									L.Items[N].Prev = P;
								}
							}
						}
						InternalFreeItem(L, ItemToDeleteIndex);
					}

					int InternalAllocateItem(List& L)
					{
						if (L.Free != Nothing)
						{
							int p = L.Free;
							L.Free = L.Items[L.Free].Next;
							return p;
						}
						cerr << "List is full" << endl;
						return Nothing;
					}

					void InternalFreeItem(List& L, const int Index)
					{
						L.Items[Index].Next = L.Free;
						L.Free = Index;
					}
				}
			}
		}
	}
}
