using System;
using  System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;


namespace Ex04.Menus.Delegates
{
    public class Menu
    {

        public delegate object UIInputDelegate(Type i_Type);

        public UIInputDelegate m_UIInput;
        public Action<object> MUiOut;
        private readonly string m_Name;

        private static object sr_quit;
        
        private readonly Menu r_Root;

        private MenuAction<object> m_MenuAction;
        
        private List<Menu> m_MenuList;

        Action<object> Output
        {
            get { return MUiOut; }
        }

        UIInputDelegate Input
        {
            get { return m_UIInput; }
        }
        
        MenuAction<object> MenuAction
        {
            get { return m_MenuAction; }
        }
        
        internal List<Menu> MenuList
        {
            get { return m_MenuList; }
        }
        
        public string Name {
            get { return this.m_Name;}
        }

        public Menu(List<Menu> i_MenuActions )
        {
            m_MenuList = i_MenuActions;
        }
        
        public Menu(string i_Name, List<Menu> i_MenuList, Action<object> i_UIOut, UIInputDelegate i_UIInput, object i_Quit)
        {
            m_Name = i_Name;
            m_MenuList = i_MenuList;
            m_UIInput = i_UIInput;
            MUiOut = i_UIOut;
            sr_quit = i_Quit;
        }

        private static object promptGetInput(Menu i_Menu)
        {
            object input = i_Menu.Input.Invoke(i_Menu.m_MenuAction.Type);

            if (!i_Menu.MenuAction.Verify.Invoke(input))
            {
                throw new FormatException(string.Format("Logic-invalid: {0}", i_Menu.MenuAction.Requirements.Invoke()));
            }
            return input;
        }
        
        private static object showMenuItem(Menu i_Menu)
        {
            i_Menu.Output(i_Menu.m_MenuAction.Description.Invoke());
            return promptGetInput(i_Menu);
        }

        public void Show()
        {
            Show(r_Root);
        }
        
        public static void Show(Menu i_Menu)
        {
            while (true)
            {
                i_Menu.Output(i_Menu.Name);
                i_Menu.Output(i_Menu.m_MenuList);
                try
                {
                    object nextMenu = showMenuItem(i_Menu);
                    if (nextMenu == sr_quit)
                    {
                        break;
                    }
                    else
                    {
                        Show(i_Menu.MenuAction.Action.Invoke(nextMenu));
                    }
                }
                catch (Exception e)
                {
                    i_Menu.Output(e.Message);
                }
            }
        }
    }
}