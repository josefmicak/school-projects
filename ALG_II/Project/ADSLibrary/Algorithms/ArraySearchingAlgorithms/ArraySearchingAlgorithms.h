#pragma once

namespace ADSLibrary
{
	namespace Algorithms
	{
		namespace ArraySearchingAlgorithms
		{
			/**
			* Hledání prvku v poli.
			*
			* Funkce testuje prostou přítomnost či nepřítomnost hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje iterační algoritmus lineárního vyhledávání. Složitost tohoto algoritmu je O(N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param n Délka prohledávaného pole
			* @param x Hledaný prvek
			* @return Funkce vrací true pokud se prvek hledaný prvek nachází v daném poli, jinak false.
			*/
			bool LinearSearch1(const int a[], const int n, const int x);


			/**
			* Hledání prvku v poli.
			*
			* Funkce hledá první výskyt hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje iterační algoritmus lineárního vyhledávání. Složitost tohoto algoritmu je O(N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param n Délka prohledávaného pole
			* @param x Hledaný prvek
			* @return Funkce vrací index prvního výskytu hledaného prvku v daném poli, jinak vrací -1.
			*/
			int LinearSearch2(const int a[], const int n, const int x);


			/**
			* Hledání prvku v poli.
			*
			* Funkce testuje prostou přítomnost či nepřítomnost hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje rekurzivní algoritmus lineárního vyhledávání. Složitost tohoto algoritmu je O(N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param n Délka prohledávaného pole
			* @param x Hledaný prvek
			* @param i Aktuálně zkoumaný index v poli. Při volání funkce je nutno tento parametr nastavit na 0.
			* @return Funkce vrací true pokud se hledaný prvek nachází v daném poli, jinak false.
			*/
			bool LinearSearchRecursive1(const int a[], const int n, const int x, const int i);


			/**
			* Hledání prvku v poli.
			*
			* Funkce hledá první výskyt hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje rekurzivní algoritmus lineárního vyhledávání. Složitost tohoto algoritmu je O(N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param n Délka prohledávaného pole
			* @param x Hledaný prvek
			* @param i Aktuálně zkoumaný index v poli. Při volání funkce je nutno tento parametr nastavit na 0.
			* @return Funkce vrací index prvního výskytu hledaného prvku v daném poli, jinak vrací -1.
			*/
			int LinearSearchRecursive2(const int a[], const int n, const int x, const int i);


			/**
			* Hledání prvku v poli.
			*
			* Funkce hledá první výskyt hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje odlišnou variantu rekurzivního algoritmu lineárního vyhledávání.
			* Složitost tohoto algoritmu je O(N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param l Levá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na 0.
			* @param r Pravá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na N-1, kde N je počet prvků v poli.
			* @param x Hledaný prvek
			* @return Funkce vrací true pokud se hledaný prvek nachází v daném poli, jinak false.
			*/
			bool LinearSearchRecursive3(const int a[], const int l, const int r, const int x);


			/**
			* Hledání prvku v poli.
			*
			* Funkce hledá první výskyt hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje odlišnou variantu rekurzivního algoritmu lineárního vyhledávání.
			* Složitost tohoto algoritmu je O(N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param l Levá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na 0.
			* @param r Pravá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na N-1, kde N je počet prvků v poli.
			* @param x Hledaný prvek
			* @return Funkce vrací true pokud se hledaný prvek nachází v daném poli, jinak false.
			*/
			bool LinearSearchRecursive4(const int a[], const int l, const int r, const int x);


			/**
			* Hledání prvku ve vzestupně setříděném poli.
			*
			* Funkce testuje prostou přítomnost či nepřítomnost hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje algoritmus vyhledávání půlením intervalu. Složitost tohoto algoritmu je O(log_{2}N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param n Délka prohledávaného pole
			* @param x Hledaný prvek
			* @return Funkce vrací true pokud se hledaný prvek nachází v daném poli, jinak false.
			*/
			bool BinarySearch1(const int a[], const int n, const int x);


