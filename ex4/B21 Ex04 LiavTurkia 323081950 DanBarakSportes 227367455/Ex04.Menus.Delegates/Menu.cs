using System;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ex04.Menus.Delegates
{
    public class Menu<T>
    {
        private static T s_Quit;
        private static Menu<T> s_Root;

        private readonly Action<object> r_UIOut;
        private readonly string r_Name;
        private readonly List<Menu<T>> r_MenuList;
        private readonly UIInputDelegate r_UIInput;
        private MenuAction<T> m_MenuAction;

        public delegate T UIInputDelegate(Type i_Type);

        public Menu(MenuAction<T> i_MenuAction, string i_Name, List<Menu<T>> i_MenuList, Action<object> i_UIOut, UIInputDelegate i_UIInput, T i_Quit)
        {
            this.r_Name = i_Name;
            this.r_MenuList = i_MenuList;
            this.m_MenuAction = i_MenuAction;
            this.r_UIInput = i_UIInput;
            this.r_UIOut = i_UIOut;
            s_Quit = i_Quit;
        }

        public Menu(bool i_Root, MenuAction<T> i_MenuAction, string i_Name, List<Menu<T>> i_MenuList, Action<object> i_UIOut, UIInputDelegate i_UIInput, T i_Quit)
            : this(i_MenuAction,  i_Name,  i_MenuList,  i_UIOut,  i_UIInput,  i_Quit)
        {
            if (i_Root)
            {
                s_Root = this;
            }
        }

        public static Menu<T> Root
        {
            get { return s_Root; }
        }

        public Action<object> Output
        {
            get { return this.r_UIOut; }
        }

        public UIInputDelegate Input
        {
            get { return this.r_UIInput; }
        }

        public MenuAction<T> MenuAction
        {
            get { return this.m_MenuAction; }
            set { this.m_MenuAction = value; }
        }

        public List<Menu<T>> MenuList
        {
            get { return this.r_MenuList; }
        }

        public string Name
        {
            get { return this.r_Name; }
        }

        public virtual void Clear()
        {
            throw new NotImplementedException();
        }

        private static T promptGetInput(Menu<T> i_Menu)
        {
            T input = i_Menu.Input.Invoke(i_Menu.MenuAction.Type);

            if (!i_Menu.MenuAction.Verify.Invoke(input))
            {
                throw new FormatException(string.Format("Logic-invalid: {0}", i_Menu.MenuAction.Requirements.Invoke()));
            }

            return input;
        }

        private static void showMenuItem(Menu<T> i_Menu)
        {
            if (i_Menu.MenuList != null && i_Menu.MenuList.Count > 0)
            {
                i_Menu.Output.Invoke(i_Menu);
            }
        }

        public void Show()
        {
            this.Clear();
            while (true)
            {
                try
                {
                    object input = null;

                    this.Output.Invoke(this.Name);
                    showMenuItem(this);

                    if (this.MenuList != null)
                    {
                        input = promptGetInput(this);
                        if (input.Equals(s_Quit))
                        {
                            break;
                        }
                    }

                    this.MenuAction.Action.Invoke(input);
                    this.Clear();
                }
                catch (Exception e)
                {
                    this.Output.Invoke(e);
                }
            }
        }
    }
}