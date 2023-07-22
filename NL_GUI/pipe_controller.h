#ifndef PIPE_READER_H
#define PIPE_READER_H

#include "pipe_reader.h"
#include "pipe_writer.h"

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
    PipeWriter* m_writer;
    QThread m_thread;
    QThread m_writerThread;

public:
    PipeReader(QObject* parent = nullptr);
    Q_INVOKABLE void start();
    Q_INVOKABLE void writemsg(QVariant message);
    QString str() { return *m_str; }


    void emitResults(const QString& str, bool print = true);
    QList<QVariant> getInitData(const QString& str);
    QString convertToRGBA(int r, int g, int b, int a);



signals:
    void startWorker();
    void dataFetched(const QString&);
    void strChanged(const QString&);
    void initDataFetched(QList<QVariant> data);
    void weightDataFetched(QVariant layer, QVariant  neuron, QVariant weight, QVariant value);
    void weightFetchedFlat(QVariant number, QVariant value);
    void writeMessage(QString message);

public slots:
    void getResult(const QString& str);

    void setStr(const QString& st)
    {
        *m_str = st; emit strChanged(st);
        qInfo() << "Str has changed";
    }

};


#endif
