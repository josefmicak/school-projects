#include "restaurace.h"

#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    Restaurace w;
    w.show();
    return a.exec();
}
