using System.Collections.Generic;

namespace GarageLogic.Garage
{
    public class Garage
    {
        private Dictionary<string, VehicleRegistration> m_Vehicles = new Dictionary<string, VehicleRegistration>();

        public VehicleRegistration GetRegistration(string i_LicenseNumber)
		{
            return this.m_Vehicles[i_LicenseNumber];
		}

        public void UpdateRegistration(string i_LicenseNumber, VehicleRegistration i_Registration)
		{
            this.m_Vehicles[i_LicenseNumber] = i_Registration;
		}

        public void RemoveRegistration(string i_LicenseNumber)
		{
            this.m_Vehicles.Remove(i_LicenseNumber);
		}

        public bool HasRegistered(string i_LicenseNumber)
		{
            return this.m_Vehicles.ContainsKey(i_LicenseNumber);
		}
    }
}