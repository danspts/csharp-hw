using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegates
{
    public class ShowTimeDelegate : TerminalUIMenu
    {
        private static MenuAction<string> menuAction = new MenuAction<string>();

        public ShowTimeDelegate() : base(i_MenuAction:new MenuAction<string>(),"Show Time", null)
        {
        }
    }
}