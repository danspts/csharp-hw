using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegates
{
    public class VersionAndSpacesDelegate : TerminalUIMenu
    {
        private static List<Menu> s_MenuList = new List<Menu>() { 
            new ShowVersionDelegate(),
            new CountSpacesDelegate(),
        };
        public VersionAndSpacesDelegate() : base("Version and Spaces", s_MenuList)
        {
        }
    }
}