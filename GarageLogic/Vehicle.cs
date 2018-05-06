using System.Collections.Generic;
using System.Text;
using System;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_LicenseNumber, r_Model;
        protected readonly List<Wheel> r_ListOfWheels;
        protected readonly Engine r_Engine;
        protected float m_PercentOfEnergy = 0;

        public Vehicle(string i_LicenseNumber, string i_Model, byte i_NumOfWheels, Engine i_EngineToVehicle)
        {
            r_Model = i_Model;
            r_LicenseNumber = i_LicenseNumber;
            r_ListOfWheels = new List<Wheel>(i_NumOfWheels);
            r_Engine = i_EngineToVehicle;
        }

        public Engine EngineSystem
        {
            get
            {
               return r_Engine;
            }
        }

        public abstract void SetWheelsProperty(string i_ManufacturerName, float i_CurrentAirPressure);

        protected void initWheelsList(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure, byte i_NumOfWheels)
        {
            for (int i = 0; i < i_NumOfWheels; i++)
            {
                r_ListOfWheels.Add(new Wheel(i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure));
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
            m_PercentOfEnergy = 100 * EngineSystem.CurrentEnergyStatus / EngineSystem.MaxEnergyCapacity;
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
            foreach (Wheel wheel in r_ListOfWheels)
            {
                wheel.AirInflation(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }            
        }

        public override string ToString()
        {
            StringBuilder wheels = new StringBuilder();
            foreach (Wheel wheel in r_ListOfWheels) 
            {
                wheels.Append(Environment.NewLine + wheel);
            }

            return string.Format(
@"License Number:{0}  ,Model is:{1} ,the wheels is:{2}", r_LicenseNumber, r_Model, wheels);
        }
    }
}