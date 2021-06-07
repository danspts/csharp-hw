using System.Collections.Generic;
using Menu = Ex04.Menus.Delegates.Menu<string>;

namespace Ex04.Menus.Test.Delegates
{
    public class ShowDateTimeDelegate : DirectoryDelegate
    {
        private static readonly List<Menu> sr_MenuList = new List<Menu>()
        {
            new BackDelegate(),
            new ShowDateDelegate(),
            new ShowTimeDelegate(),
        };

        public ShowDateTimeDelegate()
            : base("Show Date / Time", sr_MenuList)
        {
        }
    }
}