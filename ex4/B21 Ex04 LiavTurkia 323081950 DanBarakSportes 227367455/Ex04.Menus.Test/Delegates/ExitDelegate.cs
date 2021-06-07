using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegates
{
    public class ExitDelegate : TerminalUIMenu
    {
        public ExitDelegate() : base(new MenuAction<string>(UtilsDelegate.Quit), "Exit", null){}
    }
}