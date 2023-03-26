#include "calculator.h"

#define MIN_BUT_WIDTH 36
#define MIN_BUT_HEIGHT 36
#define NORMAL_FONT_SIZE 8
#define BIG_FONT_SIZE 12

Calculator::Calculator(QWidget *parent)
    : QWidget(parent)
{

    // vytvoreni hlavniho Grid Layoutu - rozmisteni komponent v okne
    layout = new QGridLayout;

    // panel pro display
    display = new QLineEdit("0");
    display->setReadOnly(true);
    display->setAlignment( Qt::AlignRight);
    display->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Normal));
    // pokud nastavime komponente font, globalni zmena fontu se zde neprojevi
    layout->addWidget(display, 0, 0, 1, 4);

    //panel pro radiobuttony
    hbox = new QHBoxLayout();
    radioButtons = new QGroupBox();
    norRBut = new QRadioButton(QString("Normal"), radioButtons);
    bigRBut = new QRadioButton(QString("Big"), radioButtons);
    norRBut->setChecked(1);
    hbox->addWidget(norRBut);
    hbox->setSpacing(20); // mezera mezi radiobuttony
    hbox->addWidget(bigRBut);
    hbox->setAlignment(Qt::AlignCenter);
    radioButtons->setLayout(hbox);
    radioButtons->setFixedHeight(75);
    layout->addWidget(radioButtons, 1, 0, 1, 4);
    //layout->addLayout(hbox, 1, 0, 1, 4);

    connect(norRBut, SIGNAL(clicked()), this, SLOT(clickNorButton()));
    connect(bigRBut, SIGNAL(clicked()), this, SLOT(clickBigButton()));

    //jednotliva tlacitka - vytvorime a ulozime do vektoru, ve kterem budou ulozeny tlacitka s cislicemi
    for(int i = 0; i <= 9; i++)
    {
        QPushButton* btn = new QPushButton(QString::number(i));

        btn->setMinimumSize(MIN_BUT_WIDTH, MIN_BUT_HEIGHT);
        btn->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
        // komponenta se bude zvetsovat ve vertikalnim i horiznotalnim smeru (jina moznost: Fixed)
        connect(btn, SIGNAL(clicked()), this, SLOT(clickDigit()));
        this->digitButtonList.push_back(btn);
    }

    // vykreslime do gridLayoutu (row, column, rowspan, columnspan)
    layout->addWidget(this->digitButtonList[1], 5, 0);
    layout->addWidget(this->digitButtonList[5], 4, 1);
    layout->addWidget(this->digitButtonList[9], 3, 2);
    layout->addWidget(this->digitButtonList[0], 6, 0, 1, 2);
    layout->addWidget(this->digitButtonList[2], 5, 1);
    layout->addWidget(this->digitButtonList[3], 5, 2);
    layout->addWidget(this->digitButtonList[4], 4, 0);
    layout->addWidget(this->digitButtonList[6], 4, 2);
    layout->addWidget(this->digitButtonList[7], 3, 0);
    layout->addWidget(this->digitButtonList[8], 3, 1);


    addBut = new QPushButton("+");
    addBut->setMinimumSize(MIN_BUT_WIDTH, MIN_BUT_HEIGHT);
    addBut->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
    connect(addBut, SIGNAL(clicked()), this, SLOT(clickOperator()));

    subBut = new QPushButton("-");
    subBut->setMinimumSize(MIN_BUT_WIDTH, MIN_BUT_HEIGHT);
    subBut->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
    connect(subBut, SIGNAL(clicked()), this, SLOT(clickOperator()));

    mulBut = new QPushButton("*");
    mulBut->setMinimumSize(MIN_BUT_WIDTH, MIN_BUT_HEIGHT);
    mulBut->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
    connect(mulBut, SIGNAL(clicked()), this, SLOT(clickOperator()));

    divBut = new QPushButton("/");
    divBut->setMinimumSize(MIN_BUT_WIDTH, MIN_BUT_HEIGHT);
    divBut->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
    connect(divBut, SIGNAL(clicked()), this, SLOT(clickOperator()));

    eqBut = new QPushButton("=");
    eqBut->setMinimumSize(MIN_BUT_WIDTH, MIN_BUT_HEIGHT);
    eqBut->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
    connect(eqBut, SIGNAL(clicked()), this, SLOT(doTheMath()));

    flBut = new QPushButton(".");
    flBut->setMinimumSize(MIN_BUT_WIDTH, MIN_BUT_HEIGHT);
    flBut->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
    connect(flBut, SIGNAL(clicked()), this, SLOT(addFloatingPoint()));

    delBut = new QPushButton(QChar(0x2190));
    delBut->setMinimumSize(MIN_BUT_WIDTH, MIN_BUT_HEIGHT);
    delBut->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
    connect(delBut, SIGNAL(clicked()), this, SLOT(deleteNumber()));

    sigBut = new QPushButton("+/-");
    sigBut->setMinimumSize(MIN_BUT_WIDTH, MIN_BUT_HEIGHT);
    sigBut->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
    connect(sigBut, SIGNAL(clicked()), this, SLOT(changeSign()));

    clsBut = new QPushButton("Cls");
    clsBut->setMinimumSize(MIN_BUT_WIDTH, MIN_BUT_HEIGHT);
    clsBut->setSizePolicy(QSizePolicy::Expanding, QSizePolicy::Expanding);
    connect(clsBut, SIGNAL(clicked()), this, SLOT(clickCls()));

    layout->addWidget(addBut, 2, 3);
    layout->addWidget(clsBut, 2, 0);
    layout->addWidget(subBut, 3, 3);
    layout->addWidget(mulBut, 4, 3);
    layout->addWidget(divBut, 5, 3);
    layout->addWidget(eqBut, 6, 3);
    layout->addWidget(flBut, 6, 2);
    layout->addWidget(delBut, 2, 1);
    layout->addWidget(sigBut, 2, 2);

    setLayout( layout );
}

