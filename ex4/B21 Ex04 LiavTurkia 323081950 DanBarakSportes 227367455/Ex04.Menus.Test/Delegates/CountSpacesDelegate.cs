using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegates
{
    public class CountSpacesDelegate : TerminalUIMenu
    {
        private static MenuAction<string> menuAction = new MenuAction<string>();

        public CountSpacesDelegate() : base(i_MenuAction:new MenuAction<string>(), "Count Spaces", null)
        {
        }
    }
}