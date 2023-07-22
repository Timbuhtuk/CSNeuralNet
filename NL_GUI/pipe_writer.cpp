#include "pipe_writer.h"


#ifdef _WIN32
#include <cstdlib>
#include <cstring>
#include "string"
#include "windows.h"
#include <stdio.h>
#include <conio.h>
#include <tchar.h>
#include <string.h>
#endif

#include <QDebug>

#define BUFSIZE 1024 * 64
#define PIPE_TIMEOUT 1024 * 20

void PipeWriter::start()
{
    // insert something useful here
}

void PipeWriter::write(const QString& message)
{
    qDebug() << "got into write actually";

#ifdef WIN32

    auto message2 = message + '\n';

    HANDLE hPipe;
    BOOL flg;
    DWORD dwWrite,dwRead;
    char szServerUpdate[200];
    char szClientUpdate[200];

    qDebug() << "creating pipe";

    hPipe = CreateNamedPipe (    TEXT("\\\\.\\pipe\\mynamedpipe"),
                            PIPE_ACCESS_DUPLEX,
                            PIPE_TYPE_MESSAGE |
                                PIPE_READMODE_MESSAGE,                  //HAS TO BE THIS
                            PIPE_UNLIMITED_INSTANCES,    // max. instances
                            BUFSIZE,                    // output buffer size
                            BUFSIZE,                    // input buffer size
                            PIPE_TIMEOUT,                // client time-out
                            NULL);                        // no security attribute

    if (hPipe == INVALID_HANDLE_VALUE)
        qDebug() << "invalid";

    qDebug() << "connecting pipe";
    ConnectNamedPipe(hPipe, NULL);

    qDebug() << "writing " << message2;


    char* msb = strdup(message2.toLocal8Bit().constData());


    qDebug() << "actually writing " << msb;

    strcpy( szServerUpdate, msb);

    //Write status to Client
    flg = WriteFile(hPipe, szServerUpdate, strlen(szServerUpdate), &dwWrite, NULL);

#endif
}
