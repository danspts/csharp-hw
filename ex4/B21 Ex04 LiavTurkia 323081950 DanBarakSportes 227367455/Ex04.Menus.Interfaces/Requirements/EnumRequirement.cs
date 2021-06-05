using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces.Requirements
{
	class EnumRequirement : RangeRequirement<int>
	{
		public EnumRequirement(Enum i_Enum)
			: base(0, Enum.GetValues(i_Enum.GetType()).Length)
		{

		}
	}
}
