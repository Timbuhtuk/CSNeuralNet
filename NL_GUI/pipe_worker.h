#ifndef PIPEWORKER_H
#define PIPEWORKER_H

#include <QObject>
#include <QString>


class PipeWorker : public QObject
{
    Q_OBJECT
public:
    explicit PipeWorker(QObject* parent = nullptr);
public slots:
    void exec();

signals:
    void result(const QString&);


};

#endif // PIPEWORKER_H
