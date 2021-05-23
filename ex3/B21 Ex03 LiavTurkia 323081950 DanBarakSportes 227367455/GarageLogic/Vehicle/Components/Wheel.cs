using System;
using System.Collections.Generic;

namespace GarageLogic.Vehicle
{
	public class Wheel : VehicleComponent<Wheel>
	{
		public static new Dictionary<string, Requirements.PropertyRequirement> GetRequirements() {
			return new Dictionary<string, Requirements.PropertyRequirement>()
			{
				{ "ManufacturerName", new Requirements.TypeRequirement(typeof(string)) },
				{ "MaxPressure", new Requirements.MinimumRequirement<float>(0f) },
			};
		}

		public static new Wheel Generate(Dictionary<string, object> i_Properties)
		{
			if (i_Properties.TryGetValue("MaxPressure", out object maxPressure) && i_Properties.TryGetValue("ManufacturerName", out object name))
			{
				if (!(name is string) || !(maxPressure is float))
				{
					throw new ArgumentException("Properties have an invalid type");
				}

				return new Wheel(name as string, (float)maxPressure);
			}
			else
			{
				throw new ArgumentException("Missing properties!");
			}
		}

		private readonly string r_ManufacturerName;
		private readonly float r_MaxPressure;
		private float m_CurrentPressure;

		public Wheel(string i_ManufacturerName, float i_StartingPressure, float i_MaxPressure)
		{
			this.r_ManufacturerName = i_ManufacturerName;
			this.r_MaxPressure = i_MaxPressure;
			this.m_CurrentPressure = i_StartingPressure;
		}

		public Wheel(string i_ManufacturerName, float i_MaxPressure)
			: this(i_ManufacturerName, i_MaxPressure, i_MaxPressure)
		{
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
