using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegates
{
    public class ShowDateDelegate : TerminalUIMenu
    {
        public ShowDateDelegate()
            : base(null, "Show Date", null)
        {
            this.MenuAction = new MenuAction<string>(UtilsDelegate.ShowDate);
        }
    }
}