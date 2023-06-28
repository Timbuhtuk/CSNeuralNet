#include "pipe_worker.h"
#include <QThread>
#include <QString>
#include <QByteArray>
#include <QDebug>
#include <thread>
#include <stdio.h>
#include <string>

#ifdef _WIN32
#include <windows.h>
#include <tchar.h>
#include <strsafe.h>
#endif

#include <iostream>
#include <string>

PipeWorker::PipeWorker(QObject* parent) : QObject{parent}
{

}

void PipeWorker::exec()
{

#ifdef _WIN32
    HANDLE hPipe;
    DWORD dwRead;
    char buffer[1024 * 64];

    hPipe = CreateNamedPipe(TEXT("\\\\.\\pipe\\mynamedpipe"),
                            PIPE_ACCESS_DUPLEX,
                            PIPE_TYPE_BYTE | PIPE_READMODE_BYTE | PIPE_WAIT,   // FILE_FLAG_FIRST_PIPE_INSTANCE is not needed but forces CreateNamedPipe(..) to fail if the pipe already exists...
                            1,
                            1024 * 64,
                            1024 * 64,
                            NMPWAIT_USE_DEFAULT_WAIT,
                            NULL);

    QString string;
    while (hPipe != INVALID_HANDLE_VALUE)
    {


        if (ConnectNamedPipe(hPipe, NULL) != FALSE)   // wait for someone to connect to the pipe
        {
            while (ReadFile(hPipe, buffer, sizeof(buffer) - 1, &dwRead, NULL) != FALSE)
            {
                /* add terminating zero */
                buffer[dwRead] = '\0';
                /* do something with data in buffer */


                qDebug("result recieved");
                emit result(QString::fromUtf8(buffer));

            }
        }

        DisconnectNamedPipe(hPipe);
        qDebug() << "pipe disconnected";
    }

#endif

}
