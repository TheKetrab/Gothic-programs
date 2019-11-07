#include "shortcutmaker.h"

#include <ShlObj.h>
#include <iostream>
#include <QDebug>

ShortcutMaker::ShortcutMaker(std::string gameLocation)
    : gameLocation(gameLocation)
{

}

int ShortcutMaker::StringToWString(std::wstring &ws, const std::string &s)
{
    std::wstring wsTmp(s.begin(), s.end());
    ws = wsTmp;
    return 0;
}

void ShortcutMaker::CreateShortcut() {

    qDebug() << "CreateShortcut";

    CoInitialize(nullptr); // COM initialize
    IShellLink *pShellLink = nullptr;
    IPersistFile *pPersistFile = nullptr;
    HRESULT hres;
    hres = CoCreateInstance(CLSID_ShellLink, nullptr, CLSCTX_ALL,
                       IID_IShellLink, (void**)&pShellLink);

    if (SUCCEEDED(hres)) {

        // ----- SET DATA OF SHORTCUT -----
        pShellLink->SetPath( L"C:/Gry/G2UcieczkaUnion/System/Gothic2.exe" );
        pShellLink->SetArguments( L"-game:Ucieczka.ini" );

        int icoId=0;
        std::wstring wIcoLocation;
        std::string sIcoLocation = gameLocation + "/System/Ucieczka.ico";

        StringToWString(wIcoLocation,sIcoLocation);
        LPCWSTR lpcwstrIcoLocation = wIcoLocation.c_str();
        pShellLink->SetIconLocation( lpcwstrIcoLocation, icoId );
        // ----- -------------------- -----


        // ----- CREATE SHORTCUT ON DESKTOP -----
        hres = pShellLink->QueryInterface(IID_IPersistFile, (void**)&pPersistFile);

        if (SUCCEEDED(hres)) {

            TCHAR desktopPath[MAX_PATH];
            hres = SHGetFolderPath(nullptr,CSIDL_DESKTOPDIRECTORY,nullptr,0,desktopPath);

            if(SUCCEEDED(hres)) {

                std::wstring wDesktopPath(desktopPath);
                std::wstring wShortcutPath = wDesktopPath + L"/Ucieczka.lnk";
                LPCWSTR lpcwstrShortcutPath = wShortcutPath.c_str();

                hres = pPersistFile->Save(lpcwstrShortcutPath, TRUE);

                /* // get info about the shortcut
                TCHAR buf[256];
                pShellLink->GetIconLocation(buf,256,&icoId);
                wstring w1(buf);
                QString qstr = QString::fromWCharArray( w1.c_str() );
                qDebug() << "IconLocation: " << qstr << " Id: " << icoId;
                */

            }

            pPersistFile->Release(); // free pointer
        }
        // ----- -------------------------- -----

        pShellLink->Release(); // free pointer
    }
}
