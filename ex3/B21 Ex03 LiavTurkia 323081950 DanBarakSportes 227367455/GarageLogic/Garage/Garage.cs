using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Garage
{
    public class Garage
    {
        private Dictionary<string, VehicleRegistration> m_Vehicles = new Dictionary<string, VehicleRegistration>();

        public VehicleRegistration GetRegistration(string i_LicenseNumber)
        {
            return this.m_Vehicles[i_LicenseNumber];
        }

        public void UpsertRegistration(string i_LicenseNumber, VehicleRegistration i_Registration)
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

        public string ListVehicles(VehicleRegistration.eVehicleStatus status_filter = default)
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, VehicleRegistration> kvp in m_Vehicles)
            {
                if (kvp.Value.Status == status_filter || status_filter == default)
                {
                    builder.AppendLine(kvp.Key);
                }
            }
            return builder.ToString();
        }
    }
}