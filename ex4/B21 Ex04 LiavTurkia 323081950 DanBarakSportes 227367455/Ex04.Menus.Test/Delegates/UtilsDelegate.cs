using System;
using System.ComponentModel;
using Menu = Ex04.Menus.Delegates.Menu<string>;

namespace Ex04.Menus.Test.Delegates
{
    internal class UtilsDelegate
    {
        public T Convert<T>(string i_Input)
        {
            object outObject = null;

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            if (converter != null && converter.CanConvertFrom(typeof(string)))
            {
                if (!converter.IsValid(i_Input))
                {
                    Console.WriteLine(string.Format("Syntax-invalid: not of type {0}", typeof(T)));
                }

                try
                {
                    outObject = converter.ConvertFromString(i_Input);
                }
                catch
                {
                    Console.WriteLine(string.Format("Syntax-invalid: not of type {0}",  typeof(T)));
                }
            }
            else
            {
                outObject = i_Input;
            }

            return (T)outObject;
        }

        internal static void Quit(object i_O)
        {
            Environment.Exit(0);
        }

        private static void waitForEnter()
        {
            Console.WriteLine("\nPress enter to return to main menu");
            Console.ReadLine();
            Menu.Root.Show();
        }

        internal static void ShowDate(object i_O)
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
            waitForEnter();
        }

        internal static void ShowTime(object i_O)
        {
            Console.WriteLine(DateTime.Now.ToString("h:mm tt"));
            waitForEnter();
        }

        internal static void ShowVersion(object i_O)
        {
            Console.WriteLine("App Version: 21.1.4.8930");
            waitForEnter();
        }

        internal static void CountSpaces(object i_O)
        {
            Console.WriteLine("Please input a string to count spaces for:\n");

            string input = Console.ReadLine();

            int counter = 0;
            foreach (char c in input)
            {
                if (c == ' ')
                {
                    ++counter;
                }
            }

            Console.WriteLine(string.Format("Input has {0} spaces", counter));
            waitForEnter();
        }
    }
}