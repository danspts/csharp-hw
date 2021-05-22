namespace GarageLogic.Vehicle
{
	public abstract class Vehicle
	{
		private readonly string r_ModelName;
		private License m_License;
		private Wheel[] m_Wheels;
		private Engine m_Engine;

		protected Vehicle(string i_ModelName, License i_License, Wheel[] i_Wheels, Engine i_Engine)
		{
			this.r_ModelName = i_ModelName;
			this.m_License = i_License;
			this.m_Wheels = i_Wheels;
			this.m_Engine = i_Engine;
		}

		public string ModelName
		{
			get { return this.r_ModelName; }
		}

		public License License
		{
			get { return this.m_License; }
			set { this.m_License = value; }
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

		public string LicenseNumber
		{
			get { return this.License.Number; }
		}

		public float RemainingEnergyPercentage
		{
			get { return this.Engine.EnergyPercentage; }
		}
	}
}
