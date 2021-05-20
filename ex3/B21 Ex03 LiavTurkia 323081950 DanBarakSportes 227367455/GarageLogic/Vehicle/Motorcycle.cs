using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	class Motorcycle : Vehicle
	{
		private readonly int r_EngineVolume;

		public Motorcycle(string i_ModelName, MotorcycleLicense i_License, Wheel[] i_Wheels, Engine i_Engine, int i_EngineVolume)
			: base(i_ModelName, i_License, i_Wheels, i_Engine)
		{
			this.r_EngineVolume = i_EngineVolume;
		}

		public MotorcycleLicense.eMotorcycleLicenseType LicenseType
		{
			get
			{
				return this.License.Type;
			}
		}

		public new MotorcycleLicense License
		{
			get
			{
				return (MotorcycleLicense)base.License;
			}

			set
			{
				if (!(value is MotorcycleLicense))
				{
					throw new ArgumentException("Motorcycle license must be of type MotorcycleLicense!");
				}

				base.License = value;
			}
		}
	}
}
