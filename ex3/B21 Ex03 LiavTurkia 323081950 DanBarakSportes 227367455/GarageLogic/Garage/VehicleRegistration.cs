namespace GarageLogic.Garage
{
	public class VehicleRegistration
	{
		public enum eVehicleStatus { 
			InRepair,
			Repaired,
			PayedFor,
		}

		private readonly Owner r_Owner;
		private Vehicle.Vehicle m_Vehicle;
		private eVehicleStatus m_Status;

		public VehicleRegistration(Owner i_Owner, Vehicle.Vehicle i_Vehicle)
		{
			this.r_Owner = i_Owner;
			this.m_Vehicle = i_Vehicle;
			this.m_Status = eVehicleStatus.InRepair;
		}

		public Vehicle.Vehicle Vehicle
		{
			get { return this.m_Vehicle; }
			set { this.m_Vehicle = value; }
		}

		public Owner Owner
		{
			get { return this.r_Owner; }
		}

		public eVehicleStatus Status
		{
			get { return this.m_Status; }
			set { this.m_Status = value; }
		}

		public override string ToString()
		{
			//Todo needed to print vehicles' details 
			return base.ToString();
		}
	}
}
