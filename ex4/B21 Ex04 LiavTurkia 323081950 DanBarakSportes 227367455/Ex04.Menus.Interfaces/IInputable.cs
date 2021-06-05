using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
	public interface IInputable
	{
		Requirements.TypeRequirement GetInputRequirement();

		// returns true if the input was valid,
		// false if its invalid and should reprompt
		bool Execute(object i_Input, StringBuilder i_OutputText);
	}
}
