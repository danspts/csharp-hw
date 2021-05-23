namespace GarageLogic.Vehicle
{
	public abstract class Engine : VehicleComponent<Engine>
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
