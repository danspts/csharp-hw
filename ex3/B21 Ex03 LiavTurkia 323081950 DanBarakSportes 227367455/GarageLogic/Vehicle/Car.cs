using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicle
{
	public class Car : Vehicle
	{
		public enum eCarColor
		{
			Red = 0,
			Silver = 1,
			White = 2,
			Black = 3,
		}

		private readonly eCarColor r_CarColor;
		private readonly int r_NumberOfDoors;

		public static new Dictionary<string, Requirements.PropertyRequirement> GetRequirements()
		{
			Dictionary<string, Requirements.PropertyRequirement> requirements = Vehicle.GetRequirements();
			requirements.Add("Number of Doors", new Requirements.RangeRequirement<int>(2, 5));
			requirements.Add("Car Color", new Requirements.TypeRequirement(typeof(eCarColor)));
			return requirements;
		}

		public Car(Dictionary<string, object> i_Properties, Wheel[] i_Wheels, Engine i_Engine)
			: base(i_Properties, i_Wheels, i_Engine)
		{
			this.applyProperty<eCarColor>(i_Properties, "Car Color", out this.r_CarColor);
			this.applyProperty<int>(i_Properties, "Number of Doors", out this.r_NumberOfDoors);
		}

		public eCarColor CarColor
		{
			get { return this.r_CarColor; }
		}

		public int NumberOfDoors
		{
			get { return this.NumberOfDoors; }
		}
		
		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine(base.ToString());
			// TODO add other features
			return builder.ToString();
		}
	}
}
