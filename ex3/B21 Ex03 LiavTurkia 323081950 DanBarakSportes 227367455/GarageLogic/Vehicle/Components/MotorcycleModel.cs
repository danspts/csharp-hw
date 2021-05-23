using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class MotorcycleModel : Model
	{
		private readonly int r_EngineVolume;

		public MotorcycleModel(string i_ModelName, int i_EngineVolume)
			: base(i_ModelName)
		{
			this.r_EngineVolume = i_EngineVolume;
		}

		public int EngineVolume
		{
			get { return this.r_EngineVolume; }
		}
	}
}
