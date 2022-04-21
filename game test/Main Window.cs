using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace game_test
{
    internal class MainWindow
    {
        internal static  Window win = new Window("Home computer")
        {
            X = 0,
            Y = 1,

            Width = Dim.Fill(),
            Height = Dim.Fill(),
        };
        internal static MenuBar menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_menu", new MenuItem [] {
                new MenuItem ("_Reboot", "", null),
                new MenuItem ("_Shut Down", "", () => {
                    Application.Shutdown(); Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(File.ReadAllText(Path.Combine(Program.gameDir, @"Program files\Computer mother board logo.txt")));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ResetColor();
                    Thread.Sleep(500);
                    Environment.Exit(0);
                                    })
                         }),
            new MenuBarItem ("_Theme", new MenuItem [] {
                new MenuItem ("_Default", "", () =>
                    {
                        win.ColorScheme = ColorSchemes.DefaultTheme();
                        Application.Top.ColorScheme = ColorSchemes.DefaultTheme();
                        Application.Top.MenuBar.ColorScheme = ColorSchemes.DefaultTheme();
                        foreach (View view in Application.Top.Subviews)
                        {
                        view.ColorScheme = ColorSchemes.DefaultTheme();
                        };
                    }),
                new MenuItem ("_Death's Calling", "", () => {
                        win.ColorScheme = ColorSchemes.DeathsCalling();
                        Application.Top.ColorScheme = ColorSchemes.DeathsCalling();
                        Application.Top.MenuBar.ColorScheme = ColorSchemes.DeathsCalling();
                        foreach (View view in Application.Top.Subviews)
                        {
                        view.ColorScheme = ColorSchemes.DeathsCalling();
                        };
                                    }),
                new MenuItem ("_Winter's burry", "", () => {
                        win.ColorScheme = ColorSchemes.WinterBurry();
                        Application.Top.ColorScheme = ColorSchemes.WinterBurry();;
                        Application.Top.MenuBar.ColorScheme = ColorSchemes.WinterBurry();
                    foreach (View view in Application.Top.Subviews)
                        {
                        view.ColorScheme = ColorSchemes.WinterBurry();
                        };
                                    })

                         })
                    });
    }
}
