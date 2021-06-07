using System.Collections.Generic;
using Menu = Ex04.Menus.Delegates.Menu<string>;

namespace Ex04.Menus.Test.Delegates
{
    public class VersionAndSpacesDelegate : DirectoryDelegate
    {
        private static List<Menu> s_MenuList = new List<Menu>() { 
            new BackDelegate(),
            new ShowVersionDelegate(),
            new CountSpacesDelegate(),
        };
        public VersionAndSpacesDelegate() : base("Version and Spaces", s_MenuList)
        {
        }
    }
}