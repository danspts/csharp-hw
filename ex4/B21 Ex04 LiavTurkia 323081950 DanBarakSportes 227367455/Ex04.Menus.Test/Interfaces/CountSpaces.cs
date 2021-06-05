using Ex04.Menus.Interfaces.Requirements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Test.Interfaces
{
	class CountSpaces : Menus.Interfaces.MenuItem, Menus.Interfaces.IDescribable, Menus.Interfaces.IInputable
	{
		public CountSpaces()
			: base("Count Spaces")
		{
		}

		public string Description
		{
			get { return "Please input a string to count spaces for"; }
		}

		public bool Execute(object i_Input, StringBuilder i_OutputText)
		{
			string input = (string)i_Input;

			int counter = 0;
			foreach(char c in input)
			{
				if(c == ' ')
				{
					++counter;
				}
			}

			i_OutputText.Append(string.Format("Input has {0} spaces", counter));

			return true;
		}

		public TypeRequirement GetInputRequirement()
		{
			return new TypeRequirement(typeof(string));
		}
	}
}
