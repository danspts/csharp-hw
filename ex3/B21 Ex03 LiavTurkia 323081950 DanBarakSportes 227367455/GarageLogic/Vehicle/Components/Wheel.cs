using System;
using System.Collections.Generic;

namespace GarageLogic.Vehicle
{
	public class Wheel
	{
		private readonly string r_ManufacturerName;
		private readonly float r_MaxPressure;
		private float m_CurrentPressure;

		public Wheel(string i_ManufacturerName, float i_MaxPressure)
		{
			this.r_ManufacturerName = i_ManufacturerName;
			this.r_MaxPressure = i_MaxPressure;
			this.m_CurrentPressure = this.r_MaxPressure;
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
				if (value < 0 || value > this.MaxPressure)
				{
					throw new ValueOutOfRangeException(0, this.MaxPressure, "Invalid pressure to inflate wheel to");
				}

				this.m_CurrentPressure = value;
			}
		}

		public void Inflate(float i_ToAdd)
		{
			this.Pressure += i_ToAdd;
		}
	}
}
