using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;


namespace game_test
{
    internal static class BootPage
    {   
        internal static void LoadingDots()
        {
            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(200);
                Console.Write(" .");
                Thread.Sleep(200);
                Console.Write(" .");
                Thread.Sleep(200);
                Console.Write(" .");
                Thread.Sleep(200);
                Console.Write("\b" + "\b" + "\b" + "\b" + "\b" + "\b");
                Console.Write("       ");
                Console.Write("\b" + "\b" + "\b" + "\b" + "\b" + "\b" + "\b");

            }
        }
        internal static void Bios()
        {
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            var lines = File.ReadAllLines(Path.Combine(Program.gameDir, @"Program Files/startup.txt"));
            SystemSounds.SwitchOnSound();
            for (int i = 0; i < lines.Length; i++)
            {
                
                if (i <= 6)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(lines[i]);
                }
                else if (i == 7)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(50);
                    Console.WriteLine(lines[i]);
                }
                else if (i == lines.Length - 1)
                {
                    Thread.Sleep(300);
                    Console.Write(lines[i]);
                }
                else
                {
                    Thread.Sleep(300);
                    Console.WriteLine(lines[i]);
                }
            }
            LoadingDots();
            Console.ResetColor();
        }
    }
}
