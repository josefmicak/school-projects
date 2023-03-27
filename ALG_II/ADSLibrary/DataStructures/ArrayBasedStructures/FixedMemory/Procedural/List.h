#pragma once

#include <iostream>
#include <string>

using namespace std;

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
					* \brief Velikost seznamu.
					*/
					const int ListSize = 5;

					/**
					* \brief Konstanta reprezentující nulový ukazatel, ukazatel "nikam".
					*/
					const int Nothing = -1;

					/**
					* \brief Položka seznamu implementovaného v poli.
					*/
					struct ListItem
					{
						/**
						* \brief Hodnota uložená v položce seznamu.
						*/
						string Value;
						/**
						* \brief Ukazatel na předcházející položku, ukazatel na předchůdce.
						*/
						int Prev;
						/**
						* \brief Ukazatel na následující položku, ukazatel na následníka.
						*/
						int Next;
					};

					/**
					* \brief Seznam pevné velikosti implementovaný v poli procedurálním způsobem.
					*
					* @author	Jiří Dvorský <jiri.dvorsky@vsb.cz>
					* @date	2010 - 2019
					*/
					struct List
					{
						ListItem Items[ListSize];
						int Head;
						int Tail;
						int Free;
					};

					void Init(List& L);
					void Init(List& L, const string& InitValue);
					void Init(List& L, const string InitValues[], const int N);
					void Init(List& L, const List& Other);

					void Prepend(List& L, const string& NewValue);
					void Append(List& L, const string& NewValue);
					void InsertBefore(List& L, const int CurrentItem, const string& NewValue);
					void InsertAfter(List& L, const int CurrentItem, const string& NewValue);

					void RemoveHead(List& L);
					void RemoveTail(List& L);
					void RemoveFirst(List& L, const string& ValueToRemove);
					void RemoveLast(List& L, const string& ValueToRemove);
					void RemoveAll(List& L, const string& ValueToRemove);
					void Remove(List& L, const int ItemToRemove);
					void Clear(List& L);

					int Search(const List& L, const string& Value);
					int ReverseSearch(const List& L, const string& Value);

					bool Contains(const List& L, const string& Value);

					bool IsEmpty(const List& L);
					int Count(const List& L);

					void Report(const List& L);
					void ReportStructure(const List& L);

					void InternalCreateSingleElementList(List& L, const string& NewValue);
					void InternalRemove(List& L, const int ItemToDelete);
					int InternalAllocateItem(List& L);
					void InternalFreeItem(List& L, const int Index);
				}
			}
		}
	}
}
