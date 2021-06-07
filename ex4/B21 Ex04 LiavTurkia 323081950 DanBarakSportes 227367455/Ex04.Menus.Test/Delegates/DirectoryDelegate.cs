using System;
using System.Collections.Generic;
using Ex04.Menus.Delegates;
using Menu = Ex04.Menus.Delegates.Menu<string>;

namespace Ex04.Menus.Test.Delegates
{
    public class DirectoryDelegate : TerminalUIMenu
    {
        
        private UtilsDelegate m_Utils = new UtilsDelegate();

        public DirectoryDelegate( string i_Name, List<Menu> i_MenuList) : base(null, i_Name, i_MenuList)
        {
            MenuAction = new MenuAction<string>(NextMenu, Validate);
            
        }

        public DirectoryDelegate(bool i_Root, string i_Name, List<Menu> i_MenuList) : base( i_Root, null, i_Name, i_MenuList)
        {
            MenuAction = new MenuAction<string>(NextMenu, Validate);
        }

        internal UtilsDelegate Utils
        {
            get { return m_Utils; }
        }
        
        private bool Validate(object i_Input)
        {
            int inputInt = Utils.convert<int>(i_Input as string);
            return inputInt >= 0 && inputInt <= MenuList.Count;
        }

        private void NextMenu(object i_Input)
        {
            int inputInt = Utils.convert<int>(i_Input as string);
            MenuList[inputInt].Show();
        }
    }
}