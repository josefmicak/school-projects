#ifndef RESTAURACE_H
#define RESTAURACE_H

#include <QMainWindow>

QT_BEGIN_NAMESPACE
namespace Ui { class Restaurace; }
QT_END_NAMESPACE

class Restaurace : public QMainWindow
{
    Q_OBJECT

public:
    Restaurace(QWidget *parent = nullptr);
    ~Restaurace();

private:
    Ui::Restaurace *ui;
};
#endif // RESTAURACE_H
