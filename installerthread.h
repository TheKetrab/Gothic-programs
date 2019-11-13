#ifndef INSTALLERTHREAD_H
#define INSTALLERTHREAD_H

#include <QtCore>
#include "mainwindow.h"

class InstallerThread : public QThread
{
    Q_OBJECT
public:
    InstallerThread(QString instalationPath);

    QString instalationPath;

    void MoveModToGothic();
    void InstallUnion();
    void CreateDesktopIcon();
    bool CopyFile(QString source, QString destinationDirectory, QString filename, QString &errors);

    void run() override;

private:

signals:
    void UpdateLabelInfo(QString info, QString cssColor);
    void UpdateProgressBar(int add);
    void EnableGUI();

public slots:



};

#endif // INSTALLERTHREAD_H
