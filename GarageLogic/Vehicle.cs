using System.Collections.Generic;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_Model;
        protected readonly string r_LicenseNumber;
        protected float m_PercentOfEnergy = 0;
        protected List<Wheel> m_ListOfWheels;        

        public Vehicle(string i_Model, string i_LicenseNumber, byte i_NumOfWheels)
        {
            r_Model = i_Model;
            r_LicenseNumber = i_LicenseNumber;
            m_ListOfWheels = new List<Wheel>(i_NumOfWheels);
        }

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

        public List<Wheel> ListOfWheels
        {
            get
            {
                return m_ListOfWheels;
            }

            set // book think about this mybe not need or need to be privat
            {
                m_ListOfWheels = value;
            }
        }
    }
}

