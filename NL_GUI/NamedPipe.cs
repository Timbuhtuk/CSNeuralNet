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

        public static void Read() // Блокируящая функция чтения
        {
            Console.WriteLine("Waiting for the text to be sent");

            using (StreamReader sr = new StreamReader(pipeClient))
            {
                // Display the read text to the console
                string temp;
                while ((temp = sr.ReadLine()) != null)
                {
                    Console.WriteLine("Received from server: {0}", temp);
                }
            }
        }

    }
}

