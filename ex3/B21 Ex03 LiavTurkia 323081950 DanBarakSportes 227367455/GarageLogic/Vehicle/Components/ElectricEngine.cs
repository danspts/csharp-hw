using System;
using System.Text;

namespace GarageLogic.Vehicle
{
    public class ElectricEngine : Engine
    {
        private readonly float r_MaxOperationHours;
        private float m_RemainingHours;

        public ElectricEngine(float i_StartingHours, float i_MaxHours)
        {
            this.m_RemainingHours = i_StartingHours;
            this.r_MaxOperationHours = i_MaxHours;
        }

        public ElectricEngine(float i_MaxHours)
            : this(i_MaxHours, i_MaxHours)
        {
        }

        public float MaxOperationHours
        {
            get { return this.r_MaxOperationHours; }
        }

        public float DifferenceOfHours
        {
            get { return this.MaxOperationHours - this.RemainingHours; }
        }

        public float RemainingHours
        {
            get
            {
                return this.m_RemainingHours;
            }

            set
            {
                if (value < 0 || value > this.DifferenceOfHours)
                {
                    throw new ValueOutOfRangeException(0, this.DifferenceOfHours, "Invalid amount of operational hours");
                }

                // Clamp to be between [0, maxTime - existingTime]
                this.m_RemainingHours = value;
            }
        }

        public override float EnergyPercentage
        {
            get { return this.RemainingHours / this.MaxOperationHours; }
        }

        public void Recharge(float i_ToAdd)
        {
            this.RemainingHours += i_ToAdd;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Amount currently charged: {0}h", this.RemainingHours));
            builder.AppendLine(string.Format("Total Capacity: {0}h", this.MaxOperationHours));
            return builder.ToString();
        }
    }
}