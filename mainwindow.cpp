#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "installerthread.h"

#include <QtCore>
#include <QtWidgets>
#include <QtGui>

MainWindow::MainWindow(QWidget *parent)
    : QMainWindow(parent)
    , ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    SetWindow();
    SetBackground();
    SetTextHeader();


}

void MainWindow::EnableGUI() {
    ui->sourcePath->setEnabled(true);
    ui->browseButton->setEnabled(true);
    ui->checkBoxIcon->setEnabled(true);
    ui->checkBoxUnion->setEnabled(true);
    ui->installButton->setEnabled(true);
}
void MainWindow::DisableGUI() {
    ui->sourcePath->setEnabled(false);
    ui->browseButton->setEnabled(false);
    ui->checkBoxIcon->setEnabled(false);
    ui->checkBoxUnion->setEnabled(false);
    ui->installButton->setEnabled(false);
}
void MainWindow::SetWindow() {

    setMinimumSize(QSize(350,500));
    setMaximumSize(QSize(350,500));
    this->setWindowTitle("G2 Ucieczka: Instalator");

    ui->checkBoxIcon->setCheckState(Qt::CheckState::Checked);
}

MainWindow::~MainWindow()
{

    delete ui;
}



void MainWindow::SetBackground() {

    ui->background->setStyleSheet("background-image: url(:Background.jpg);");
    setWindowIcon(QIcon(":G2ULogo.ico"));

}


QFont HeaderFont(QFont baseFont) {

    baseFont.setPointSize(10);
    baseFont.setBold(true);
    return baseFont;

}

void MainWindow::SetTextHeader() {

    ui->title->setFont( HeaderFont( ui->title->font()) );

}

void MainWindow::on_browseButton_clicked()
{
    QString dir =
      QFileDialog::getExistingDirectory(
        this, tr("Open Directory"), "/home", QFileDialog::ShowDirsOnly
                                           | QFileDialog::DontResolveSymlinks);
    ui->sourcePath->setPlainText(dir);
}

void MainWindow::on_installButton_clicked()
{
    // ----- EXIT IF -----
    if (ui->sourcePath->toPlainText().isEmpty())
        return;


    // ----- TRY TO INSTALL -----
    QString errors;
    if (EverythingIsGood(errors))
        StartInstalation();
    else
        ShowProblemsDialog(errors);
}


void MainWindow::ForceInstalationFromDialog() {
    StartInstalation();
}

bool MainWindow::EverythingIsGood(QString &errors) {

    bool res = true;

    // ----- ----- IS GOTHIC FOLDER ----- -----
    if (!IsGothicFolder(ui->sourcePath->toPlainText())) {
        res = false;
        errors += "Wybrany folder prawdopodobnie nie jest folderem<br>z zainstalowanym Gothiciem 2 Noc Kruka.";
        return res;
    }
    // ----- ----- ---------------- ----- -----


    // ----- ----- IS UNION INSTALLED ----- -----
    if (ui->checkBoxUnion->isChecked()
     && UserHasUnion(ui->sourcePath->toPlainText())) {
        res = false;
        errors += "Prawdopodobnie masz już zainstalowanego<br>Uniona. Próbujesz go nadpisać?";
    }

    if (!ui->checkBoxUnion->isChecked()
     && !UserHasUnion(ui->sourcePath->toPlainText())) {
        res = false;
        errors += "W folderze z Gothicem nie znaleziono Uniona.<br>Powinieneś zaznaczyć opcję, aby go zainstalować!";
    }
    // ----- ----- ------------------ ----- -----

    return res;
}

void MainWindow::StartInstalation() {


    DisableGUI();

    installerThread = new InstallerThread(ui->sourcePath->toPlainText());

    connect(installerThread,SIGNAL(UpdateProgressBar(int)),
            this,SLOT(UpdateProgressBar(int)));
    connect(installerThread,SIGNAL(UpdateLabelInfo(QString,QString)),
            this,SLOT(UpdateLabelInfo(QString,QString)));
    connect(installerThread,SIGNAL(EnableGUI()),
            this,SLOT(EnableGUI()));

    installerThread->start();

}

bool MainWindow::IsGothicFolder(QString path) {

    return
      (QDir(path).exists()
       && QDir(path + "/_Work").exists()
       && QDir(path + "/Data").exists()
       && QDir(path + "/System").exists());

}

bool MainWindow::UserHasUnion(QString path) {

    return
      (QFile(path + "/Data/Union.vdf").exists()
       && QFile(path + "/System/Union.patch").exists());

}



void MainWindow::ShowProblemsDialog(QString &errors) {

    // ----- DEFINE -----
    QDialog *dialog = new QDialog(this);

    QLabel *label1 = new QLabel("Coś poszło nie tak!");
    QLabel *label2 = new QLabel(errors);
    QLabel *label3 = new QLabel("Instalacja może nie przebiedz poprawnie.");

    QPushButton *buttonNo = new QPushButton("Popraw błędy");
    QPushButton *buttonYes = new QPushButton("Instaluj mimo to");

    QVBoxLayout *vbox = new QVBoxLayout();

    QWidget *buttonBox = new QWidget();
    QHBoxLayout *hbox = new QHBoxLayout();

    // ----- ADD LAYOUTS -----
    hbox->addWidget(buttonNo);
    hbox->addWidget(buttonYes);
    buttonBox->setLayout(hbox);

    label1->setFont( HeaderFont(label1->font()) );
    label1->setAlignment(Qt::AlignCenter);
    vbox->addWidget(label1);
    vbox->addWidget(label2);
    vbox->addWidget(label3);
    vbox->addWidget(buttonBox);
    dialog->setLayout(vbox);

    // ----- BUTTONS ACTIONS -----
    connect(buttonNo,SIGNAL(clicked()),
            dialog,SLOT(close()));
    connect(buttonYes,SIGNAL(clicked()),
            dialog,SLOT(close()));
    connect(buttonYes,SIGNAL(clicked()),
            dialog->parent(),SLOT(ForceInstalationFromDialog()));

    dialog->setFixedSize( dialog->sizeHint() );
    dialog->exec();

}


void MainWindow::UpdateLabelInfo(QString message, QString cssColor) {

    ui->labelStatus->setText("<font color='" + cssColor + "'>" + message + "</font>");

}

void MainWindow::UpdateProgressBar(int add) {

    int val = ui->progressBar->value();

    for (int i=0; i<add; i++) {
        ui->progressBar->setValue(val + i);
        QThread::msleep(10);
    }

    ui->progressBar->setValue(val + add);

}
