using System;
using Terminal.Gui;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;



namespace game_test
{
    internal class Program
    {   
        //Control over console window - not my code*****
        [DllImport("kernel32.dll", ExactSpelling = true)]

        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;
        //**********************************************
        
        internal static string gameDir = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        internal static string exePath = Path.Combine(Environment.CurrentDirectory, @"game test.exe");
        public static void ColorSetting()
        {
            Colors.Base= ColorSchemes.DefaultTheme();
            Colors.Menu = ColorSchemes.DefaultTheme();
        }
        static void Main(string[] args)
        {
            ShowWindow(ThisConsole, MAXIMIZE);
            BootPage.Bios();
            Console.Clear();
            Thread.Sleep(300);
            Application.Init();
            Piano.Init();
            ColorSetting();
            Toplevel top = Application.Top;
            LoginPage.loginInit(top, MainWindow.win);
            top.Add(MainWindow.menu);
            Application.Run();
        }
    }
}