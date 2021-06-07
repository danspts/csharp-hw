using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegates
{
    public class ShowDateTimeDelegate : TerminalUIMenu
    {
        private static List<Menu> s_MenuList = new List<Menu>() { 
            new ShowDateDelegate(),
            new ShowTimeDelegate(),
        };
        public ShowDateTimeDelegate() : base(i_MenuAction:new MenuAction<string>(),"Show Date / Time", s_MenuList)
        {
        }
    }
}