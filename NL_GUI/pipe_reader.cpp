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
    QString value{ qstrSplit[1] };
    auto values = value.trimmed().split(' ');
    if (key == "INITPRINT")
    {
        qDebug() << "NOT initializing with values: " << getInitData(value);


        // emit initDataFetched(getInitData(value));
    }

    else if (key == "INIT")
    {
        emit initDataFetched(getInitData(value));
    }

    else if (key == "WEIGHT")
    {
        qDebug() << "Emitting changed function";

        int redValue{static_cast<int>(values[3].toDouble() * 255.0)};

        emit weightDataFetched(QVariant::fromValue(values[0].toInt()),
                               QVariant::fromValue(values[1].toInt()),
                               QVariant::fromValue(values[2].toInt()),
                               QVariant::fromValue(redValue));
    }

    else if (key == "WEIGHTS")
    {
        qDebug() << "Weights triggered";
        emitResults(value, false);
    }

    else if (key == "WEIGHTSPRINT")
    {
        qDebug() << "Weights triggered";
        emitResults(value, true);
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


// TODO
QString PipeReader::convertToRGBA(int r, int g, int b, int a)
{
    return {};
}

void PipeReader::emitResults(const QString& str, bool print) {

    QList<QString> layers{str.split('|')};
    QList<QString> neurons;
    QList<QString> weights;
    int redValue{};

    for (int layerIndex{0}; layerIndex < layers.size(); ++layerIndex)
    {
        neurons = layers[layerIndex].split('*');

        for (int neuronIndex{}; neuronIndex < neurons.size(); ++neuronIndex)
        {
            weights = neurons[neuronIndex].split('/');

            for (int weightIndex{}; weightIndex < weights.size(); ++weightIndex)
            {
                if (print)
                {
                    qDebug() << "Value: " << weights[weightIndex] <<
                        "; layer: " << layerIndex <<
                        "; neuron: " << neuronIndex <<
                        "; weight: " << weightIndex;
                    continue;
                }


                redValue = static_cast<int>(weights[weightIndex].toDouble() * 255.0);
                emit weightDataFetched(layerIndex, neuronIndex, weightIndex, redValue);

            }
        }
    }
}

QList<QVariant> PipeReader::getInitData(const QString& str) {

    QList<QString> layers{str.split('|')};
    QList<QString> neurons;

    QList<QVariant> nlData;

    for (int layerIndex{}; layerIndex < layers.size(); ++layerIndex)
    {
        neurons = layers[layerIndex].split('*');
        nlData.append(QVariant::fromValue(neurons.size()));
    }

    return nlData;
}

void PipeReader::start()
{

    qInfo() << "Start function executed";
    emit startWorker();
}

