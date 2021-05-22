using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic
{
	class ValueOutOfRangeException : Exception
	{
        private readonly float r_MinValue;
        private readonly float r_MaxValue;

        public ValueOutOfRangeException(float i_Min, float i_Max)
            : base(string.Format("Value out of the range {0},{1}", i_Min, i_Max))
        {
            this.r_MinValue = i_Min;
            this.r_MaxValue = i_Max;
        }

        public ValueOutOfRangeException(float i_Min, float i_Max, string message)
            : base(string.Format("{0}: Value out of the range {1},{2}", message, i_Min, i_Max))
        {
            this.r_MinValue = i_Min;
            this.r_MaxValue = i_Max;
        }

        public ValueOutOfRangeException(float i_Min, float i_Max, string message, Exception inner)
            : base(string.Format("{0}: Value out of the range {1},{2}", message, i_Min, i_Max), inner)
        {
            this.r_MinValue = i_Min;
            this.r_MaxValue = i_Max;
        }
    }
}
