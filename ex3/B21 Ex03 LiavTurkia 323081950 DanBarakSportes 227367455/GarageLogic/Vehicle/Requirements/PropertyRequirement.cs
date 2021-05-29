using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Requirements
{
    public abstract class PropertyRequirement
    {
        public abstract bool Verify(object i_ToVerify);

        public abstract string GetRequirementInformation(); 

        public abstract Type Type { get; }
    }
}