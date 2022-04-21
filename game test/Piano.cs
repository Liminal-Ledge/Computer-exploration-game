using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_test
{
    internal static class Piano
    {
        static int[] frequencies = new int[86];
        static string[] keyNames = new string[86];

        internal static void Init()
        {
            string[] strFreq = File.ReadAllLines(Path.Combine(Program.gameDir, @"Program files/Piano/Piano Key Frequencies.txt"));
            keyNames = File.ReadAllLines(Path.Combine(Program.gameDir, @"Program files/Piano/Piano Key Names.txt"));
            int j = 0;
            for (int i = 0; i < 86; i++)
            {   
                frequencies[i] = (int) Math.Round(Double.Parse(strFreq[j]));
                if (keyNames[i].Contains("/"))
                {
                    keyNames[i] = keyNames[i].Remove(keyNames[i].Length - 1);
                }
                else
                {
                    j++;
                }
            }
        }
        internal static void playKey(string key, int duration)
        {
            int frequency = frequencies[Array.IndexOf(keyNames, key)];
            Console.Beep(frequency, duration);
        }
        internal static void playSong(string path)
        {
            string[] song = File.ReadAllLines(path);
            for (int i = 0; i < song.Length; i = i + 2)
            {
                playKey(song[i], int.Parse(song[i+1]));
            }
        }

    }
}
