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


signals:
    void startWorker();
    void dataFetched(QString);
    void strChanged(QString);
    void initDataFetched(QList<QVariant> data);
    void weightDataFetched(QVariant layer, QVariant  neuron, QVariant weight, QVariant value);
    void weightFetchedFlat(QVariant number, QVariant value);

public slots:
    void getResult(const QString& str)
    {
        qDebug() << "Get result function triggered";

        auto qstrSplit{ str.split(':') };
        auto key{ qstrSplit[0] };
        auto value{ qstrSplit[1] };
        QVariantList list;
        auto values = value.trimmed().split(' ');
        if (key == "INIT")
        {
            qDebug() << "Emitting init function";

            for (const auto& el :  value.split(' '))
            {
                list.append(QVariant::fromValue(el.toInt()));
            }

            emit initDataFetched(list);
        }
        else if (key == "WEIGHT")
        {
            qDebug() << "Emitting changed function";

            int redValue{static_cast<int>(values[3].toDouble() * 255.0)};

            emit weightDataFetched(QVariant::fromValue(values[0].toInt()),
                                   QVariant::fromValue(values[1].toInt()),
                                   QVariant::fromValue(values[2].toInt()),
                                   QVariant::fromValue(redValue));

            qDebug() << "Values: " << QVariant::fromValue(values[0].toInt()) <<
                QVariant::fromValue(values[1].toInt()) <<
                QVariant::fromValue(values[2].toInt()) <<
                QVariant::fromValue(redValue) << " emitted";
        }

        else if (key == "WEIGHTFLAT")
        {
            emit weightFetchedFlat(QVariant::fromValue(values[0]),
                                   QVariant::fromValue(values[1])
                                   );


        }

        else
        {
            qDebug() << "Nothing has been emitted";
        }


    }

    void setStr(const QString& st) { *m_str = st; emit strChanged(st);
        qInfo() << "Str has changed"; }

};


#endif
