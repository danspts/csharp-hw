using System;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;

using Menu = Ex04.Menus.Delegates.Menu<string>;

namespace Ex04.Menus.Delegates
{
    public class TerminalUIMenu : Menu
    {
        private static readonly string sr_Line = new string('-', 85);
        
        public TerminalUIMenu(MenuAction<string> i_MenuAction, string i_Name, List<Menu<string>> i_MenuList) : base(i_MenuAction, i_Name, i_MenuList, i_UIOut: getOutput, i_UIInput: promptGetInput, i_Quit: "0")
        { 
        }
        
        public TerminalUIMenu(bool i_Root, MenuAction<string> i_MenuAction, string i_Name, List<Menu> i_MenuList) : base(i_Root, i_MenuAction, i_Name, i_MenuList, i_UIOut: getOutput, i_UIInput: promptGetInput, i_Quit: "0")
        { 
        }
        
        private static void printToConsole(Menu i_menu)
        {
            StringBuilder builder = new StringBuilder();

            builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("\t\t\t\tChoose a command: ");
            builder.AppendLine(sr_Line);

            List<Menu> children = i_menu.MenuList;

            for (int i = 0; i < children.Count; ++i)
            {
                builder.AppendLine(string.Format("{0}: {1}", i, children[i].Name));
            }
            
            builder.AppendLine(sr_Line);
            builder.Append("Number:  ");
            Console.WriteLine(builder.ToString());

        }

        private static void printToConsole(string i_String)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine(i_String);
            builder.AppendLine(sr_Line);
            Console.WriteLine(builder.ToString());
        }
        
        private static void printToConsole(Exception i_Exception)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("/!\\" + i_Exception.Message + "/!\\");
            builder.AppendLine(sr_Line);
            Console.WriteLine(builder.ToString());
        }


        private static void getOutput(object i_Object)
        {
            if (i_Object is string)
            {
                printToConsole(i_Object as string);
            }
            else if (i_Object is Menu)
            {
                printToConsole(i_Object as Menu);
            }
            else if (i_Object is Exception)
            {
                printToConsole(i_Object as Exception);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public override void Clear()
        {
            Console.Clear();
        }

        private static string promptGetInput(Type i_Type)
        {
            string command = Console.ReadLine();
            return command;
        }
    }
}