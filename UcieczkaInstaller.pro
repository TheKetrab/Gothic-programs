QT       += core gui multimedia
RESOURCES += Resources/resources.qrc

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

CONFIG += c++11 resources_big static

# The following define makes your compiler emit warnings if you use
# any Qt feature that has been marked deprecated (the exact warnings
# depend on your compiler). Please consult the documentation of the
# deprecated API in order to know how to port your code away from it.
DEFINES += QT_DEPRECATED_WARNINGS

# You can also make your code fail to compile if it uses deprecated APIs.
# In order to do so, uncomment the following line.
# You can also select to disable deprecated APIs only up to a certain version of Qt.
#DEFINES += QT_DISABLE_DEPRECATED_BEFORE=0x060000    # disables all the APIs deprecated before Qt 6.0.0



# LIBS += -L[path to lib] -l[name of lib]

LIBS = \
    -LC:/Qt/Static/5.13.1/lib \
    -IC:/Qt/Static/5.13.1/include/QtCore \
    -IC:/Qt/Static/5.13.1/include/QtMultimedia \
    -IC:/Qt/Static/5.13.1/include/QtGui \
    -IC:/Qt/Static/5.13.1/include/QtCore \
    -IC:/Qt/Static/5.13.1/include/QtWidgets \
    -lQt5Core \
    -lQt5Multimedia \
    -lQt5Gui \
    -lQt5Widgets

SOURCES += \
    installerthread.cpp \
    main.cpp \
    mainwindow.cpp \
    shortcutmaker.cpp

HEADERS += \
    installerthread.h \
    mainwindow.h \
    shortcutmaker.h

FORMS += \
    mainwindow.ui


#INCLUDEPATH += "C:/Program Files/Microsoft SDKs/Windows/v7.1/Include"
#LIBS += "C:/Program Files/Microsoft SDKs/Windows/v7.1/Lib/Rpcrt4.lib"

win32
{
    LIBS += -lole32
}

# Default rules for deployment.
qnx: target.path = /tmp/$${TARGET}/bin
else: unix:!android: target.path = /opt/$${TARGET}/bin
!isEmpty(target.path): INSTALLS += target

DISTFILES += \
    x.qml
