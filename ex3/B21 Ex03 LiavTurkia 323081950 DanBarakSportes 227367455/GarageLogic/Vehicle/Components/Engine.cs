using System.Collections.Generic;
using System;

namespace GarageLogic.Vehicle
{
    public abstract class Engine
    {
        public abstract float EnergyPercentage { get; }

        public override string ToString()
        {
            throw new NotImplementedException("The implementation to String was not defined for this vehicle");
        }
    }
}