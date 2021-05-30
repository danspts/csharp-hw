using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle.Requirements
{
	class RangeRequirement<T> : MinimumRequirement<T>
		where T : IComparable<T>
	{
		private readonly T r_Maximum;

		public RangeRequirement(T i_Minimum, T i_Maximum)
			: base(i_Minimum)
		{
			this.r_Maximum = i_Maximum;
		}

		public T Maximum
		{
			get { return this.r_Maximum; }
		}

		public override bool Verify(object i_ToVerify)
		{
			return base.Verify(i_ToVerify) && Comparer<T>.Default.Compare((T)i_ToVerify, this.r_Maximum) <= 0;
		}

		public override string GetRequirementInformation()
		{
			return string.Format("{0}, max: {1}", base.GetRequirementInformation(), this.r_Maximum);
		}
	}
}
