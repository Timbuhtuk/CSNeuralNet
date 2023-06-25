#ifndef PIPE_READER_H
#define PIPE_READER_H

#include "pipe_worker.h"

#include <QObject>
#include <QList>
#include <QString>
#include <QThread>
#include <QDebug>
#include <QtQml/qqmlregistration.h>
#include <QVariant>
#include <QVariantList>

class PipeReader : public QObject
{
private:
    Q_OBJECT
    QML_ELEMENT
    Q_PROPERTY(QString str READ str WRITE setStr NOTIFY strChanged)

    QString* m_str;
    PipeWorker* m_worker;
    QThread m_thread;

public:
    PipeReader(QObject* parent = nullptr);
    Q_INVOKABLE void start();
    QString str() { return *m_str; }


    void emitResults(const QString& str);



signals:
    void startWorker();
    void dataFetched(QString);
    void strChanged(QString);
    void initDataFetched(QList<QVariant> data);
    void weightDataFetched(QVariant layer, QVariant  neuron, QVariant weight, QVariant value);
    void weightFetchedFlat(QVariant number, QVariant value);

public slots:
    void getResult(const QString& str);

    void setStr(const QString& st)
    {
        *m_str = st; emit strChanged(st);
        qInfo() << "Str has changed";
    }

};


#endif
