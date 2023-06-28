using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace C_N_own
{
    class NamedPipe
    {

        public static NamedPipeClientStream pipeClient{ get; protected set; }

        // Windows реализация
        static NamedPipe()
        {
            Console.WriteLine("Waiting for server to connect to the pipe...");
            pipeClient = new NamedPipeClientStream(".", "mynamedpipe", PipeDirection.InOut);
            pipeClient.Connect();
            Console.WriteLine("Server connected.");
        }

        public static void Write(string text)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(text + '\n');
            pipeClient.Write(messageBytes, 0, messageBytes.Length);
        }
    }
}

