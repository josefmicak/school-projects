/**
 * @brief Hlavni soubor programu
 * @file main.cpp
 * @author Josef Micak
 * @mainpage MIC0378 - Domaci ucetnictvi
 */

#include <iostream>
#include <fstream>
#include <cstdlib>
#include <algorithm>
#include <iomanip>
#include <string>
#include "funkce.hpp"

using namespace std;

/** @fn int main()
 *  @brief Hlavni funkce, slouzi predevsim ke nacteni a kontrole vstupnich dat a k volani funkci pro naplneni pole struktury
 */
int main()
{
    ifstream souborZaznamu;
    string input;
    cout << "Zadejte nazev souboru ve formatu .csv, ktery obsahuje vami pozadovana vstupni data.\nSoubor se musi nachazet ve slozce vstupnidata, nazev souboru piste bez koncovky .csv" << endl;
    cin >> input;
    string nazevSouboru = "..\\vstupnidata\\" + input + ".csv";
    souborZaznamu.open(nazevSouboru.c_str());
    system("cls");
    char volba;
    if(souborZaznamu.is_open() == false)
    {
        cout << "Soubor s nazvem " + input + ".csv se nepodarilo najit. Prejete si do programu nyni nacist soubor se vzorovymi vstupnimi daty (Zaznamy.csv)? (Y/N)" << endl;
        cin >> volba;
        if (volba == 'Y' || volba == 'y')
        {
            input = "Zaznamy";
            souborZaznamu.close();
            souborZaznamu.open("..\\vstupnidata\\Zaznamy.csv");
            if(souborZaznamu.is_open() == false)
            {
                system("cls");
                cout << "Soubor Zaznamy.csv se nepodarilo nacist, pravdepodobne byl odstranen ze slozky vstupnidata.\nProgram se nyni ukonci." << endl;
                return 0;
            }
        }
        else if (volba == 'N' || volba == 'n')
        {
            system("cls");
            cout << "Bez zadanych vstupnich dat nemuze program fungovat.\nProgram se nyni ukonci." << endl;
            return 0;
        }
        else
        {
            system("cls");
            cout << "Nevybral jste ani jednu z nabizenych moznosti (Y/N).\nProgram se nyni ukonci." << endl;
            return 0;
        }
    }

    int pocetZaznamu = pocetRadku(souborZaznamu);

    Zaznamy *registr = new Zaznamy[pocetZaznamu];
    naplneniZaznamu(souborZaznamu, registr);

    int pocetKatZaznamu, pocetCastek, volbaMes, volbaMenu = 0, volbaSubMenu = 0, *indexy, *p;
    double prijmy, vydaje, *castky;
    bool vseZaznamy = false, mesiceZaznamy = false, kategorieZaznamy = false, konec = false, chybovaHlaska = false;
    string volbaKat;

    do
    {
        system("cls");
        Menu();
        if (chybovaHlaska == true)
        {
            system("cls");
            cout << "[Chyba] Nevybral jste zadnou z uvedenych moznosti. Zkuste to prosim znovu." << endl;
            Menu();
        }
        cin.clear();
        fflush(stdin);
        cin >> volbaMenu;

        if (cin.peek() != '\n' || cin.fail())
        {
            volbaMenu = 0;
        }
        else
        {
            chybovaHlaska = false;
        }

        switch (volbaMenu)
        {
        case 1:
            vypisZaznamu(registr, pocetZaznamu, input, prijmy, vydaje, vseZaznamy);
            break;
        case 2:
            vypisZaznamuMesic(registr, pocetZaznamu, prijmy, vydaje, indexy, volbaMes, pocetCastek, p, castky, mesiceZaznamy);
            break;
        case 3:
            vypisZaznamuKategorie(registr, pocetZaznamu, pocetKatZaznamu, prijmy, vydaje, volbaKat, kategorieZaznamy);
            break;
        default:
            chybovaHlaska = true;
            break;
        }
        if (chybovaHlaska == false)
        {
            subMenu();
            cin.clear();
            fflush(stdin);
            cin >> volbaSubMenu;

            if (cin.peek() != '\n' || cin.fail())
            {
                volbaSubMenu = 0;
            }

            switch (volbaSubMenu)
            {
            case 1:
                konec = true;
                break;
            case 2:
                if (vseZaznamy == true)
                {
                    vseZaznamy = false;
                    vseDoHTML(registr, pocetZaznamu, prijmy, vydaje, input);
                }
                else if (mesiceZaznamy == true)
                {
                    mesiceZaznamy = false;
                    mesiceDoHTML(registr, pocetZaznamu, prijmy, vydaje, volbaMes, pocetCastek, indexy, input);
                }
                else if (kategorieZaznamy == true)
                {
                    kategorieZaznamy = false;
                    kategorieDoHTML(registr, pocetZaznamu, prijmy, vydaje, volbaKat, pocetKatZaznamu, input);
                }
                else
                {
                    cout << "[Chyba] Soubor HTML neni mozne vytvorit, nejsou nactene zadne zaznamy ktere by bylo mozno vypsat." << endl;
                    cout << "Zadanim jakekoli klavesy se vratite do hlavniho menu." << endl;
                    volbaSubMenu = 0;
                    cin.clear();
                    cin.ignore(500, '\n');
                    cin.get();
                    cin.get();
                    break;
                }
            case 3:
                break;
            default:
                cout << "[Chyba] Nevybral jste zadnou z uvedenych moznosti." << endl;
                cout << "Zadanim jakekoli klavesy se vratite do hlavniho menu." << endl;
                volbaSubMenu = 0;
                cin.clear();
                cin.ignore(500, '\n');
                cin.get();
                cin.get();
                break;
            }
        }

    } while (konec == false);

    delete[] registr;
    registr = nullptr;

    souborZaznamu.close();
    return 0;
}
