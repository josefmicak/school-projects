/********************************************************************************
** Form generated from reading UI file 'restaurace.ui'
**
** Created by: Qt User Interface Compiler version 5.14.2
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_RESTAURACE_H
#define UI_RESTAURACE_H

#include <QtCore/QVariant>
#include <QtWidgets/QApplication>
#include <QtWidgets/QGroupBox>
#include <QtWidgets/QLabel>
#include <QtWidgets/QLineEdit>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QRadioButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QTabWidget>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_Restaurace
{
public:
    QWidget *centralwidget;
    QTabWidget *tabWidget;
    QWidget *tab;
    QGroupBox *pridatZam;
    QLabel *jmenoZamL;
    QLabel *prijmeniZamL;
    QLabel *pohlaviZamL;
    QLabel *datumNarZamL;
    QLabel *datumFormatL;
    QLabel *adresaZamL;
    QLabel *emailZamL;
    QLabel *telefonZamL;
    QLabel *datumNasZamL;
    QLabel *datumFormat2;
    QLineEdit *jmenoZamB;
    QLineEdit *prijmeniZamB;
    QRadioButton *pohlaviZamRB1;
    QRadioButton *pohlaviZamRB2;
    QLineEdit *datumNarZamBD;
    QLineEdit *datumNarZamBM;
    QLineEdit *datumNarZamBR;
    QLineEdit *adresaZamB;
    QLineEdit *emailZamB;
    QLineEdit *telefonZamB;
    QLineEdit *datumNasZamBM;
    QLineEdit *datumNasZamBR;
    QLineEdit *datumNasZamBD;
    QPushButton *pridatZamBut1;
    QPushButton *pridatZamBut2;
    QGroupBox *odebratZam;
    QLabel *idZamL;
    QLineEdit *idZamB;
    QPushButton *odebratZamBut1;
    QPushButton *odebratZamBut2;
    QPushButton *vyhledatZamBut;
    QPushButton *odebratVsechZamBut;
    QPushButton *potvrditZmenyBut;
    QPushButton *zrusitBut;
    QWidget *tab_2;
    QPushButton *vyhledatObjBut;
    QPushButton *odebratVsechObjBut;
    QPushButton *potvrditZmenyBut_2;
    QGroupBox *pridatObj;
    QLabel *jmenoZakL;
    QLabel *prijmeniZakL;
    QLabel *adresaZakL;
    QLabel *cenaL;
    QLabel *telefonZakL;
    QLineEdit *jmenoZamB_2;
    QLineEdit *prijmeniZamB_2;
    QLineEdit *adresaZakB;
    QLineEdit *cenaObjB;
    QLineEdit *telefonZamB_2;
    QPushButton *pridatObjBut1;
    QPushButton *pridatObjBut2;
    QLineEdit *datumVytvoreniBR;
    QLineEdit *datumVytvoreniBM;
    QLabel *datumVytvoreniL;
    QLabel *datumFormatL_2;
    QLineEdit *datumVytvoreniBD;
    QLabel *menaL;
    QPushButton *zrusitBut_2;
    QGroupBox *odebratObj;
    QLabel *idObjL;
    QLineEdit *idObjB;
    QPushButton *odebratObjBut1;
    QPushButton *odebratObjBut2;
    QWidget *tab_3;
    QPushButton *vyhledatVozBut;
    QGroupBox *pridatVoz;
    QLabel *modelL;
    QLabel *SPZL;
    QLabel *obejmKufruL;
    QLineEdit *modelB;
    QLineEdit *SPZB;
    QLineEdit *objemKufruB;
    QPushButton *pridatVozBut1;
    QPushButton *pridatVozBut2;
    QLineEdit *datumVytvoreniBR_3;
    QLineEdit *datumVytvoreniBM_3;
    QLabel *datumVytvoreniL_3;
    QLabel *datumFormatL_4;
    QLineEdit *datumVytvoreniBD_3;
    QLineEdit *cenaVozB;
    QLabel *cenaL_3;
    QLabel *menaL_3;
    QPushButton *zrusitBut_3;
    QPushButton *potvrditZmenyBut_3;
    QGroupBox *odebratVoz;
    QLabel *idVozL;
    QLineEdit *idVozB;
    QPushButton *odebratObjBut1_3;
    QPushButton *odebratObjBut2_3;
    QPushButton *odebratVsechVozBut;
    QMenuBar *menubar;
    QStatusBar *statusbar;

    void setupUi(QMainWindow *Restaurace)
    {
        if (Restaurace->objectName().isEmpty())
            Restaurace->setObjectName(QString::fromUtf8("Restaurace"));
        Restaurace->resize(538, 482);
        centralwidget = new QWidget(Restaurace);
        centralwidget->setObjectName(QString::fromUtf8("centralwidget"));
        tabWidget = new QTabWidget(centralwidget);
        tabWidget->setObjectName(QString::fromUtf8("tabWidget"));
        tabWidget->setGeometry(QRect(0, 0, 541, 441));
        tab = new QWidget();
        tab->setObjectName(QString::fromUtf8("tab"));
        pridatZam = new QGroupBox(tab);
        pridatZam->setObjectName(QString::fromUtf8("pridatZam"));
        pridatZam->setGeometry(QRect(0, 10, 281, 371));
        jmenoZamL = new QLabel(pridatZam);
        jmenoZamL->setObjectName(QString::fromUtf8("jmenoZamL"));
        jmenoZamL->setGeometry(QRect(10, 30, 47, 20));
        prijmeniZamL = new QLabel(pridatZam);
        prijmeniZamL->setObjectName(QString::fromUtf8("prijmeniZamL"));
        prijmeniZamL->setGeometry(QRect(10, 65, 37, 13));
        pohlaviZamL = new QLabel(pridatZam);
        pohlaviZamL->setObjectName(QString::fromUtf8("pohlaviZamL"));
        pohlaviZamL->setGeometry(QRect(10, 100, 47, 13));
        datumNarZamL = new QLabel(pridatZam);
        datumNarZamL->setObjectName(QString::fromUtf8("datumNarZamL"));
        datumNarZamL->setGeometry(QRect(10, 135, 81, 16));
        datumFormatL = new QLabel(pridatZam);
        datumFormatL->setObjectName(QString::fromUtf8("datumFormatL"));
        datumFormatL->setGeometry(QRect(10, 150, 91, 16));
        adresaZamL = new QLabel(pridatZam);
        adresaZamL->setObjectName(QString::fromUtf8("adresaZamL"));
        adresaZamL->setGeometry(QRect(10, 185, 47, 13));
        emailZamL = new QLabel(pridatZam);
        emailZamL->setObjectName(QString::fromUtf8("emailZamL"));
        emailZamL->setGeometry(QRect(10, 220, 47, 13));
        telefonZamL = new QLabel(pridatZam);
        telefonZamL->setObjectName(QString::fromUtf8("telefonZamL"));
        telefonZamL->setGeometry(QRect(10, 255, 47, 13));
        datumNasZamL = new QLabel(pridatZam);
        datumNasZamL->setObjectName(QString::fromUtf8("datumNasZamL"));
        datumNasZamL->setGeometry(QRect(10, 290, 81, 16));
        datumFormat2 = new QLabel(pridatZam);
        datumFormat2->setObjectName(QString::fromUtf8("datumFormat2"));
        datumFormat2->setGeometry(QRect(10, 305, 101, 16));
        jmenoZamB = new QLineEdit(pridatZam);
        jmenoZamB->setObjectName(QString::fromUtf8("jmenoZamB"));
        jmenoZamB->setGeometry(QRect(110, 30, 113, 20));
        prijmeniZamB = new QLineEdit(pridatZam);
        prijmeniZamB->setObjectName(QString::fromUtf8("prijmeniZamB"));
        prijmeniZamB->setGeometry(QRect(110, 65, 113, 20));
        pohlaviZamRB1 = new QRadioButton(pridatZam);
        pohlaviZamRB1->setObjectName(QString::fromUtf8("pohlaviZamRB1"));
        pohlaviZamRB1->setGeometry(QRect(110, 97, 41, 17));
        pohlaviZamRB2 = new QRadioButton(pridatZam);
        pohlaviZamRB2->setObjectName(QString::fromUtf8("pohlaviZamRB2"));
        pohlaviZamRB2->setGeometry(QRect(170, 97, 51, 17));
        datumNarZamBD = new QLineEdit(pridatZam);
        datumNarZamBD->setObjectName(QString::fromUtf8("datumNarZamBD"));
        datumNarZamBD->setGeometry(QRect(110, 135, 25, 20));
        datumNarZamBM = new QLineEdit(pridatZam);
        datumNarZamBM->setObjectName(QString::fromUtf8("datumNarZamBM"));
        datumNarZamBM->setGeometry(QRect(140, 135, 25, 20));
        datumNarZamBR = new QLineEdit(pridatZam);
        datumNarZamBR->setObjectName(QString::fromUtf8("datumNarZamBR"));
        datumNarZamBR->setGeometry(QRect(170, 135, 50, 20));
        adresaZamB = new QLineEdit(pridatZam);
        adresaZamB->setObjectName(QString::fromUtf8("adresaZamB"));
        adresaZamB->setGeometry(QRect(110, 180, 161, 20));
        emailZamB = new QLineEdit(pridatZam);
        emailZamB->setObjectName(QString::fromUtf8("emailZamB"));
        emailZamB->setGeometry(QRect(110, 215, 161, 20));
        telefonZamB = new QLineEdit(pridatZam);
        telefonZamB->setObjectName(QString::fromUtf8("telefonZamB"));
        telefonZamB->setGeometry(QRect(110, 250, 113, 20));
        datumNasZamBM = new QLineEdit(pridatZam);
        datumNasZamBM->setObjectName(QString::fromUtf8("datumNasZamBM"));
        datumNasZamBM->setGeometry(QRect(140, 290, 25, 20));
        datumNasZamBR = new QLineEdit(pridatZam);
        datumNasZamBR->setObjectName(QString::fromUtf8("datumNasZamBR"));
        datumNasZamBR->setGeometry(QRect(170, 290, 50, 20));
        datumNasZamBD = new QLineEdit(pridatZam);
        datumNasZamBD->setObjectName(QString::fromUtf8("datumNasZamBD"));
        datumNasZamBD->setGeometry(QRect(110, 290, 25, 20));
        pridatZamBut1 = new QPushButton(pridatZam);
        pridatZamBut1->setObjectName(QString::fromUtf8("pridatZamBut1"));
        pridatZamBut1->setGeometry(QRect(60, 340, 75, 23));
        pridatZamBut2 = new QPushButton(pridatZam);
        pridatZamBut2->setObjectName(QString::fromUtf8("pridatZamBut2"));
        pridatZamBut2->setGeometry(QRect(140, 340, 75, 23));
        odebratZam = new QGroupBox(tab);
        odebratZam->setObjectName(QString::fromUtf8("odebratZam"));
        odebratZam->setGeometry(QRect(290, 10, 241, 91));
        idZamL = new QLabel(odebratZam);
        idZamL->setObjectName(QString::fromUtf8("idZamL"));
        idZamL->setGeometry(QRect(10, 30, 81, 16));
        idZamB = new QLineEdit(odebratZam);
        idZamB->setObjectName(QString::fromUtf8("idZamB"));
        idZamB->setGeometry(QRect(110, 30, 113, 20));
        odebratZamBut1 = new QPushButton(odebratZam);
        odebratZamBut1->setObjectName(QString::fromUtf8("odebratZamBut1"));
        odebratZamBut1->setGeometry(QRect(40, 60, 75, 23));
        odebratZamBut2 = new QPushButton(odebratZam);
        odebratZamBut2->setObjectName(QString::fromUtf8("odebratZamBut2"));
        odebratZamBut2->setGeometry(QRect(120, 60, 75, 23));
        vyhledatZamBut = new QPushButton(tab);
        vyhledatZamBut->setObjectName(QString::fromUtf8("vyhledatZamBut"));
        vyhledatZamBut->setGeometry(QRect(335, 130, 161, 23));
        odebratVsechZamBut = new QPushButton(tab);
        odebratVsechZamBut->setObjectName(QString::fromUtf8("odebratVsechZamBut"));
        odebratVsechZamBut->setGeometry(QRect(320, 170, 191, 23));
        potvrditZmenyBut = new QPushButton(tab);
        potvrditZmenyBut->setObjectName(QString::fromUtf8("potvrditZmenyBut"));
        potvrditZmenyBut->setGeometry(QRect(170, 390, 101, 23));
        zrusitBut = new QPushButton(tab);
        zrusitBut->setObjectName(QString::fromUtf8("zrusitBut"));
        zrusitBut->setGeometry(QRect(280, 390, 75, 23));
        tabWidget->addTab(tab, QString());
        tab_2 = new QWidget();
        tab_2->setObjectName(QString::fromUtf8("tab_2"));
        vyhledatObjBut = new QPushButton(tab_2);
        vyhledatObjBut->setObjectName(QString::fromUtf8("vyhledatObjBut"));
        vyhledatObjBut->setGeometry(QRect(335, 130, 161, 23));
        odebratVsechObjBut = new QPushButton(tab_2);
        odebratVsechObjBut->setObjectName(QString::fromUtf8("odebratVsechObjBut"));
        odebratVsechObjBut->setGeometry(QRect(320, 170, 191, 23));
        potvrditZmenyBut_2 = new QPushButton(tab_2);
        potvrditZmenyBut_2->setObjectName(QString::fromUtf8("potvrditZmenyBut_2"));
        potvrditZmenyBut_2->setGeometry(QRect(170, 390, 101, 23));
        pridatObj = new QGroupBox(tab_2);
        pridatObj->setObjectName(QString::fromUtf8("pridatObj"));
        pridatObj->setGeometry(QRect(0, 10, 281, 291));
        jmenoZakL = new QLabel(pridatObj);
        jmenoZakL->setObjectName(QString::fromUtf8("jmenoZakL"));
        jmenoZakL->setGeometry(QRect(10, 30, 61, 20));
        prijmeniZakL = new QLabel(pridatObj);
        prijmeniZakL->setObjectName(QString::fromUtf8("prijmeniZakL"));
        prijmeniZakL->setGeometry(QRect(10, 65, 61, 16));
        adresaZakL = new QLabel(pridatObj);
        adresaZakL->setObjectName(QString::fromUtf8("adresaZakL"));
        adresaZakL->setGeometry(QRect(10, 100, 71, 16));
        cenaL = new QLabel(pridatObj);
        cenaL->setObjectName(QString::fromUtf8("cenaL"));
        cenaL->setGeometry(QRect(10, 220, 47, 13));
        telefonZakL = new QLabel(pridatObj);
        telefonZakL->setObjectName(QString::fromUtf8("telefonZakL"));
        telefonZakL->setGeometry(QRect(10, 135, 71, 16));
        jmenoZamB_2 = new QLineEdit(pridatObj);
        jmenoZamB_2->setObjectName(QString::fromUtf8("jmenoZamB_2"));
        jmenoZamB_2->setGeometry(QRect(110, 30, 113, 20));
        prijmeniZamB_2 = new QLineEdit(pridatObj);
        prijmeniZamB_2->setObjectName(QString::fromUtf8("prijmeniZamB_2"));
        prijmeniZamB_2->setGeometry(QRect(110, 62, 113, 20));
        adresaZakB = new QLineEdit(pridatObj);
        adresaZakB->setObjectName(QString::fromUtf8("adresaZakB"));
        adresaZakB->setGeometry(QRect(110, 97, 161, 20));
        cenaObjB = new QLineEdit(pridatObj);
        cenaObjB->setObjectName(QString::fromUtf8("cenaObjB"));
        cenaObjB->setGeometry(QRect(110, 215, 111, 20));
        telefonZamB_2 = new QLineEdit(pridatObj);
        telefonZamB_2->setObjectName(QString::fromUtf8("telefonZamB_2"));
        telefonZamB_2->setGeometry(QRect(110, 132, 113, 20));
        pridatObjBut1 = new QPushButton(pridatObj);
        pridatObjBut1->setObjectName(QString::fromUtf8("pridatObjBut1"));
        pridatObjBut1->setGeometry(QRect(60, 260, 75, 23));
        pridatObjBut2 = new QPushButton(pridatObj);
        pridatObjBut2->setObjectName(QString::fromUtf8("pridatObjBut2"));
        pridatObjBut2->setGeometry(QRect(140, 260, 75, 23));
        datumVytvoreniBR = new QLineEdit(pridatObj);
        datumVytvoreniBR->setObjectName(QString::fromUtf8("datumVytvoreniBR"));
        datumVytvoreniBR->setGeometry(QRect(170, 167, 50, 20));
        datumVytvoreniBM = new QLineEdit(pridatObj);
        datumVytvoreniBM->setObjectName(QString::fromUtf8("datumVytvoreniBM"));
        datumVytvoreniBM->setGeometry(QRect(140, 167, 25, 20));
        datumVytvoreniL = new QLabel(pridatObj);
        datumVytvoreniL->setObjectName(QString::fromUtf8("datumVytvoreniL"));
        datumVytvoreniL->setGeometry(QRect(10, 170, 81, 16));
        datumFormatL_2 = new QLabel(pridatObj);
        datumFormatL_2->setObjectName(QString::fromUtf8("datumFormatL_2"));
        datumFormatL_2->setGeometry(QRect(10, 185, 91, 16));
        datumVytvoreniBD = new QLineEdit(pridatObj);
        datumVytvoreniBD->setObjectName(QString::fromUtf8("datumVytvoreniBD"));
        datumVytvoreniBD->setGeometry(QRect(110, 167, 25, 20));
        menaL = new QLabel(pridatObj);
        menaL->setObjectName(QString::fromUtf8("menaL"));
        menaL->setGeometry(QRect(230, 217, 21, 16));
        zrusitBut_2 = new QPushButton(tab_2);
        zrusitBut_2->setObjectName(QString::fromUtf8("zrusitBut_2"));
        zrusitBut_2->setGeometry(QRect(280, 390, 75, 23));
        odebratObj = new QGroupBox(tab_2);
        odebratObj->setObjectName(QString::fromUtf8("odebratObj"));
        odebratObj->setGeometry(QRect(290, 10, 241, 91));
        idObjL = new QLabel(odebratObj);
        idObjL->setObjectName(QString::fromUtf8("idObjL"));
        idObjL->setGeometry(QRect(10, 30, 81, 16));
        idObjB = new QLineEdit(odebratObj);
        idObjB->setObjectName(QString::fromUtf8("idObjB"));
        idObjB->setGeometry(QRect(110, 30, 113, 20));
        odebratObjBut1 = new QPushButton(odebratObj);
        odebratObjBut1->setObjectName(QString::fromUtf8("odebratObjBut1"));
        odebratObjBut1->setGeometry(QRect(40, 60, 75, 23));
        odebratObjBut2 = new QPushButton(odebratObj);
        odebratObjBut2->setObjectName(QString::fromUtf8("odebratObjBut2"));
        odebratObjBut2->setGeometry(QRect(120, 60, 75, 23));
        tabWidget->addTab(tab_2, QString());
        tab_3 = new QWidget();
        tab_3->setObjectName(QString::fromUtf8("tab_3"));
        vyhledatVozBut = new QPushButton(tab_3);
        vyhledatVozBut->setObjectName(QString::fromUtf8("vyhledatVozBut"));
        vyhledatVozBut->setGeometry(QRect(335, 130, 161, 23));
        pridatVoz = new QGroupBox(tab_3);
        pridatVoz->setObjectName(QString::fromUtf8("pridatVoz"));
        pridatVoz->setGeometry(QRect(0, 10, 281, 251));
        modelL = new QLabel(pridatVoz);
        modelL->setObjectName(QString::fromUtf8("modelL"));
        modelL->setGeometry(QRect(10, 30, 61, 20));
        SPZL = new QLabel(pridatVoz);
        SPZL->setObjectName(QString::fromUtf8("SPZL"));
        SPZL->setGeometry(QRect(10, 65, 61, 16));
        obejmKufruL = new QLabel(pridatVoz);
        obejmKufruL->setObjectName(QString::fromUtf8("obejmKufruL"));
        obejmKufruL->setGeometry(QRect(10, 155, 61, 16));
        modelB = new QLineEdit(pridatVoz);
        modelB->setObjectName(QString::fromUtf8("modelB"));
        modelB->setGeometry(QRect(110, 30, 161, 20));
        SPZB = new QLineEdit(pridatVoz);
        SPZB->setObjectName(QString::fromUtf8("SPZB"));
        SPZB->setGeometry(QRect(110, 62, 113, 20));
        objemKufruB = new QLineEdit(pridatVoz);
        objemKufruB->setObjectName(QString::fromUtf8("objemKufruB"));
        objemKufruB->setGeometry(QRect(110, 152, 111, 20));
        pridatVozBut1 = new QPushButton(pridatVoz);
        pridatVozBut1->setObjectName(QString::fromUtf8("pridatVozBut1"));
        pridatVozBut1->setGeometry(QRect(60, 220, 75, 23));
        pridatVozBut2 = new QPushButton(pridatVoz);
        pridatVozBut2->setObjectName(QString::fromUtf8("pridatVozBut2"));
        pridatVozBut2->setGeometry(QRect(140, 220, 75, 23));
        datumVytvoreniBR_3 = new QLineEdit(pridatVoz);
        datumVytvoreniBR_3->setObjectName(QString::fromUtf8("datumVytvoreniBR_3"));
        datumVytvoreniBR_3->setGeometry(QRect(170, 97, 50, 20));
        datumVytvoreniBM_3 = new QLineEdit(pridatVoz);
        datumVytvoreniBM_3->setObjectName(QString::fromUtf8("datumVytvoreniBM_3"));
        datumVytvoreniBM_3->setGeometry(QRect(140, 97, 25, 20));
        datumVytvoreniL_3 = new QLabel(pridatVoz);
        datumVytvoreniL_3->setObjectName(QString::fromUtf8("datumVytvoreniL_3"));
        datumVytvoreniL_3->setGeometry(QRect(10, 100, 81, 16));
        datumFormatL_4 = new QLabel(pridatVoz);
        datumFormatL_4->setObjectName(QString::fromUtf8("datumFormatL_4"));
        datumFormatL_4->setGeometry(QRect(10, 120, 91, 16));
        datumVytvoreniBD_3 = new QLineEdit(pridatVoz);
        datumVytvoreniBD_3->setObjectName(QString::fromUtf8("datumVytvoreniBD_3"));
        datumVytvoreniBD_3->setGeometry(QRect(110, 97, 25, 20));
        cenaVozB = new QLineEdit(pridatVoz);
        cenaVozB->setObjectName(QString::fromUtf8("cenaVozB"));
        cenaVozB->setGeometry(QRect(110, 187, 111, 20));
        cenaL_3 = new QLabel(pridatVoz);
        cenaL_3->setObjectName(QString::fromUtf8("cenaL_3"));
        cenaL_3->setGeometry(QRect(10, 190, 47, 13));
        menaL_3 = new QLabel(pridatVoz);
        menaL_3->setObjectName(QString::fromUtf8("menaL_3"));
        menaL_3->setGeometry(QRect(230, 190, 21, 16));
        zrusitBut_3 = new QPushButton(tab_3);
        zrusitBut_3->setObjectName(QString::fromUtf8("zrusitBut_3"));
        zrusitBut_3->setGeometry(QRect(280, 390, 75, 23));
        potvrditZmenyBut_3 = new QPushButton(tab_3);
        potvrditZmenyBut_3->setObjectName(QString::fromUtf8("potvrditZmenyBut_3"));
        potvrditZmenyBut_3->setGeometry(QRect(170, 390, 101, 23));
        odebratVoz = new QGroupBox(tab_3);
        odebratVoz->setObjectName(QString::fromUtf8("odebratVoz"));
        odebratVoz->setGeometry(QRect(290, 10, 241, 91));
        idVozL = new QLabel(odebratVoz);
        idVozL->setObjectName(QString::fromUtf8("idVozL"));
        idVozL->setGeometry(QRect(10, 30, 81, 16));
        idVozB = new QLineEdit(odebratVoz);
        idVozB->setObjectName(QString::fromUtf8("idVozB"));
        idVozB->setGeometry(QRect(110, 30, 113, 20));
        odebratObjBut1_3 = new QPushButton(odebratVoz);
        odebratObjBut1_3->setObjectName(QString::fromUtf8("odebratObjBut1_3"));
        odebratObjBut1_3->setGeometry(QRect(40, 60, 75, 23));
        odebratObjBut2_3 = new QPushButton(odebratVoz);
        odebratObjBut2_3->setObjectName(QString::fromUtf8("odebratObjBut2_3"));
        odebratObjBut2_3->setGeometry(QRect(120, 60, 75, 23));
        odebratVsechVozBut = new QPushButton(tab_3);
        odebratVsechVozBut->setObjectName(QString::fromUtf8("odebratVsechVozBut"));
        odebratVsechVozBut->setGeometry(QRect(320, 170, 191, 23));
        tabWidget->addTab(tab_3, QString());
        Restaurace->setCentralWidget(centralwidget);
        menubar = new QMenuBar(Restaurace);
        menubar->setObjectName(QString::fromUtf8("menubar"));
        menubar->setGeometry(QRect(0, 0, 538, 21));
        Restaurace->setMenuBar(menubar);
        statusbar = new QStatusBar(Restaurace);
        statusbar->setObjectName(QString::fromUtf8("statusbar"));
        Restaurace->setStatusBar(statusbar);

        retranslateUi(Restaurace);

        tabWidget->setCurrentIndex(2);


        QMetaObject::connectSlotsByName(Restaurace);
    } // setupUi

    void retranslateUi(QMainWindow *Restaurace)
    {
        Restaurace->setWindowTitle(QCoreApplication::translate("Restaurace", "Restaurace", nullptr));
        pridatZam->setTitle(QCoreApplication::translate("Restaurace", "P\305\231idat zam\304\233stnance", nullptr));
        jmenoZamL->setText(QCoreApplication::translate("Restaurace", "Jm\303\251no", nullptr));
        prijmeniZamL->setText(QCoreApplication::translate("Restaurace", "P\305\231\303\255jmen\303\255", nullptr));
        pohlaviZamL->setText(QCoreApplication::translate("Restaurace", "Pohlav\303\255", nullptr));
        datumNarZamL->setText(QCoreApplication::translate("Restaurace", "Datum narozen\303\255", nullptr));
        datumFormatL->setText(QCoreApplication::translate("Restaurace", "(DD/MM/YYYY)", nullptr));
        adresaZamL->setText(QCoreApplication::translate("Restaurace", "Adresa", nullptr));
        emailZamL->setText(QCoreApplication::translate("Restaurace", "Email", nullptr));
        telefonZamL->setText(QCoreApplication::translate("Restaurace", "Telefon", nullptr));
        datumNasZamL->setText(QCoreApplication::translate("Restaurace", "Datum n\303\241stupu", nullptr));
        datumFormat2->setText(QCoreApplication::translate("Restaurace", "(DD/MM/YYYY)", nullptr));
        pohlaviZamRB1->setText(QCoreApplication::translate("Restaurace", "mu\305\276", nullptr));
        pohlaviZamRB2->setText(QCoreApplication::translate("Restaurace", "\305\276ena", nullptr));
        pridatZamBut1->setText(QCoreApplication::translate("Restaurace", "Ulo\305\276it", nullptr));
        pridatZamBut2->setText(QCoreApplication::translate("Restaurace", "Zru\305\241it", nullptr));
        odebratZam->setTitle(QCoreApplication::translate("Restaurace", "Odebrat zam\304\233stnance", nullptr));
        idZamL->setText(QCoreApplication::translate("Restaurace", "ID zam\304\233stnance", nullptr));
        odebratZamBut1->setText(QCoreApplication::translate("Restaurace", "Ulo\305\276it", nullptr));
        odebratZamBut2->setText(QCoreApplication::translate("Restaurace", "Zru\305\241it", nullptr));
        vyhledatZamBut->setText(QCoreApplication::translate("Restaurace", "Vyhledat zam\304\233stnance", nullptr));
        odebratVsechZamBut->setText(QCoreApplication::translate("Restaurace", "Odebrat v\305\241echny zam\304\233stnance", nullptr));
        potvrditZmenyBut->setText(QCoreApplication::translate("Restaurace", "Potvrdit zm\304\233ny", nullptr));
        zrusitBut->setText(QCoreApplication::translate("Restaurace", "Zru\305\241it", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(tab), QCoreApplication::translate("Restaurace", "Spr\303\241va zam\304\233stnanc\305\257", nullptr));
        vyhledatObjBut->setText(QCoreApplication::translate("Restaurace", "Vyhledat objedn\303\241vku", nullptr));
        odebratVsechObjBut->setText(QCoreApplication::translate("Restaurace", "Odebrat v\305\241echny objedn\303\241vky", nullptr));
        potvrditZmenyBut_2->setText(QCoreApplication::translate("Restaurace", "Potvrdit zm\304\233ny", nullptr));
        pridatObj->setTitle(QCoreApplication::translate("Restaurace", "P\305\231idat objedn\303\241vku", nullptr));
        jmenoZakL->setText(QCoreApplication::translate("Restaurace", "Jm\303\251no z\303\241k.", nullptr));
        prijmeniZakL->setText(QCoreApplication::translate("Restaurace", "P\305\231\303\255jmen\303\255 z\303\241k.", nullptr));
        adresaZakL->setText(QCoreApplication::translate("Restaurace", "Adresa z\303\241k.", nullptr));
        cenaL->setText(QCoreApplication::translate("Restaurace", "Cena", nullptr));
        telefonZakL->setText(QCoreApplication::translate("Restaurace", "Telefon z\303\241k.", nullptr));
        pridatObjBut1->setText(QCoreApplication::translate("Restaurace", "Ulo\305\276it", nullptr));
        pridatObjBut2->setText(QCoreApplication::translate("Restaurace", "Zru\305\241it", nullptr));
        datumVytvoreniL->setText(QCoreApplication::translate("Restaurace", "Datum vytvo\305\231en\303\255", nullptr));
        datumFormatL_2->setText(QCoreApplication::translate("Restaurace", "(DD/MM/YYYY)", nullptr));
        menaL->setText(QCoreApplication::translate("Restaurace", "K\304\215", nullptr));
        zrusitBut_2->setText(QCoreApplication::translate("Restaurace", "Zru\305\241it", nullptr));
        odebratObj->setTitle(QCoreApplication::translate("Restaurace", "Odebrat objedn\303\241vku", nullptr));
        idObjL->setText(QCoreApplication::translate("Restaurace", "ID objedn\303\241vky", nullptr));
        odebratObjBut1->setText(QCoreApplication::translate("Restaurace", "Ulo\305\276it", nullptr));
        odebratObjBut2->setText(QCoreApplication::translate("Restaurace", "Zru\305\241it", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(tab_2), QCoreApplication::translate("Restaurace", "Spr\303\241va objedn\303\241vek", nullptr));
        vyhledatVozBut->setText(QCoreApplication::translate("Restaurace", "Vyhledat vozidlo", nullptr));
        pridatVoz->setTitle(QCoreApplication::translate("Restaurace", "P\305\231idat vozidlo", nullptr));
        modelL->setText(QCoreApplication::translate("Restaurace", "Model", nullptr));
        SPZL->setText(QCoreApplication::translate("Restaurace", "SPZ", nullptr));
        obejmKufruL->setText(QCoreApplication::translate("Restaurace", "Objem kufru", nullptr));
        pridatVozBut1->setText(QCoreApplication::translate("Restaurace", "Ulo\305\276it", nullptr));
        pridatVozBut2->setText(QCoreApplication::translate("Restaurace", "Zru\305\241it", nullptr));
        datumVytvoreniL_3->setText(QCoreApplication::translate("Restaurace", "Datum vytvo\305\231en\303\255", nullptr));
        datumFormatL_4->setText(QCoreApplication::translate("Restaurace", "(DD/MM/YYYY)", nullptr));
        cenaL_3->setText(QCoreApplication::translate("Restaurace", "Cena", nullptr));
        menaL_3->setText(QCoreApplication::translate("Restaurace", "K\304\215", nullptr));
        zrusitBut_3->setText(QCoreApplication::translate("Restaurace", "Zru\305\241it", nullptr));
        potvrditZmenyBut_3->setText(QCoreApplication::translate("Restaurace", "Potvrdit zm\304\233ny", nullptr));
        odebratVoz->setTitle(QCoreApplication::translate("Restaurace", "Odebrat vozidlo", nullptr));
        idVozL->setText(QCoreApplication::translate("Restaurace", "ID vozidla", nullptr));
        odebratObjBut1_3->setText(QCoreApplication::translate("Restaurace", "Ulo\305\276it", nullptr));
        odebratObjBut2_3->setText(QCoreApplication::translate("Restaurace", "Zru\305\241it", nullptr));
        odebratVsechVozBut->setText(QCoreApplication::translate("Restaurace", "Odebrat v\305\241echna vozidla", nullptr));
        tabWidget->setTabText(tabWidget->indexOf(tab_3), QCoreApplication::translate("Restaurace", "Spr\303\241va vozidel", nullptr));
    } // retranslateUi

};

namespace Ui {
    class Restaurace: public Ui_Restaurace {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_RESTAURACE_H
