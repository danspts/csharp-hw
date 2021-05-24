using System;
using System.Collections.Generic;

namespace GarageLogic.Vehicle
{
	internal class TypeConfiguration<WheelType, LicenseType, EngineType, ModelType>
		where WheelType : Wheel
		where LicenseType : License
		where EngineType : Engine
		where ModelType : Model
	{
		readonly int r_NumOfWheels;

		public TypeConfiguration(int i_NumOfWheels)
		{
			this.r_NumOfWheels = i_NumOfWheels;
		}

		public int NumOfWheels
		{
			get { return this.r_NumOfWheels; }
		}

	}
}
