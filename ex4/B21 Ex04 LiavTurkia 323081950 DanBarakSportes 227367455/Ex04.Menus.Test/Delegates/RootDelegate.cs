using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegates
{
    public class RootDelegate : Menus.Delegates.TerminalUIMenu
    {

        private static MenuAction<string> menuAction = new MenuAction<string>();
        
        private static List<Menu> s_MenuList = new List<Menu>() { 
            new VersionAndSpacesDelegate(),
            new ShowDateTimeDelegate(),
        };
        
        public RootDelegate() : base(i_MenuAction:new MenuAction<string>(), "Main Menu", s_MenuList)
        {
        }
    }
}