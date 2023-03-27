#include "Queue.h"

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
					Queue::Queue()
					{
						this->Head = 0;
						this->Tail = 0;
					}

					void Queue::Enqueue(const int X)
					{
						this->Items[this->Tail] = X;
						this->Tail = (this->Tail + 1) % this->QueueSize;
					}

					int Queue::Dequeue()
					{
						int x = this->Items[this->Head];
						this->Head = (this->Head + 1) % this->QueueSize;
						return x;
					}

					int Queue::Peek() const
					{
						return this->Items[this->Head];
					}

					bool Queue::IsEmpty() const
					{
						return this->Head == this->Tail;
					}

					bool Queue::IsFull() const
					{
						return this->Head == (this->Tail + 1) % this->QueueSize;
					}

					void Queue::Clear()
					{
						this->Head = 0;
						this->Tail = 0;
					}

					void Queue::Report() const
					{
						cout << "Queue report" << endl;
						cout << "--------------------------" << endl;
						cout << "Head: " << this->Head << endl;
						cout << "Tail: " << this->Tail << endl;
						for (int i = 0; i < this->QueueSize; i++)
						{
							cout << i << "   " << this->Items[i] << endl;
						}
						cout << "--------------------------" << endl;
						cout << endl;
					}
				}
			}
		}
	}
}
