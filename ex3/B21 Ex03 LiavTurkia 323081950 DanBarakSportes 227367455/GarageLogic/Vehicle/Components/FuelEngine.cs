using System;
using System.Text;

namespace GarageLogic.Vehicle
{
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octane95,
            Octane96,
            Octane98,
        }

        private readonly eFuelType r_FuelType;
        private readonly float r_MaxFuelLiters;
        private float m_RemainingLiters;

        public FuelEngine(eFuelType i_FuelType, float i_StartingLiters, float i_MaxLiters)
        {
            this.r_FuelType = i_FuelType;
            this.m_RemainingLiters = i_StartingLiters;
            this.r_MaxFuelLiters = i_MaxLiters;
        }

        public FuelEngine(eFuelType i_FuelType, float i_MaxLiters)
            : this(i_FuelType, i_MaxLiters, i_MaxLiters)
        {
        }

        public eFuelType FuelType
        {
            get { return this.r_FuelType; }
        }

        public float MaxFuelLiters
        {
            get { return this.r_MaxFuelLiters; }
        }

        public float DifferenceOfFuel
        {
            get { return this.MaxFuelLiters - this.RemainingLiters; }
        }

        public float RemainingLiters
        {
            get
            {
                return this.m_RemainingLiters;
            }

            set
            {
                if (value < 0 || value > this.DifferenceOfFuel)
                {
                    throw new ValueOutOfRangeException(0, this.DifferenceOfFuel, "Invalid liters of fuel");
                }

                this.m_RemainingLiters = value;
            }
        }

        public override float EnergyPercentage
        {
            get { return this.m_RemainingLiters / this.r_MaxFuelLiters; }
        }

        public void Refuel(float i_ToAdd)
        {
            this.RemainingLiters += i_ToAdd;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Fuel currently in tank: {0}L", this.RemainingLiters));
            builder.AppendLine(string.Format("Tank total Capacity: {0}", this.MaxFuelLiters));
            builder.AppendLine(string.Format("Fuel type: {0}", this.FuelType));
            return builder.ToString();
        }
    }
}