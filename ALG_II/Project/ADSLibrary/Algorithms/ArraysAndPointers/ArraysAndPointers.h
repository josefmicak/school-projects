#pragma once

#include <iostream>
#include <iomanip>

using namespace std;

namespace ADSLibrary
{
	namespace Algorithms
	{
		namespace ArraysAndPointers
		{
			/**
			 * Inicializace hodnot v poli.
			 * Hodnoty v poli jsou pouze demonstrační, nemají žádný hlubší význam.
			 *
			 * @param a Pole do kterého se budou ukládat hodnoty
			 * @param N Počet prvků v poli
			 */
			void InitArray(int* a, const int N);

			/**
			 * Změna hodnot prvků pole.
			 * Změna hodnot v poli je pouze demonstrační.
			 * Účelem je změnit hodnoty v poli při demonstraci kopírování hodnot.
			 *
			 * @param a Pole, kde budeme měnit hodnoty.
			 * @param N Počet prvků v poli
			 */
			void UpdateArray(int* a, const int N);

			/**
			 * Tisk pole na standardní výstup.
			 * Pole je předáváno jako ukazatel, přesněji řečeno jako ukazatel na první prvek pole.
			 *
			 * @param a Tisknuté pole
			 * @param N Počet prvků v poli
			 */
			void PrintArray1(const int* a, const int N);

			/**
			 * Tisk pole na standardní výstup.
			 * Pole je předáváno způsobem obvyklým v C++.
			 *
			 * @param a Tisknuté pole
			 * @param N Počet prvků v poli
			 */
			void PrintArray2(const int a[], const int N);

			/**
			 * Tisk pole na standardní výstup.
			 * Pole je předáváno jako ukazatel, přesněji řečeno jako ukazatel na první prvek pole.
			 * Zpracování pole probíhá pomocí pointerové aritmetiky.
			 *
			 * @param a Tisknuté pole
			 * @param N Počet prvků v poli
			 */
			void PrintArray3(const int* a, const int N);

			/**
			 * Kopírování hodnot z pole SourceArray do pole DestinationArray.
			 * Obě pole jsou předávána jako ukazatelé, přesněji řečeno jako ukazatelé na jejich první prvky.
			 * Kopírování probíhá pomocí běžného indexování pole.
			 *
			 * @param SourceArray Zdrojové pole, čili "odkud"
			 * @param DestinationArray Cílové pole, čili "kam"
			 * @param N Počet prvků v poli SourceArray
			 */
			void CopyArray1(const int* SourceArray, int* DestinationArray, const int N);

			/**
			 * Kopírování hodnot z pole SourceArray do pole DestinationArray.
			 * Obě pole jsou předávána jako ukazatelé, přesněji řečeno jako ukazatelé na jejich první prvky.
			 * Kopírování probíhá pomocí pointerové artimetiky.
			 *
			 * @param SourceArray Zdrojové pole, čili "odkud"
			 * @param DestinationArray Cílové pole, čili "kam"
			 * @param N Počet prvků v poli SourceArray
			 */
			void CopyArray2(const int* SourceArray, int* DestinationArray, const int N);

			/**
			 * Kopírování hodnot z pole SourceArray do pole DestinationArray.
			 * Obě pole jsou předávána jako ukazatelé, přesněji řečeno jako ukazatelé na jejich první prvky.
			 * Kopírování probíhá pomocí pointerové aritmetiky.
			 *
			 * Zápis pointerové aritmetiky je v maximální míře zhuštěn,
			 * je využito všech dostupných možností zápisu kódu v C++.
			 * Tento způsob zápisu algoritmu je zcela nevhodný pro začátečníky. Uvádím ho zde dvou důvodů -
			 * jednak pro úplnost (že je možný i takový zápis algoritmu) a jednak jako hlavolam...
			 *
			 * @param SourceArray Zdrojové pole, čili "odkud"
			 * @param DestinationArray Cílové pole, čili "kam"
			 * @param N Počet prvků v poli SourceArray
			 */
			void CopyArray2a(const int* SourceArray, int* DestinationArray, const int N);

			/**
			 * Funkce demonstrující práci s jednorozměrným polem.
			 */
			void DemoArray();

			/**
			* Funkce demonstrující práci s jednorozměrným dynamicky alokovaným polem.
			*/
			void DemoArrayDynamic();

			/**
			 * Počet řádků dvourozměrného pole.
			 */
			const int RowNumber = 4;

			/**
			 * Počet sloupců dvourozměrného pole.
			 */
			const int ColumnNumber = 5;

			/**
			 * Alokace dvourozměrného pole. C++ zná jen jednorozměrné pole, dvou a vícerozměrné pole je nutné deklarovat jako pole pointerů na další subpole.
			 * Takže dvourozměrné pole dynamicky alokované je pointer na pole jehož prvky jsou pointery na požadovaný datový typ, čili dvojnásobný pointer, **.
			 *
			 * @param R Počet řádků alokovaného dvourozměrného pole
			 * @param C Počet sloupců alokovaného dvourozměrného pole
			 * @return Pointer na dvourozměrného pole
			 */
			double** AllocateMatrix(const int R, const int C);

			/**
			 * Dealokace dvourozměrného pole. Pole je postupně dealokováno po řádcích. Délku řádků tohoto pole, tj. počet sloupců, není nutné uvádět,
			 * protože dealokace řádků matice je provedena pomocí operátoru delete[]. Správce paměti v tomto případě ví, kolik každý řádek zabírá paměti.
			 *
			 * @param M Dynamicky alokované dvourozměrného pole
			 * @param R Počet řádků dvourozměrného pole.
			 */
			void DeallocateMatrix(double** M, const int R);

			/**
			 * Naplnění dvourozměrného pole testovacími daty.
			 *
			 * @param M Dynamicky alokované dvourozměrného pole
			 * @param R Počet řádků dvourozměrného pole
			 * @param C Počet sloupců dvourozměrného pole
			 */
			void FillMatrix(double** M, const int R, const int C);

			/**
			 * Tisk dvourozměrného pole na standardní výstup.
			 *
			 * @param M Dynamicky alokované dvourozměrného pole
			 * @param R Počet řádků dvourozměrného pole
			 * @param C Počet sloupců dvourozměrného pole
			 */
			void PrintMatrix(const double** M, const int R, const int C);
		}
	}
}
