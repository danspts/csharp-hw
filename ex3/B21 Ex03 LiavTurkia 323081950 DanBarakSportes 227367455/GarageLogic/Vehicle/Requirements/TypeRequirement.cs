using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Requirements
{
    public class TypeRequirement : PropertyRequirement
    {
        private readonly Type r_Type;

        public TypeRequirement(Type i_Type)
        {
            r_Type = i_Type;
        }

        public override Type Type
        {
            get { return this.r_Type; }
        }

        public override bool Verify(object i_ToVerify)
        {
            return i_ToVerify != null && i_ToVerify.GetType() == this.r_Type;
        }

        public override string GetRequirementInformation()
        {
            return string.Format("Must be of type {0}", this.r_Type.Name);
        }
    }
}