using System.Collections.Generic;

namespace GarageLogic
{
    internal abstract class Vehicle
    {
        protected readonly string r_LicenseNumber, r_Model;
        protected float m_PercentOfEnergy = 0;
        protected readonly List<Wheel> m_ListOfWheels;
        protected readonly Engine r_Engine;

        public Vehicle(string i_Model, string i_LicenseNumber, byte i_NumOfWheels , Engine i_EngineToVehicle)
        {
            r_Model = i_Model;
            r_LicenseNumber = i_LicenseNumber;
            m_ListOfWheels = new List<Wheel>(i_NumOfWheels);
            r_Engine = i_EngineToVehicle;
        }

        public Engine EngineSystem
        {
            get
            {
               return r_Engine;
            }
        }

        public abstract void InitializationOfVariousVehicle(params object[] i_Details);

        protected void initWheelsList(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure, byte i_NumOfWheels)
        {
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_ListOfWheels.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure));
            }
        }

        public float PercentOfEnergy
        {
            get
            {                
                return m_PercentOfEnergy;
            }
        }

        public void FillEnergy(float i_AmonutOfEnergy, string i_EnergyType)
        {
            EngineSystem.FillEnergy(i_AmonutOfEnergy, i_EnergyType);
            m_PercentOfEnergy = (100 * (EngineSystem.CurrentEnergyStatus / EngineSystem.MaxEnergyCapacity));
        }

        public string Model
        {
            get
            {
                return r_Model;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public void FillMaxWheelsAir()
        {
            foreach (Wheel wheel in m_ListOfWheels)
            {
                wheel.AirInflation(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }            
        }
    }
}