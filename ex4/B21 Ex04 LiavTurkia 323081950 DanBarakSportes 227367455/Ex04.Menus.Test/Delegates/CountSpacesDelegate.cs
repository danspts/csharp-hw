using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegates
{
    public class CountSpacesDelegate : TerminalUIMenu
    {
        public CountSpacesDelegate() : base(new MenuAction<string>(UtilsDelegate.CountSpaces), "Count Spaces", null){}

    }
}