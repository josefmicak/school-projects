#ifndef CALCULATOR_H
#define CALCULATOR_H

#include <QWidget>
#include <QLabel>
#include <QLineEdit>
#include <QTableView>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QString>
#include <QButtonGroup>
#include <QRadioButton>
#include <QSpinBox>
#include <QGroupBox>
#include <QPushButton>
#include <QMessageBox>


class Calculator : public QWidget
{
    Q_OBJECT

    QGridLayout *layout;
    QVBoxLayout *panel;
    QHBoxLayout *hbox;
    QLineEdit  *display;
    QGroupBox *radioButtons;
    QRadioButton *norRBut, *bigRBut;
    std::vector<QPushButton*> digitButtonList;
    QPushButton *addBut, *clsBut, *subBut, *mulBut, *divBut, *eqBut, *flBut, *delBut, *sigBut;

    QMessageBox msg;

    QFont font;

    bool newNumExpected=false;
    bool newidOpExpected=false;
    bool fltPoint=false;
    double opA=0;
    double opB=0;
    QString idOp = "";

public:
    Calculator(QWidget *parent = 0);
    ~Calculator();

private slots:
    void clickNorButton();
    void clickBigButton();
    void clickDigit();
    void clickOperator();
    void clickCls();
    void doTheMath();
    void addFloatingPoint();
    void deleteNumber();
    void changeSign();
};

#endif // CALCULATOR_H
