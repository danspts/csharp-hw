using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public abstract class Model : VehicleComponent<Model>
	{
		private readonly string r_ModelName;

		public Model(string i_ModelName)
		{
			this.r_ModelName = i_ModelName;
		}

		public string Name
		{
			get { return this.r_ModelName;  }
		}
	}
}
