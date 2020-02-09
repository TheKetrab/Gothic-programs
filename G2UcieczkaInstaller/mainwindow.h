#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QProgressBar>
#include <QDebug>

#include "installerthread.h"


QT_BEGIN_NAMESPACE
namespace Ui { class MainWindow; }
QT_END_NAMESPACE

class MainWindow : public QMainWindow
{
    Q_OBJECT



public:
    ~MainWindow();
    void SetBackground();
    void SetTextHeader();
    void StartInstalation();
    void SetWindow();
    bool EverythingIsGood(QString &errors);
    void ShowProblemsDialog(QString &errors);
    static bool IsGothicFolder(QString path);
    static bool UserHasUnion(QString path);

public:
    MainWindow(QWidget *parent = nullptr);

    QThread *installerThread;

private slots:
    void on_browseButton_clicked();
    void on_installButton_clicked();
public slots:
    void ForceInstalationFromDialog();
    void UpdateProgressBar(int add);
    void UpdateLabelInfo(QString message, QString cssColor);
    void EnableGUI();
    void DisableGUI();




public:
    Ui::MainWindow *ui;
};
#endif // MAINWINDOW_H
