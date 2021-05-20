using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	abstract class Engine
	{
		protected float m_EnergyPercentage;

		protected Engine(float i_StartingPercentage)
		{
			this.m_EnergyPercentage = i_StartingPercentage;
		}

		public float EnergyPercentage
		{
			get { return this.m_EnergyPercentage; }
		}
	}
}
