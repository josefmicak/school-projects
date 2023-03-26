#include "restaurace.h"
#include "ui_restaurace.h"

Restaurace::Restaurace(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::Restaurace)
{
    ui->setupUi(this);
}

Restaurace::~Restaurace()
{
    delete ui;
}