Calculator::~Calculator()
{

}

void Calculator::clickDigit()
{
    if(newidOpExpected)
    {
        msg.setText("+ or - or * or / expected");
        msg.exec();
        return;
    }

    // pomoci sender zjistime, ktera komponenta vyvolala signal
    // vime, ze je to tlacitko, tak sender, ktery je obecne QObject, pretypujeme na QPushButton
    QPushButton *clickedButton = static_cast<QPushButton*>(sender());
    QString txt = display->text(); // ziskame text displeje
    if(txt.compare("0") == 0 || txt.compare("+") == 0 || txt.compare("-") == 0 || txt.compare("*") == 0 || txt.compare("/") == 0)
        txt = clickedButton->text();
    else
        txt.append(clickedButton->text()); // pokud neni, pridame znak
    display->setText(txt);

    newNumExpected = false;
    fltPoint = false;
}

void Calculator::clickOperator()
{
    if(newNumExpected)
    {
        msg.setText("Number expected");
        msg.exec();
        return;
    }

    if(fltPoint)
    {
        msg.setText("Floating point expected");
        msg.exec();
        return;
    }
    if(idOp.compare("") == 1)
    {
        msg.setText("You have already selected an operation");
        msg.exec();
        return;
    }
    QPushButton *clickedButton = static_cast<QPushButton*>(sender());
    opA = display->text().toDouble();
    idOp = clickedButton->text();
    display->setText(idOp);

    newNumExpected = true;
    newidOpExpected=false;
}

void Calculator::doTheMath()
{
    if(newNumExpected)
    {
        msg.setText("Number expected");
        msg.exec();
        return;
    }
    if(fltPoint)
    {
        msg.setText("Floating point expected");
        msg.exec();
        return;
    }
    if(idOp.compare("") == 0)
    {
        msg.setText("You have not selected any operation yet");
        msg.exec();
        return;
    }
    if(newidOpExpected)
    {
        msg.setText("+ or - or * or / expected");
        msg.exec();
        return;
    }
    opB = display->text().toDouble();
    double result = 0;
    if(idOp.compare("+") == 0)
        result = opA + opB;
    if(idOp.compare("-") == 0)
        result = opA - opB;
    if(idOp.compare("*") == 0)
        result = opA * opB;
    if(idOp.compare("/") == 0)
        result = opA / opB;
    display->setText(QString::number(result));
    idOp = "";
    opA = result;

}

void Calculator::addFloatingPoint()
{
    bool number = true;
    QString txt = display->text();

    if(newNumExpected)
    {
        msg.setText("Number expected");
        msg.exec();
        return;
    }
    if(fltPoint)
    {
        msg.setText("Floating point expected");
        msg.exec();
        return;
    }
    if(newidOpExpected)
    {
        msg.setText("+ or - or * or / expected");
        msg.exec();
        return;
    }

    for(int i=1;i<txt.size();i++)
        if(!txt[i].isDigit())
            number = false;
    if(!txt[0].isDigit() && txt[0] != '-')
        number = false;

    if(!number)
        return;
    fltPoint = true;
    display->setText(txt + ".");
}

void Calculator::deleteNumber()
{
    QString txt = display->text();
    int len = txt.size();

    if(len == 1)
    {
        if(txt.compare("+") == 0 || txt.compare("-") == 0 || txt.compare("*") == 0 || txt.compare("/") == 0)
        {
            idOp = "";
            newidOpExpected=true;
            newNumExpected = false;
            display->setText(QString::number(opA));
        }
        else
            display->setText("0");
    }
    else
    {
        txt = txt.left(len-1);
        display->setText(txt);
        if(txt[len-2] == '.')
            newNumExpected = true;
        else
            newNumExpected = false;
    }
}

void Calculator::changeSign()
{
    QString txt = display->text();

    if(txt != "+" && txt != "-" && txt != "*" && txt != "/")
    {
        double number = txt.toDouble();
        number=-number;
        display->setText(QString::number(number));
    }
}

void Calculator::clickNorButton()
{
    // zmenime font konkretnim prvkum
    clsBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    norRBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    bigRBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    addBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    subBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    mulBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    divBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    eqBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    flBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    delBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    sigBut->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));

    for(int i = 0; i <= 9; i++)
    {
        this->digitButtonList[i]->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));
    }

    // nebo globalne v celem okne
    //this->setFont(QFont("SanSerif", NORMAL_FONT_SIZE, QFont::Normal));

}
void Calculator::clickBigButton()
{
    clsBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    norRBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    bigRBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    addBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    subBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    mulBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    divBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    eqBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    flBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    delBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    sigBut->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));

    for(int i = 0; i <= 9; i++)
    {
        this->digitButtonList[i]->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
    }
    //this->setFont(QFont("SanSerif", BIG_FONT_SIZE, QFont::Bold));
}

void Calculator::clickCls()
{
    display->setText("0");
    newidOpExpected=false;
    newNumExpected=false;
    fltPoint=false;
    opA=0;
    opB=0;
    idOp = "";
}


