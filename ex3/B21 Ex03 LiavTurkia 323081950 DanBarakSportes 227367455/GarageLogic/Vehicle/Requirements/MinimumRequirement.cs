using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Requirements
{
	class MinimumRequirement<T> : TypeRequirement
		where T : IComparable<T>
	{
		private readonly T r_Minimum;

		public MinimumRequirement(T i_Minimum)
			: base(typeof(T))
		{
			this.r_Minimum = i_Minimum;
		}

		public override bool Verify(object i_ToVerify)
		{
			return base.Verify(i_ToVerify) && Comparer<T>.Default.Compare((T)i_ToVerify, this.r_Minimum) >= 0;
		}

		public override string GetRequirementInformation()
		{
			return string.Format("{0}, min: {1}", base.GetRequirementInformation(), this.r_Minimum);
		}
	}
}
