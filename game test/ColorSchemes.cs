using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace game_test
{
    internal static class ColorSchemes
    {
        internal static ColorScheme ReaderPalette()
        {
            var colorScheme = new ColorScheme();
            colorScheme.Normal = Application.Driver.MakeAttribute(Color.White, Color.Black);
            colorScheme.Focus = Application.Driver.MakeAttribute(Color.White, Color.Black);
            return colorScheme;
        }
        internal static ColorScheme ProgressBar()
        {
            var colorScheme = new ColorScheme();
            colorScheme.Normal = Application.Driver.MakeAttribute(Color.Green, Color.DarkGray);
            colorScheme.Focus = Application.Driver.MakeAttribute(Color.Green, Color.DarkGray);
            return colorScheme;
        }
        internal static ColorScheme DefaultTheme()
        {
            var colorScheme = new ColorScheme();
            colorScheme.Normal = Application.Driver.MakeAttribute(Color.Green, Color.Black);
            colorScheme.Focus = Application.Driver.MakeAttribute(Color.Black, Color.White);
            colorScheme.HotNormal = Application.Driver.MakeAttribute(Color.Green, Color.Black);
            colorScheme.HotFocus = Application.Driver.MakeAttribute(Color.Black, Color.White);
            return colorScheme;
        }
        internal static ColorScheme DeathsCalling()
        {
            var colorScheme = new ColorScheme();
            colorScheme.Normal = Application.Driver.MakeAttribute(Color.Red, Color.Black);
            colorScheme.Focus = Application.Driver.MakeAttribute(Color.Red, Color.DarkGray);
            colorScheme.HotNormal = Application.Driver.MakeAttribute(Color.Red, Color.Black);
            colorScheme.HotFocus = Application.Driver.MakeAttribute(Color.Red, Color.DarkGray);
            return colorScheme;
        }
        internal static ColorScheme WinterBurry()
        {
            var colorScheme = new ColorScheme();
            colorScheme.Normal = Application.Driver.MakeAttribute(Color.Blue, Color.DarkGray);
            colorScheme.Focus = Application.Driver.MakeAttribute(Color.Blue, Color.DarkGray);
            colorScheme.HotNormal = Application.Driver.MakeAttribute(Color.Blue, Color.DarkGray);
            colorScheme.HotFocus = Application.Driver.MakeAttribute(Color.Blue, Color.DarkGray);
            return colorScheme;
        }
    }
}
