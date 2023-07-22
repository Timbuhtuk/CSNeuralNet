#ifndef PIPE_WRITER_H_H
#define PIPE_WRITER_H_H


#include <QObject>
#include <QVariant>
#include <string>

class PipeWriter : public QObject
{
    Q_OBJECT

public:
    explicit PipeWriter(const std::string& pipePath = "mynamedpipe", QObject* parent = nullptr)
    {

    } //, QObject* parent = null);
    //explicit
    void start();


public slots:
    void write(const QString& text);

};

#endif
