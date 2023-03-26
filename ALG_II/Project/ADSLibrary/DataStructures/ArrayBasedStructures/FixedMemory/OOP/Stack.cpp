#include "Stack.h"

namespace ADSLibrary
{
	namespace DataStructures
	{
		namespace ArrayBasedStructures
		{
			namespace FixedMemory
			{
				namespace OOP
				{
					Stack::Stack()
					{
						this->StackPointer = 0;
					}

					void Stack::Push(const char X)
					{
						this->Items[this->StackPointer] = X;
						this->StackPointer += 1;
					}

					char Stack::Pop()
					{
						this->StackPointer -= 1;
						return this->Items[this->StackPointer];
					}

					char Stack::Top() const
					{
						return this->Items[this->StackPointer - 1];
					}

					bool Stack::IsEmpty() const
					{
						return this->StackPointer == 0;
					}

					bool Stack::IsFull() const
					{
						return this->StackPointer >= this->StackSize;
					}

					void Stack::Clear()
					{
						this->StackPointer = 0;
					}
				}
			}
		}
	}
}
