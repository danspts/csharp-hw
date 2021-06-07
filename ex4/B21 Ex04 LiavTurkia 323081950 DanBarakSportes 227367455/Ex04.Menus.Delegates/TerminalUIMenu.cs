using System;
using System.ComponentModel;
using System.Text;
using System.Collections.Generic;


namespace Ex04.Menus.Delegates
{
    public class TerminalUIMenu : Menu
    {
        private static readonly string sr_Line = new string('-', 85);
        
        public TerminalUIMenu(MenuAction<string> i_MenuAction, string i_Name, List<Menu> i_MenuList) : base(i_MenuAction, i_Name, i_MenuList, i_UIOut: getOutput, i_UIInput: promptGetInput, i_Quit: "0")
        { 
        }
        
        private static void printToConsole(Menu i_menu)
        {

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine(i_menu.Name);
            builder.AppendLine(sr_Line);

            Console.WriteLine(builder.ToString());
            
            builder = new StringBuilder();
            builder.AppendLine("\n" + sr_Line);
            builder.AppendLine("\t\t\t\tChoose a command: ");
            builder.AppendLine(sr_Line);
            builder.AppendLine("0: Exit");

            List<Menu> children = i_menu.MenuList;

            for (int i = 0; i < children.Count; ++i)
            {
                builder.AppendLine(string.Format("{0}: {1}", i + 1, children[i].Name));
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


        private static void getOutput(object i_Object)
        {
            if (i_Object is string)
            {
                printToConsole(i_Object as string);

            }
            if (i_Object is Menu)
            {
                printToConsole(i_Object as Menu);
            }
        }

        private static object promptGetInput(Type i_Type)
        {
            object outObject;

            string command = Console.ReadLine();

            TypeConverter converter = TypeDescriptor.GetConverter(i_Type);

            if (converter != null && converter.CanConvertFrom(typeof(string)))
            {
                if (!converter.IsValid(command))
                {
                    throw new FormatException(string.Format("Syntax-invalid: not of type {0}", i_Type ));
                }

                try
                {
                    outObject = converter.ConvertFromString(command);
                }
                catch
                {
                    throw new FormatException(string.Format("Syntax-invalid: not of type {0}", i_Type ));
                }
            }
            else
            {
                outObject = command;
            }

            return outObject;
        }
    }
}