using System.Collections.Generic;
using Ex04.Menus.Delegates;
using Menu = Ex04.Menus.Delegates.Menu<string>;

namespace Ex04.Menus.Test.Delegates
{
    public class ShowVersionDelegate : TerminalUIMenu
    {
        public ShowVersionDelegate()
            : base(new MenuAction<string>(UtilsDelegate.ShowVersion), "Show Version", null)
        {
        }
    }
}