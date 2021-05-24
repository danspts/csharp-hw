﻿using System;

namespace GarageLogic.Vehicle
{
	public class ElectricEngine : Engine
	{
		private readonly float r_MaxOperationHours;
		private float m_RemainingHours;

		public ElectricEngine(float i_StartingHours, float i_MaxHours)
			: base(i_StartingHours / i_MaxHours)
		{
			this.m_RemainingHours = i_StartingHours;
			this.r_MaxOperationHours = i_MaxHours;
		}

		public float MaxOperationHours
		{
			get { return this.r_MaxOperationHours; }
		}

		public float RemainingHours
		{
			get
			{
				return this.m_RemainingHours;
			}

			set
			{
				// Clamp to be between [0, maxPressure]
				this.m_RemainingHours = Math.Max(0f, Math.Min(this.MaxOperationHours, value));
				this.m_EnergyPercentage = this.m_RemainingHours / this.r_MaxOperationHours;
			}
		}

		public void Recharge(float i_ToAdd)
		{
			this.RemainingHours += i_ToAdd;
		}
	}
}