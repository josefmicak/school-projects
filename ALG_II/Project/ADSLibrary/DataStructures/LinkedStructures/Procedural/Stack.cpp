#include "Stack.h"

namespace ADSLibrary
{
	namespace DataStructures
	{
		namespace LinkedStructures
		{
			namespace Procedural
			{
				void Init(Stack& S)
				{
					S.StackPointer = nullptr;
				}

				void Push(Stack& S, const char X)
				{
					StackItem* n = new StackItem();
					n->Value = X;
					n->Prev = S.StackPointer;
					S.StackPointer = n;
				}

				char Pop(Stack& S)
				{
					StackItem* d = S.StackPointer;
					char ch = d->Value;
					S.StackPointer = S.StackPointer->Prev;
					delete d;
					return ch;
				}

				char Top(const Stack& S)
				{
					return S.StackPointer->Value;
				}

				bool IsEmpty(const Stack& S)
				{
					return S.StackPointer == nullptr;
				}
				
				void Clear(Stack& S)
				{
					while (!IsEmpty(S))
					{
						Pop(S);
					}
				}
			}
		}
	}
}