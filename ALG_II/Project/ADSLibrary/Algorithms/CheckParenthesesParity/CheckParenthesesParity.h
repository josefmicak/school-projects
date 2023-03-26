#pragma once
#include <string>

#include "../../../ADSLibrary/DataStructures/ArrayBasedStructures/FixedMemory/Procedural/Stack.h"

using namespace std;
using namespace ADSLibrary::DataStructures::ArrayBasedStructures::FixedMemory::Procedural;

namespace ADSLibrary
{
	namespace Algorithms
	{
		namespace CheckParenthesesParity
		{
			/**
			* Testování parity závorek.
			* Funkce testuje paritu kulatých, hranatých a složených závorek v daném matematickém výrazu, øetìzci.
			* Jinak øeèeno, funkce kontroluje zda-li je daný matematický výraz správnì uzávorkován.
			* Funkce ke své èinnosti využívá zásobník.
			*
			* @param Expr Testovaný matematický výraz
			* @return Funkce vrací true pokud je výraz správnì uzávorkován, jinak vrací false.
			*/
			bool CheckParenthesesParity1(string Expr);
			
			/**
			* Testování parity závorek.
			* Funkce testuje paritu kulatých, hranatých a složených závorek v daném matematickém výrazu, øetìzci.
			* Jinak øeèeno, funkce kontroluje zda-li je daný matematický výraz správnì uzávorkován.
			* Funkce ke své èinnosti využívá zásobník.
			*
			* @param Expr Testovaný matematický výraz
			* @return Funkce vrací true pokud je výraz správnì uzávorkován, jinak vrací false.
			*/
			bool CheckParenthesesParity2(string Expr);
		}
	}
}
