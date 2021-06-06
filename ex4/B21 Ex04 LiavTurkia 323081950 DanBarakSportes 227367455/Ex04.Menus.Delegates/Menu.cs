using System;
using  System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;


namespace Ex04.Menus.Delegates
{
    public class Menu
    {

        public delegate object UIInputDelegate(object obj);

        public UIInputDelegate m_UIInput;
        public Action<object> m_UIout;

        private static readonly object sr_quit;
        
        private readonly Menu r_Root;

        private MenuAction<object> m_MenuAction;

        private static readonly string sr_Line = new string('-', 85);

        private List<Menu> m_Menus;
        

        public Menu(List<Menu> i_MenuActions)
        {
            m_Menus = i_MenuActions;
        }
        
        public Menu(List<Menu> i_MenuActions, Action<object> i_UIout, UIInputDelegate i_UIInput, object sr_quit)
        {
            m_Menus = i_MenuActions;
            m_UIInput = i_UIInput;
            m_UIout = i_UIout;
        }

        private static object promptGetInput(MenuAction<object> i_MenuAction)
        {
            object outObject;
            
            string command = Console.ReadLine();

            TypeConverter converter = TypeDescriptor.GetConverter(i_MenuAction.Type);

            if (converter.CanConvertFrom(typeof(string)))
            {
                if (!converter.IsValid(command))
                {
                    throw new FormatException(string.Format("Syntax-invalid: not of type {0}", i_MenuAction.Type));
                }

                try
                {
                    outObject = converter.ConvertFromString(command);
                }
                catch
                {
                    throw new FormatException(string.Format("Syntax-invalid: not of type {0}", i_MenuAction.Type));
                }
            }
            else
            {
                outObject = command;
            }

            if (!i_MenuAction.Verify.Invoke(outObject))
            {
                throw new FormatException(string.Format("Logic-invalid: {0}", i_MenuAction.Requirements.Invoke()));
            }

            return outObject;
        }
        
        private static Menu showMenuItem(Menu i_Menu)
        {
            i_Menu.m_MenuAction.Description.Invoke();
            return i_Menu.m_MenuAction.Action.Invoke(promptGetInput(i_Menu.m_MenuAction));
        }
        
        public void Show()
        {
            Menu currentItem = this.r_Root;
            while (true)
            {
                
                if (currentItem == this.r_Root)
                {
                    
                }
            }
        }
    }
}