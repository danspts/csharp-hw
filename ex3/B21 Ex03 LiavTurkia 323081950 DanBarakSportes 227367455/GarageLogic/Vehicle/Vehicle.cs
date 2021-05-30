using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class Vehicle
	{
		private readonly string r_ModelName;
		private readonly string r_LicenseNumber;
		private Wheel[] m_Wheels;
		private Engine m_Engine;

		public static Dictionary<string, Requirements.PropertyRequirement> GetRequirements()
		{
			Dictionary<string, Requirements.PropertyRequirement> requirements = new Dictionary<string, Requirements.PropertyRequirement>
			{
				{ "Model Name", new Requirements.TypeRequirement(typeof(string)) },
				{ "License Number", new Requirements.TypeRequirement(typeof(string)) },
			};
			return requirements;
		}

		public Vehicle(Dictionary<string, object> i_Properties, Wheel[] i_Wheels, Engine i_Engine)
		{
			this.applyProperty<string>(i_Properties, "Model Name", out this.r_ModelName);
			this.applyProperty<string>(i_Properties, "License Number", out this.r_LicenseNumber);

			this.m_Wheels = i_Wheels;
			this.m_Engine = i_Engine;
		}

		public Wheel[] Wheels
		{
			get { return this.m_Wheels; }
			set { this.m_Wheels = value; }
		}

		public Engine Engine
		{
			get { return this.m_Engine; }
			set { this.m_Engine = value; }
		}

		public string ModelName
		{
			get { return this.r_ModelName; }
		}

		public string LicenseNumber
		{
			get { return this.r_LicenseNumber; }
		}

		protected void applyProperty<T>(Dictionary<string, object> i_Properties, string i_PropertyName, out T o_Variable)
		{
			if (i_Properties.TryGetValue(i_PropertyName, out object value))
			{
				if (!(value is T))
				{
					throw new ArgumentException(string.Format("{0} is of the wrong type, should be {1}", i_PropertyName, typeof(T).Name));
				}

				o_Variable = (T)value;
			}
			else
			{
				throw new ArgumentException(string.Format("Missing property: {0}", i_PropertyName));
			}
		}

		public virtual Dictionary<string, object> GetProperties()
		{
			Dictionary<string, object> props = new Dictionary<string, object>
			{
				{ "License Number", this.LicenseNumber },
				{ "Model Name", this.ModelName },
			};
			if (this.Wheels.Length > 0)
			{
				// all the tires should have the same specification anyways, so [0] is fine
				props.Add("Tire Manufacturer", this.Wheels[0].ManufacturerName);
				props.Add("Tire Max Pressure", this.Wheels[0].MaxPressure);
			}

			return props;
		}

		public void InflateAllWheels()
		{
			foreach (Wheel wheel in this.Wheels)
			{
				wheel.Inflate();
			}
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			foreach (KeyValuePair<string, object> pair in this.GetProperties())
			{
				builder.AppendLine(string.Format("{0}: {1}", pair.Key, pair.Value.ToString()));
			}

			builder.AppendLine(this.Engine.ToString());
			return builder.ToString();
		}
	}
}
