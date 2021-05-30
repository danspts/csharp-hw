using System.Text;
namespace GarageLogic.Garage
{
    public class VehicleRegistration
    {
        public enum eVehicleStatus
        {
            None = 0,
            InRepair = 1,
            Repaired = 2,
            PayedFor = 3,
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
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("\n-------------------------------------------------------------------------------------");
            builder.AppendLine(this.Vehicle.ToString());
            builder.AppendLine("Owner: " + this.Owner.ToString());
            builder.AppendLine("Status: " + this.Status.ToString());
            builder.AppendLine("\n-------------------------------------------------------------------------------------");
            return builder.ToString();
        }
    }
}