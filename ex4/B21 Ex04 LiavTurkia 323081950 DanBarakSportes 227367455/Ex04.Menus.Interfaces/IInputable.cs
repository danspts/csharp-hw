using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
	interface IInputable
	{
		Requirements.PropertyRequirement GetInputRequirement();

		// returns true if the input was valid,
		// false if its invalid and should reprompt
		bool AcceptInput(string i_Input);
	}
}
