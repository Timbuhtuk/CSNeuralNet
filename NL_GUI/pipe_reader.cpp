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

void PipeReader::start()
{

    qInfo() << "Start function executed";
    emit startWorker();
}

