#include "installerthread.h"
#include <QThread>
#include <QFile>
#include <QDir>
#include <QThread>
#include <QDebug>
#include "mainwindow.h"
#include <QApplication>

#include "shortcutmaker.h"

InstallerThread::InstallerThread(QString instalationPath)
    : instalationPath(instalationPath)
{

}


void InstallerThread::run() {

    qDebug() << "InstallerThread Run";
    MoveModToGothic();
    CreateDesktopIcon();

    EnableGUI();
}

// returns false if any problems
bool InstallerThread::CopyFile(QString source, QString destinationDirectory, QString filename, QString &errors) {

    bool res = true;

    // ----- IF FILE EXISTS -----
    if (QFile::exists(destinationDirectory + filename)) {
        res = false;
        errors += "Plik " + filename + " już istniał! Został więc nadpisany.";
    }
    // ----- -------------- -----


    // ----- DIRECTORY DOESN'T EXISTS -----
    if (!QDir(destinationDirectory).exists()) {
        QDir().mkpath(destinationDirectory);
    }
    // ----- ------------------------ -----


    // ----- COPY -----
    qDebug() << "source = " << source << " dest = " <<destinationDirectory<<filename;
    if (!QFile::copy(source,destinationDirectory + filename)) {
        res = false;
        errors += "Powstały problemy przy przenoszeniu pliku " + filename + ".";
    }
    // ----- ---- -----

    return res;

}



void InstallerThread::MoveModToGothic() {

    // Ucieczka Mod        = 166MB     18%
    // FreeMine Guitar     = 17MB       2%
    // G2UcieczkaIntro     = 61MB       7%
    // G2UcieczkaAfterKap3 = 33MB       3%
    // G2UcieczkaOutro     = 33MB       4%
    // G2UcieczkaCredits   = 27MB       3%
    // Ucieczka Dubbing    = 568MB     63%
    //        -----> RAZEM = 905MB -- 100%

    QString errors = "";

    qDebug() << "Instalacja";

    // ----- MOVING MOD FILE -----
    UpdateLabelInfo("bla","red");
    CopyFile(":/Ucieczka.mod",instalationPath+"/Data/modvdf/","Ucieczka.mod",errors);
    UpdateProgressBar(18,errors);
    // ----- --------------- -----


    // ----- MOVING SOUNDS -----
    //UpdateLabelInfo("bla");
    CopyFile(":/FREE_MINE_GUITAR.wav",instalationPath+"/_Work/data/Sound/SFX/","FREE_MINE_GUITAR.wav",errors);
    UpdateProgressBar(2,errors);
    // ----- ------------- -----


    // ----- MOVING VIDEOS -----
    //UpdateLabelInfo("bla");
    CopyFile(":/G2UcieczkaIntro.bik",instalationPath+"/_Work/data/Video/","G2UcieczkaIntro.bik",errors);
    UpdateProgressBar(7,errors);

    CopyFile(":/G2UcieczkaAfterKap3.bik",instalationPath+"/_Work/data/Video/","G2UcieczkaAfterKap3.bik",errors);
    UpdateProgressBar(3,errors);

    CopyFile(":/G2UcieczkaOutro.bik",instalationPath+"/_Work/data/Video/","G2UcieczkaOutro.bik",errors);
    UpdateProgressBar(4,errors);

    CopyFile(":/G2UcieczkaCredits.bik",instalationPath+"/_Work/data/Video/","G2UcieczkaCredits.bik",errors);
    UpdateProgressBar(3,errors);
    // ----- ------------- -----


    // ----- MOVING DUBBING -----
    //UpdateLabelInfo("bla");
    CopyFile(":/UcieczkaDubbing.vdf",instalationPath+"/Data/","UcieczkaDubbing.vdf",errors);
    UpdateProgressBar(63,errors);
    // ----- -------------- -----

    qDebug() << errors;
    qDebug() << "SKONCZYLEM";

}


void InstallerThread::CreateDesktopIcon() {

    std::string str = instalationPath.toUtf8().constData();
    ShortcutMaker m(str);
    m.CreateShortcut();

    /*
    ShellShortcut shortcut = new ShellShortcut(@"S:\foo.lnk");
    shortcut.Description = "Sample item";
    shortcut.IconPath = @"S:\my\myDirectory\icon.ico";
    shortcut.IconIndex = Convert.ToInt32(0);
    shortcut.Path = @"S:\my\myDirectory\";
    shortcut.WorkingDirectory = @"S:\my\myDirectory\";
    shortcut.Save();
    */












}

