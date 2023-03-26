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
			namespace OOP
			{
				class List
				{
				public:
					struct ListItem
					{
						string Value;
						ListItem* Prev;
						ListItem* Next;
					};

					List();
					List(const string& InitValue);
					List(const string InitValues[], const int N);
					List(const List& Other);

					ListItem* GetHead() const;
					ListItem* GetTail() const;

					void Prepend(const string& NewValue);
					void Append(const string& NewValue);
					void InsertBefore(ListItem* CurrentItem, const string& NewValue);
					void InsertAfter(ListItem* CurrentItem, const string& NewValue);

					void RemoveHead();
					void RemoveTail();
					void RemoveFirst(const string& ValueToRemove);
					void RemoveLast(const string& ValueToRemove);
					void RemoveAll(const string& ValueToRemove);
					void Remove(const ListItem* ItemToRemove);
					void Clear();

					ListItem* Search(const string& Value) const;
					ListItem* ReverseSearch(const string& Value) const;

					bool Contains(const string& Value) const;

					bool IsEmpty() const;
					int Count() const;

					void Report() const;
					void ReportStructure() const;

				private:
					ListItem* Head;
					ListItem* Tail;

					void InternalCreateSingleElementList(const string& NewValue);
					void InternalRemove(const ListItem* ItemToDelete);
				};
			}
		}
	}
}