			/**
			* Hledání prvku ve vzestupně setříděném poli.
			*
			* Funkce testuje prostou přítomnost či nepřítomnost hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje algoritmus vyhledávání půlením intervalu. Složitost tohoto algoritmu je O(log_{2}N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param n Délka prohledávaného pole
			* @param x Hledaný prvek
			* @return Funkce vrací index výskytu hledaného prvku v daném poli, jinak vrací -1.
			*/
			int BinarySearch2(const int a[], const int n, const int x);


			/**
			* Hledání prvku ve vzestupně setříděném poli.
			*
			* Funkce testuje prostou přítomnost či nepřítomnost hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje algoritmus vyhledávání půlením intervalu. Složitost tohoto algoritmu je O(log_{2}N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param n Délka prohledávaného pole
			* @param x Hledaný prvek
			* @return Funkce vrací index výskytu hledaného prvku v daném poli. Pokud se hledaný prvek v daném poli nenachází, vrací funkce záporné číslo
			* jehož bitový doplněk udává pozici na kterou je případně možné hledaný prvek do pole vložit tak, aby bylo zachováno vzestupné uspořádání daného pole.
			*/
			int BinarySearch3(const int a[], const int n, const int x);


			/**
			* Hledání prvku ve vzestupně setříděném poli.
			*
			* Funkce testuje prostou přítomnost či nepřítomnost hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje algoritmus vyhledávání půlením intervalu pomocí rekurze. Složitost tohoto algoritmu je O(log_{2}N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param l Levá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na 0.
			* @param r Pravá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na N-1, kde N je počet prvků v poli.
			* @param x Hledaný prvek
			* @return Funkce vrací true pokud se hledaný prvek nachází v daném poli, jinak false.
			*/
			bool BinarySearchRecursive1(const int a[], const int l, const int r, const int x);


			/**
			* Hledání prvku ve vzestupně setříděném poli.
			*
			* Funkce testuje prostou přítomnost či nepřítomnost hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje algoritmus vyhledávání půlením intervalu pomocí rekurze. Složitost tohoto algoritmu je O(log_{2}N), kde N je počet prvků v poli.
			* Funkce demonstruje implementaci rekurzívního volání pomocí ternárního operátoru.
			*
			* @param a Prohledávané pole
			* @param l Levá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na 0.
			* @param r Pravá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na N-1, kde N je počet prvků v poli.
			* @param x Hledaný prvek
			* @return Funkce vrací true pokud se hledaný prvek nachází v daném poli, jinak false.
			*/
			bool BinarySearchRecursive1a(const int a[], const int l, const int r, const int x);


			/**
			* Hledání prvku ve vzestupně setříděném poli.
			*
			* Funkce testuje prostou přítomnost či nepřítomnost hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje algoritmus vyhledávání půlením intervalu pomocí rekurze. Složitost tohoto algoritmu je O(log_{2}N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param l Levá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na 0.
			* @param r Pravá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na N-1, kde N je počet prvků v poli.
			* @param x Hledaný prvek
			* @return Funkce vrací index výskytu hledaného prvku v daném poli, jinak vrací -1.
			*/
			int BinarySearchRecursive2(const int a[], const int l, const int r, const int x);


			/**
			* Hledání prvku ve vzestupně setříděném poli.
			*
			* Funkce testuje prostou přítomnost či nepřítomnost hledaného prvku v daném poli.
			* Funkce nezkoumá počet všech výskytů hledaného prvku v poli ani případné indexy všech jeho výskytů.
			* Funkce implementuje algoritmus vyhledávání půlením intervalu pomocí rekurze. Složitost tohoto algoritmu je O(log_{2}N), kde N je počet prvků v poli.
			*
			* @param a Prohledávané pole
			* @param l Levá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na 0.
			* @param r Pravá mez prohledávaného úseku pole, inkluzivní. Při počátečním volání funkce nastavit tento parametr na N-1, kde N je počet prvků v poli.
			* @param x Hledaný prvek
			* @return Funkce vrací index výskytu hledaného prvku v daném poli. Pokud se hledaný prvek v daném poli nenachází, vrací funkce záporné číslo
			* jehož bitový doplněk udává pozici na kterou je případně možné hledaný prvek do pole vložit tak, aby bylo zachováno vzestupné uspořádání daného pole.
			*/
			int BinarySearchRecursive3(const int a[], const int l, const int r, const int x);
		}
	}
}
