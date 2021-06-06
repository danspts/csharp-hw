using System.Collections.Generic;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test.Delegates
{
    public class ShowVersionDelegate : TerminalUIMenu
    {
        public ShowVersionDelegate() : base("Show Version", null)
        {
        }
    }
}