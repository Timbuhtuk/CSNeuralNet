#include "pipe_worker.h"
#include <QThread>
#include <QString>
#include <QDebug>
#include <thread>
#include <stdio.h>

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
    emit result("WEIGHT: 0 0 0 0.1");
    emit result("WEIGHT: 0 0 0 0.9");

#ifdef _WIN32
    HANDLE hPipe;
    char buffer[1024];
    DWORD dwRead;

    hPipe = CreateNamedPipe(TEXT("\\\\.\\pipe\\mynamedpipe"),
                            PIPE_ACCESS_DUPLEX,
                            PIPE_TYPE_BYTE | PIPE_READMODE_BYTE | PIPE_WAIT,   // FILE_FLAG_FIRST_PIPE_INSTANCE is not needed but forces CreateNamedPipe(..) to fail if the pipe already exists...
                            1,
                            1024 * 16,
                            1024 * 16,
                            NMPWAIT_USE_DEFAULT_WAIT,
                            NULL);

    while (hPipe != INVALID_HANDLE_VALUE)
    {
        if (ConnectNamedPipe(hPipe, NULL) != FALSE)   // wait for someone to connect to the pipe
        {
            while (ReadFile(hPipe, buffer, sizeof(buffer) - 1, &dwRead, NULL) != FALSE)
            {
                /* add terminating zero */
                buffer[dwRead] = '\0';
                /* do something with data in buffer */
                emit result(QString{buffer});
                // printf("%s", buffer);
            }
        }

        DisconnectNamedPipe(hPipe);
    }
#endif

}
