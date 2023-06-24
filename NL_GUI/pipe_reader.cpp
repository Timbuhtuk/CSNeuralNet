#include "pipe_worker.h"
#include "pipe_reader.h"
#include <QDebug>

#include <QVariant>
#include <QVariantList>

PipeReader::PipeReader(QObject* parent)
    : QObject{parent},
      m_thread{new QThread},
      m_str{new QString{"None yyet"}},
      m_worker{new PipeWorker}
{
    m_worker->moveToThread(&m_thread);
    connect(&m_thread, &QThread::finished, m_worker, &QObject::deleteLater);
    connect(m_worker, SIGNAL(result(QString)), this, SLOT(getResult(QString)));
    connect(this, SIGNAL(startWorker()), m_worker, SLOT(exec()));
    m_thread.start();

}

void PipeReader::getResult(const QString& str)
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

void PipeReader::start()
{

    qInfo() << "Start function executed";
    emit startWorker();
}

