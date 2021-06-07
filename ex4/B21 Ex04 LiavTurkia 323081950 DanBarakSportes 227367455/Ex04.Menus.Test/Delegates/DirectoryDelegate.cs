using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ex04.Menus.Delegates;
using Menu = Ex04.Menus.Delegates.Menu<string>;

namespace Ex04.Menus.Test.Delegates
{
    public class DirectoryDelegate : TerminalUIMenu
    {
        private readonly UtilsDelegate r_Utils = new UtilsDelegate();

        public DirectoryDelegate(string i_Name, List<Menu> i_MenuList)
            : base(null, i_Name, i_MenuList)
        {
            this.MenuAction = new MenuAction<string>(this.NextMenu, this.Validate, i_Requirements: this.getRequirements);
        }

        public DirectoryDelegate(bool i_Root, string i_Name, List<Menu> i_MenuList)
            : base(i_Root, null, i_Name, i_MenuList)
        {
            this.MenuAction = new MenuAction<string>(this.NextMenu, this.Validate, i_Requirements: this.getRequirements);
        }

        internal UtilsDelegate Utils
        {
            get { return this.r_Utils; }
        }

        private bool Validate(object i_Input)
        {
            int inputInt = this.Utils.Convert<int>(i_Input as string);
            return inputInt >= 0 && inputInt < this.MenuList.Count;
        }

        private void NextMenu(object i_Input)
        {
            int inputInt = this.Utils.Convert<int>(i_Input as string);
            this.MenuList[inputInt].Show();
        }

        private string getRequirements()
        {
            return string.Format(" Inputs should have the range: {0} to {1} ", 0, this.MenuList.Count - 1);
        }
    }
}