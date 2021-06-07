using System.Collections.Generic;
using Menu = Ex04.Menus.Delegates.Menu<string>;

namespace Ex04.Menus.Test.Delegates
{
    public class RootDelegate : DirectoryDelegate
    {

        private static List<Menu> s_MenuList = new List<Menu>() { 
            new ExitDelegate(),
            new VersionAndSpacesDelegate(),
            new ShowDateTimeDelegate(),
        };
        
        public RootDelegate() : base(i_Root:true, "Main Menu", s_MenuList)
        {
        }
    }
}