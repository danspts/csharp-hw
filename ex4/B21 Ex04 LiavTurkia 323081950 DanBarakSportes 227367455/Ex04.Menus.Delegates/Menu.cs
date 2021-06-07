using System;
using  System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;


namespace Ex04.Menus.Delegates
{
    public class Menu <T>
    {

        public delegate T UIInputDelegate(Type i_Type);

        public UIInputDelegate m_UIInput;
        public Action<object> MUiOut;
        private readonly string m_Name;

        private static T sr_quit;
        
        private static Menu<T> sr_Root;

        private MenuAction<T> m_MenuAction;

        private List<Menu<T>> m_MenuList;


        public Menu(MenuAction<T> i_MenuAction, string i_Name, List<Menu<T>> i_MenuList, Action<object> i_UIOut, UIInputDelegate i_UIInput, T i_Quit)
        {
            m_Name = i_Name;
            m_MenuList = i_MenuList;
            m_MenuAction = i_MenuAction;
            m_UIInput = i_UIInput;
            MUiOut = i_UIOut;
            sr_quit = i_Quit;
        }

        public Menu(bool i_Root, MenuAction<T> i_MenuAction, string i_Name, List<Menu<T>> i_MenuList, Action<object> i_UIOut, UIInputDelegate i_UIInput, T i_Quit) :
            this (i_MenuAction,  i_Name,  i_MenuList,  i_UIOut,  i_UIInput,  i_Quit)
        {
            if (i_Root)
            {
                sr_Root = this;
            }
        }
        
        public static Menu<T> Root
        {
            get { return sr_Root; }
        }
        
        public Action<object> Output
        {
            get { return MUiOut; }
            
        }

        public UIInputDelegate Input
        {
            get { return m_UIInput; }
        }
        
        public MenuAction<T> MenuAction
        {
            get { return m_MenuAction; }
            set { m_MenuAction = value; }
        }
        
        public List<Menu<T>> MenuList
        {
            get { return m_MenuList; }
        }
        
        public string Name {
            get { return this.m_Name;}
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
            Clear();
            while (true)
            {
                try
                {
                    object input = null;
                    
                    Output.Invoke(Name);
                    showMenuItem(this);

                    if (MenuList != null)
                    {
                        input = promptGetInput(this);
                        if (input.Equals(sr_quit))
                        {
                            break;
                        }
                    }
                    MenuAction.Action.Invoke(input);
                    break;
                }
                catch (Exception e)
                {
                    Output.Invoke(e);
                }
            }
        }
    }
}