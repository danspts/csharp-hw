using Ex04.Menus.Delegates;
using Menu = Ex04.Menus.Delegates.Menu<string>;

namespace Ex04.Menus.Test.Delegates
{
    public class BackDelegate : TerminalUIMenu
    {
        public BackDelegate() : base(null, "Back To Main Menu", null) {}
    }
}