#include "installerthread.h"
#include "mainwindow.h"
#include "shortcutmaker.h"

#include <QtCore>


InstallerThread::InstallerThread(QString instalationPath)
    : instalationPath(instalationPath)
{

}


void InstallerThread::run() {

    qDebug() << "InstallerThread Run";
    MoveModToGothic();
    InstallUnion();
    CreateDesktopIcon();

    // when you're done
    EnableGUI();
}

// returns false if any problems
bool InstallerThread::CopyFile(QString source, QString destinationDirectory, QString filename, QString &errors) {

    bool res = true;

    // ----- IF FILE EXISTS -----
    if (QFile::exists(destinationDirectory + filename)) {
        res = false;
        QString error = "Plik " + filename + " już istniał! Został więc nadpisany.";
        errors += error + "<br>";
        UpdateLabelInfo(error,"red");
    }
    // ----- -------------- -----


    // ----- DIRECTORY DOESN'T EXISTS -----
    if (!QDir(destinationDirectory).exists()) {
        QDir().mkpath(destinationDirectory);
        QString error = "Folder " + destinationDirectory + " nie istniał, więc został utworzony.";
        errors += error + "<br>";
        UpdateLabelInfo(error,"red");
    }
    // ----- ------------------------ -----


    // ----- COPY -----
    qDebug() << "source = " << source << " dest = " <<destinationDirectory<<filename;
    if (!QFile::copy(source,destinationDirectory + filename)) {
        res = false;
        QString error = "Powstały problemy przy przenoszeniu pliku " + filename + ".";
        errors += error + "<br>";
        UpdateLabelInfo(error,"red");
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
    // Ucieczka Dubbing    = 568MB     62%
    // OtherFiles          = 0MB        1%
    //        -----> RAZEM = 905MB -- 100%

    QString errors = "";

    qDebug() << "Instalacja";

    // ----- MOVING MOD FILE -----
    UpdateLabelInfo("Przenoszenie paczki z mode.","black");
    CopyFile(":/Ucieczka.mod",instalationPath+"/Data/modvdf/","Ucieczka.mod",errors);
    UpdateProgressBar(18);
    // ----- --------------- -----


    // ----- MOVING SOUNDS -----
    UpdateLabelInfo("Przenoszenie dźwięków.","black");
    CopyFile(":/FREE_MINE_GUITAR.wav",instalationPath+"/_Work/data/Sound/SFX/","FREE_MINE_GUITAR.wav",errors);
    UpdateProgressBar(2);
    // ----- ------------- -----


    // ----- MOVING VIDEOS -----
    UpdateLabelInfo("Przenoszenie plików video.","black");

    CopyFile(":/G2UcieczkaIntro.bik",instalationPath+"/_Work/data/Video/","G2UcieczkaIntro.bik",errors);
    UpdateProgressBar(7);

    CopyFile(":/G2UcieczkaAfterKap3.bik",instalationPath+"/_Work/data/Video/","G2UcieczkaAfterKap3.bik",errors);
    UpdateProgressBar(3);

    CopyFile(":/G2UcieczkaOutro.bik",instalationPath+"/_Work/data/Video/","G2UcieczkaOutro.bik",errors);
    UpdateProgressBar(4);

    CopyFile(":/G2UcieczkaCredits.bik",instalationPath+"/_Work/data/Video/","G2UcieczkaCredits.bik",errors);
    UpdateProgressBar(3);
    // ----- ------------- -----


    // ----- MOVING DUBBING -----
    UpdateLabelInfo("Przenoszenie dubbingu.","black");
    CopyFile(":/UcieczkaDubbing.vdf",instalationPath+"/Data/","UcieczkaDubbing.vdf",errors);
    UpdateProgressBar(62);
    // ----- -------------- -----


    // ----- OTHER FILES -----
    UpdateLabelInfo("Przenoszenie pomocniczych plików.","black");

    CopyFile(":/G2ULogo.ico",instalationPath+"/System/","Ucieczka.ico",errors);
    CopyFile(":/Ucieczka.ini",instalationPath+"/System/","Ucieczka.ini",errors);
    CopyFile(":/Ucieczka.rtf",instalationPath+"/System/","Ucieczka.rtf",errors);

    UpdateProgressBar(1);
    // ----- -------------- -----

    qDebug() << errors;
    qDebug() << "SKONCZYLEM";

}

void InstallerThread::InstallUnion() {

    QString errors;
    UpdateLabelInfo("Instalacja pakietu Union.","black");
    CopyFile(":/Union.patch",instalationPath+"/System/","Union.patch",errors);
    CopyFile(":/Union.vdf",instalationPath+"/Data/","Union.vdf",errors);
    qDebug() << errors;

}


void InstallerThread::CreateDesktopIcon() {

    UpdateLabelInfo("Tworzenie skrótu na pulpicie.","black");
    std::string str = instalationPath.toUtf8().constData();
    ShortcutMaker m(str);
    m.CreateShortcut();

}

