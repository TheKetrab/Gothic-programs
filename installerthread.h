#ifndef INSTALLERTHREAD_H
#define INSTALLERTHREAD_H

#include <QThread>
#include "mainwindow.h"

class InstallerThread : public QThread
{
    Q_OBJECT
public:
    InstallerThread(QString instalationPath
                    );

    QString instalationPath;

    void MoveModToGothic();
    void CreateDesktopIcon();
    static bool CopyFile(QString source, QString destinationDirectory, QString filename, QString &errors);

    void run() override;

private:

signals:
    void UpdateLabelInfo(QString info, QString cssColor);
    void UpdateProgressBar(int add, QString errors);
    void EnableGUI();

public slots:



};

#endif // INSTALLERTHREAD_H
