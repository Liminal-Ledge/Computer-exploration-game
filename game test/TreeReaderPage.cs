using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace game_test
{
    internal class TreeReaderPage

    {
        public TreeReaderPage() { 
            
        }
        internal static Window treeWin = new Window("File Explorer")
        {
            X = Pos.Percent(0), //instead of 0 becuase 0 will let the window slide
            Y = Pos.Percent(0)+1,

            Width = Dim.Percent(50),
            Height = Dim.Percent(63)
        };
        internal static Window reader = new Window("reader")
        {
            X = Pos.Percent(50),
            Y = 1,
            Width = Dim.Percent(50),
            Height = Dim.Fill()
        };
        internal static Window fileInfo = new Window("File Info")
        {
            X = Pos.Percent(0), //instead of 0 becuase 0 will let the window slide
            Y = Pos.Percent(65),
            Width = Dim.Percent(50),
            Height = Dim.Fill()
        };
        internal static TreeView<string> fileExplorer = new TreeView<string>(new DirTree())
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Percent(64),
            AllowLetterBasedNavigation = true,
            Bounds = new Rect(0, 0, Console.LargestWindowWidth/2, (Console.LargestWindowHeight/100)*65)
        };
        internal static TextView textView = new TextView()
        {
            X = 2,
            Y = 2,
            Width = Dim.Fill(),
            Height = Dim.Percent(90),
            WordWrap = true,
            ReadOnly = false,
            ColorScheme = ColorSchemes.ReaderPalette()

        };
        internal static Window pianoKeys = new Window("Piano")
        {
            X = Pos.Percent(0),
            Y = Pos.Percent(0),
            Height = Dim.Percent(50),
            Width = Dim.Fill(),
            };
        internal static Window content = new Window("Content")
        {
            X = Pos.Percent(0),
            Y = Pos.Percent(50),
            Height = Dim.Fill(),
            Width = Dim.Fill(),
        };

        internal ProgressBar MusicProgressBar = new ProgressBar()
        {   
            X = Pos.Percent(25),
            Y = Pos.Percent(90),
            Height = Dim.Sized(10),
            Width = Dim.Percent(50),
            ProgressBarStyle = ProgressBarStyle.Continuous,
            ColorScheme = ColorSchemes.ProgressBar(),
            Fraction = (Convert.ToSingle(song.stopWatch.ElapsedMilliseconds)/Convert.ToSingle(song.songLength)),
            
        };

        static Song song = new Song(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @"program files/piano/sample.txt"));
        private Button Player(string path)
        {
            Button play = new Button("Play")
            {
                X = Pos.Right(MusicProgressBar)+5,
                Y = Pos.Y(MusicProgressBar),
            };
            play.Clicked += () =>
            {
                
                song = new Song(path);
                var token = Application.MainLoop.AddIdle(() =>
                {
                    MusicProgressBar.Fraction = (Convert.ToSingle(song.stopWatch.ElapsedMilliseconds) / Convert.ToSingle(song.songLength));
                    return true;
                });
                new Thread(() => {
                    song.stopWatch.Start();
                    Piano.playSong(path);
                    song.stopWatch.Stop();
                    Application.MainLoop.RemoveIdle(token);
                }).Start();
                
                
            };
            return play;
        }
        static string GetName(string path) => Path.GetFileName(path);
        private void selectionEventHandler(object o, Terminal.Gui.Trees.SelectionChangedEventArgs<string> e)
        {
            var val = e.NewValue;
            if (val == null) { return; };
            var path = fileExplorer.SelectedObject;
            try { var test = Directory.GetFiles(path); }
            catch (Exception) {
                textView.Text = File.ReadAllText(path);
                TreeReaderPage.FileInfoInit(path);
                if ((new FileInfo(path)).Extension == ".msk")
                {
                    reader.Add(MusicProgressBar);
                    reader.Add(Player(path));
                }
            };
        }
        internal void fileExplorerInitializer(TreeView<string> fileExplorer)
        {
            string fileRoot = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @"Kashlov's computer\Root");
            fileExplorer.AddObject(fileRoot);
            fileExplorer.AspectGetter = GetName;
            fileExplorer.Style.ExpandableSymbol = '•';
            fileExplorer.SelectionChanged += selectionEventHandler;
        }
        private static string TypeFinder(FileInfo file)
        {
            switch (file.Extension)
            {
                case ".txt":
                    return "text file";
                case ".msk":
                    return "music file";
                default:
                    return file.Extension;
            }
        }
        private static void FileInfoInit(string path)
        {
            fileInfo.RemoveAll();
            var file = new FileInfo(path);
            Label title = new Label(String.Format("{0} {1}", "File Name:", file.Name))
            {
                X = 1,
                Y = 1,
            };
            Label size = new Label(String.Format("{0} {1} {2}", "Size:", file.Length, "Byte"))
            {
                X = 1,
                Y = 2,
            };
            Label type = new Label(String.Format("{0} {1}", "Type:", TypeFinder(file)))
            {
                X = 1,
                Y = 3,
            };
            Label creationDate = new Label(String.Format("{0} {1}", "Creation date:", file.CreationTime))
            {
                X = 1,
                Y = 4,
            };

            //Adding all these to the window
            fileInfo.Add(
                title, size, type, creationDate
                );
        }
        internal static void pageInit()
        {
            TreeReaderPage page = new TreeReaderPage();
            TreeReaderPage.treeWin.Add(TreeReaderPage.fileExplorer);
            TreeReaderPage.reader.Add(TreeReaderPage.textView);
            page.fileExplorerInitializer(TreeReaderPage.fileExplorer);
            
        }
    }
}
