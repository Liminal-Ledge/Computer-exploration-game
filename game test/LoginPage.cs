using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace game_test
{
    internal static class LoginPage
    {
        private static Label login = new Label("Login: ") { X = Pos.Center() - ("login:".Length + (40 / 2)), Y = Pos.Center() - 2 };
        private static Label password = new Label("Password: ")
        {
            X = Pos.Left(login),
            Y = Pos.Top(login) + 1
        };
        private static TextField loginText = new TextField("")
        {
            X = Pos.Right(password),
            Y = Pos.Top(login),
            Width = 40
        };
        private static TextField passText = new TextField("")
        {
            Secret = true,
            X = Pos.Left(loginText),
            Y = Pos.Top(password),
            Width = Dim.Width(loginText)
        };
        private static Button ok = new Button()
        {
            X = Pos.Center(),
            Y = Pos.Bottom(loginText) + 2,
            Text = "OK"
        };


        private static void buttonInit(Toplevel top, Window win)
        {
            ok.Clicked += () => {
                if ((passText.Text == "test") & (loginText.Text == "test"))
                {
                    top.Remove(win);

                    top.Add(TreeReaderPage.treeWin, TreeReaderPage.reader, TreeReaderPage.fileInfo);
                    TreeReaderPage.pageInit();
                   
                }
                else
                {
                    SystemSounds.Failure();
                    MessageBox.Query(50, 7, "Connection denied", "incorrect password or login", "ok"); 
                }
            };
        }
        internal static void loginInit(Toplevel top, Window win)
        {   
            buttonInit(top, win);
            win.Add(
                 login, password, loginText, passText, ok
                    );
            top.Add(win);
        }
    }
}
