using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Terminal.Gui;

namespace game_test
{
    internal class Song
    {
        public Song(string path)
        {
            this.path = path;
            this.songLength = Song.SongLength(path);
        }
        internal string path;
        internal int songLength;
        internal static int SongLength(string path)
        {
            string[] song = File.ReadAllLines(Path.Combine(Program.gameDir, @"Kashlov's computer\", path));
            var time = 0;
            for (int i = 1; i < song.Length; i = i + 2)
            {
                time += int.Parse(song[i]);
            }
            return time;
        }
        internal Stopwatch stopWatch = new Stopwatch();
       
        internal static float Fraction(Stopwatch stopWatch,  int length)
        {
            return (Convert.ToSingle(stopWatch.ElapsedMilliseconds)/Convert.ToSingle(length));
        }
        internal void progressTracker(ProgressBar bar, Song song)
        {
          
                while (stopWatch.ElapsedMilliseconds <= songLength)
                {
                    bar.Fraction = Fraction(stopWatch, songLength);
                    Thread.Sleep(10);
                };
                song.stopWatch.Stop();

        }
    }
}
