#include "Queue.h"

namespace ADSLibrary
{
	namespace DataStructures
	{
		namespace LinkedStructures
		{
			namespace Procedural
			{
				void Init(Queue& Q)
				{
					Q.Head = nullptr;
					Q.Tail = nullptr;
				}

				void Enqueue(Queue& Q, const int X)
				{
					QueueItem* n = new QueueItem();
					n->Value = X;
					n->Prev = nullptr;
					if (IsEmpty(Q))
					{
						Q.Head = n;
					}
					else
					{
						Q.Tail->Prev = n;
					}
					Q.Tail = n;
				}

				int Dequeue(Queue& Q)
				{
					QueueItem* d = Q.Head;
					int result = d->Value;
					Q.Head = Q.Head->Prev;
					if (IsEmpty(Q))
					{
						Q.Tail = nullptr;
					}
					delete d;
					return result;
				}

				int Peek(const Queue& Q)
				{
					return Q.Head->Value;
				}

				bool IsEmpty(const Queue& Q)
				{
					return Q.Head == nullptr;
				}

				void Clear(Queue& Q)
				{
					while (!IsEmpty(Q))
					{
						Dequeue(Q);
					}
				}
			}
		}
	}
}
