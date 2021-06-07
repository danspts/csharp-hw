using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces.Requirements
{
    public abstract class PropertyRequirement
    {
        public abstract Type Type { get; }

        public abstract bool Verify(object i_ToVerify);

        public abstract string GetRequirementInformation();
    }
}
