namespace GarageLogic.Vehicle
{
	public class License : VehicleComponent<License>
	{
		private readonly string r_LicenseNumber;

		public License(string i_LicenseNumber)
		{
			this.r_LicenseNumber = i_LicenseNumber;
		}

		public string Number
		{
			get { return this.r_LicenseNumber; }
		}
	}
}
