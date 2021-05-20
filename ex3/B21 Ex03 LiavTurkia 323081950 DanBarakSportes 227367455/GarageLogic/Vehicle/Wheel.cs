using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	class Wheel
	{
		private readonly string r_ManufacturerName;
		private readonly float r_MaxPressure;
		private float m_CurrentPressure;

		public Wheel(string i_ManufacturerName, float i_StartingPressure, float i_MaxPressure)
		{
			this.r_ManufacturerName = i_ManufacturerName;
			this.r_MaxPressure = i_MaxPressure;
			this.m_CurrentPressure = i_StartingPressure;
		}

		public string ManufacturerName
		{
			get { return this.r_ManufacturerName; }
		}

		public float MaxPressure
		{
			get { return this.r_MaxPressure; }
		}

		public float Pressure
		{
			get
			{
				return this.m_CurrentPressure;
			}

			set
			{
				// Clamp to be between [0, maxPressure]
				this.m_CurrentPressure = Math.Max(0f, Math.Min(this.MaxPressure, value));
			}
		}

		public void Inflate(float i_ToAdd)
		{
			this.Pressure += i_ToAdd;
		}
	}
}
