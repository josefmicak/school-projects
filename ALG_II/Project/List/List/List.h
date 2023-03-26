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
			namespace Procedural
			{
				struct ListItem
				{
					string Value;
					ListItem* Prev;
					ListItem* Next;
				};

				struct SimpleSet
				{
					ListItem* Head;
					ListItem* Tail;
				};

				void Init(SimpleSet& S);
				void Init(SimpleSet& S, const string& InitValue);
				void Init(SimpleSet& S, const string InitValues[], const int N);
				void Init(SimpleSet& S, const SimpleSet& Other);

				void Prepend(SimpleSet& S, const string& NewValue);
				void Add(SimpleSet& S, const string& NewValue);
				void InsertBefore(SimpleSet& S, ListItem* CurrentItem, const string& NewValue);
				void InsertAfter(SimpleSet& S, ListItem* CurrentItem, const string& NewValue);

				void RemoveHead(SimpleSet& S);
				void RemoveTail(SimpleSet& S);
				void RemoveFirst(SimpleSet& S, const string& ValueToRemove);
				void RemoveLast(SimpleSet& S, const string& ValueToRemove);
				void Remove(SimpleSet& S, const string& ValueToRemove);
				void RemoveItem(SimpleSet& S, const ListItem* ItemToRemove);
				void Clear(SimpleSet& S);

				ListItem* Search(const SimpleSet& S, const string& Value);
				ListItem* ReverseSearch(const SimpleSet& S, const string& Value);

				bool Contains(const SimpleSet& S, const string& Value);

				bool IsEmpty(const SimpleSet& S);
				int Count(const SimpleSet& S);

				void Report(const SimpleSet& S);
				void ReportStructure(const SimpleSet& S);

				void InternalCreateSingleElementList(SimpleSet& S, const string& NewValue);
				void InternalRemove(SimpleSet& S, const ListItem* ItemToDelete);

				void UnionWith(SimpleSet& S, const SimpleSet& Other);
				void IntersectionWith(SimpleSet& S, const SimpleSet& Other);
			}
		}
	}
}

