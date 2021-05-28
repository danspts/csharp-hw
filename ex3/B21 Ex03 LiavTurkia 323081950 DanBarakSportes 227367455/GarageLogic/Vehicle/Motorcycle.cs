using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class Motorcycle : Vehicle
	{
		public enum eLicenseType
		{
			A,
			B1,
			AA,
			BB,
		}

		private readonly eLicenseType r_LicenseType;
		private readonly int r_EngineVolume;

		public static new Dictionary<string, Requirements.PropertyRequirement> GetRequirements()
		{
			Dictionary<string, Requirements.PropertyRequirement> requirements = Vehicle.GetRequirements();
			requirements.Add("Engine Volume", new Requirements.MinimumRequirement<int>(0));
			requirements.Add("License Type", new Requirements.TypeRequirement(typeof(eLicenseType)));
			return requirements;
		}

		public Motorcycle(Dictionary<string, object> i_Properties, Wheel[] i_Wheels, Engine i_Engine)
			: base(i_Properties, i_Wheels, i_Engine)
		{
			this.applyProperty<eLicenseType>(i_Properties, "License Type", out this.r_LicenseType);
			this.applyProperty<int>(i_Properties, "Engine Volume", out this.r_EngineVolume);
		}

		public eLicenseType LicenseType
		{
			get { return this.r_LicenseType; }
		}

		public int EngineVolume
		{
			get { return this.r_EngineVolume; }
		}
	}
}
