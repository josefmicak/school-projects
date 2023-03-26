#include <climits>
#include "ArraySortingAlgorithms.h"

namespace ADSLibrary
{
	namespace Algorithms
	{
		namespace ArraySortingAlgorithms
		{
			void Exchange(int& x, int& y)
			{
				int aux = x;
				x = y;
				y = aux;
			}

			void SelectSort(int a[], const int n)
			{
				for (int i = 0; i < n; i++)
				{
					int min = i;
					for (int j = i + 1; j < n; j++)
					{
						if (a[j] < a[min])
						{
							min = j;
						}
					}
					Exchange(a[min], a[i]);
				}
			}

			void InsertSort(int a[], const int n)
			{
				for (int i = 1; i < n; i++)
				{
					int v = a[i];
					int j = i;
					while (j > 0)
					{
						if (a[j - 1] > v)
						{
							a[j] = a[j - 1];
							j -= 1;
						}
						else
						{
							break;
						}
					}
					a[j] = v;
				}
			}

			void BubbleSort0(int a[], const int n)
			{
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n - 1; j++)
					{
						if (a[j] > a[j + 1])
						{
							Exchange(a[j], a[j + 1]);
						}
					}
				}
			}

			void BubbleSort1(int a[], const int n)
			{
				for (int i = n - 1; i > 0; i--)
				{
					for (int j = 0; j < i; j++)
					{
						if (a[j] > a[j + 1])
						{
							Exchange(a[j], a[j + 1]);
						}
					}
				}
			}

			void BubbleSort2(int a[], const int n)
			{
				bool AnyExchange;
				do
				{
					AnyExchange = false;
					for (int i = 0; i < n - 1; i++)
					{
						if (a[i] > a[i + 1])
						{
							Exchange(a[i], a[i + 1]);
							AnyExchange = true;
						}
					}
				} while (AnyExchange);
			}

			void BubbleSort3(int a[], const int n)
			{
				bool AnyExchange;
				int Right = n - 1;
				do
				{
					AnyExchange = false;
					for (int i = 0; i < Right; i++)
					{
						if (a[i] > a[i + 1])
						{
							Exchange(a[i], a[i + 1]);
							AnyExchange = true;
						}
					}
					Right -= 1;
				} while (AnyExchange);
			}

			void BubbleSort4(int a[], const int n)
			{
				int Right = n - 1;
				int LastExchangeIndex;
				do
				{
					LastExchangeIndex = 0;
					for (int i = 0; i < Right; i++)
					{
						if (a[i] > a[i + 1])
						{
							Exchange(a[i], a[i + 1]);
							LastExchangeIndex = i + 1;
						}
					}
					Right = LastExchangeIndex;
				} while (LastExchangeIndex > 0);
			}

			void CombSort(int a[], const int n)
			{
				int Gap = n;
				bool AnyExchange;
				do
				{
					AnyExchange = false;
					Gap = 10 * Gap / 13;
					if (Gap < 1)
					{
						Gap = 1;
					}
					for (int i = 0; i + Gap < n; i++)
					{
						if (a[i] > a[i + Gap])
						{
							Exchange(a[i], a[i + Gap]);
							AnyExchange = true;
						}
					}
				} while (Gap != 1 || AnyExchange);
			}

			void ShakerSort(int a[], const int n)
			{
				int ExchangeIndex = 0;
				int Left = 0;
				int Right = n - 1;
				do
				{
					for (int i = Left; i < Right; i++)
					{
						if (a[i] > a[i + 1])
						{
							Exchange(a[i], a[i + 1]);
							ExchangeIndex = i;
						}
					}
					Right = ExchangeIndex;
					for (int i = Right; i > Left; i--)
					{
						if (a[i - 1] > a[i])
						{
							Exchange(a[i - 1], a[i]);
							ExchangeIndex = i;
						}
					}
					Left = ExchangeIndex;
				} while (Left < Right);
			}

			void ShellSort(int a[], const int n)
			{
				const int NumberOfGaps = 8;
				const int Gaps[NumberOfGaps] = { 701, 301, 132, 57, 23, 10, 4, 1 };
				for (int g = 0; g < NumberOfGaps; g++)
				{
					int gap = Gaps[g];
					for (int i = gap; i < n; i += 1)
					{
						int v = a[i];
						int j = i;
						while (j >= gap)
						{
							if (a[j - gap] > v)
							{
								a[j] = a[j - gap];
								j -= gap;
							}
							else
							{
								break;
							}
						}
						a[j] = v;
					}
				}
			}

			void QuickSortInternal(int a[], const int l, const int r)
			{
				int i = l;
				int j = r;
				int pivot = a[(l + r) / 2];
				do
				{
					while (a[i] < pivot)
						i += 1;
					while (pivot < a[j])
						j -= 1;
					if (i <= j)
					{
						Exchange(a[i], a[j]);
						i += 1;
						j -= 1;
					}
				} while (i <= j);
				if (l < j)
					QuickSortInternal(a, l, j);
				if (i < r)
					QuickSortInternal(a, i, r);
			}

			void QuickSort(int a[], const int n)
			{
				QuickSortInternal(a, 0, n - 1);
			}

			void BuildHeap(int a[], int n, int i)
			{
				int largest = i;
				int left = 2 * i + 1;
				int right = 2 * i + 2;
				if (left < n && a[left] > a[largest])
					largest = left;
				if (right < n && a[right] > a[largest])
					largest = right;
				if (largest != i)
				{
					Exchange(a[i], a[largest]);
					BuildHeap(a, n, largest);
				}
			}

			void HeapSort(int a[], const int n)
			{
				for (int i = n / 2 - 1; i >= 0; i--)
					BuildHeap(a, n, i);
				for (int i = n - 1; i >= 0; i--)
				{
					Exchange(a[0], a[i]);
					BuildHeap(a, i, 0);
				}
			}

			int GetBit(const int Value, const int BitPosition)
			{
				return (Value >> BitPosition) & 1;
			}

			void RadixSortInternal(int a[], const int l, const int r, const int b)
			{
				if (r > l && b >= 0)
				{
					int i = l;
					int j = r;
					do
					{
						while (GetBit(a[i], b) == 0 && i < j)
							i++;
						while (GetBit(a[j], b) == 1 && i < j)
							j--;
						Exchange(a[i], a[j]);
					} while (j != i);
					if (GetBit(a[r], b) == 0)
						j++;
					RadixSortInternal(a, l, j - 1, b - 1);
					RadixSortInternal(a, j, r, b - 1);
				}
			}

			void RadixSort(int a[], const int n)
			{
				const int BitsPerInt = sizeof(int) * CHAR_BIT;
				RadixSortInternal(a, 0, n - 1, BitsPerInt - 1);
			}
		}
	}
}
