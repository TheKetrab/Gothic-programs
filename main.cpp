#include "mainwindow.h"

#include <QtCore>
#include <QMediaPlayer>
#include <QApplication>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    QThread::currentThread()->setObjectName("MainThread");

    // ----- WINDOW -----
    MainWindow w;
    w.show();
    // ----- ------ -----

    // ----- MUSIC -----
    QMediaPlayer *music = new QMediaPlayer();
    music->setMedia(QUrl("qrc:Music.wav"));
    music->play();
    // ----- ----- -----


    return a.exec();
}
