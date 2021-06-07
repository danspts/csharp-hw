using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegates
{
    public class ShowTimeDelegate : TerminalUIMenu
    {
        public ShowTimeDelegate()
            : base(i_MenuAction: new MenuAction<string>(UtilsDelegate.ShowTime), "Show Time", null)
        {
        }
    }
}