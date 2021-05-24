using System;
using System.Collections.Generic;

namespace GarageLogic.Vehicle
{
	public class Vehicle : VehicleComponent<Vehicle>
	{
		private readonly Model r_Model;
		private License m_License;
		private Wheel[] m_Wheels;
		private Engine m_Engine;

		public Vehicle(Model i_Model, License i_License, Wheel[] i_Wheels, Engine i_Engine)
		{
			this.r_Model = i_Model;
			this.m_License = i_License;
			this.m_Wheels = i_Wheels;
			this.m_Engine = i_Engine;
		}

		public Model Model
		{
			get { return this.r_Model; }
		}

		public License License
		{
			get { return this.m_License; }
			set { this.m_License = value; }
		}

		public Wheel[] Wheels
		{
			get { return this.m_Wheels; }
			set { this.m_Wheels = value; }
		}

		public Engine Engine
		{
			get { return this.m_Engine; }
			set { this.m_Engine = value; }
		}
	}
}
