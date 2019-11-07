#ifndef SHORTCUTMAKER_H
#define SHORTCUTMAKER_H

#include <iostream>

class ShortcutMaker
{
public:

    std::string gameLocation;

    ShortcutMaker(std::string gameLocation);
    void CreateShortcut();
    static int StringToWString(std::wstring &ws, const std::string &s);
};

#endif // SHORTCUTMAKER_H
