using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_MaxOfEngineCapacity = 7_000;
        private const float k_MaxAirPressure = 30;
        private const byte k_NumOfWheels = 2;

        protected int m_EngineCapacity;
        protected eTypeOfLicense m_TypeOfLicense;

        internal Motorcycle(string i_LicenseNumber, string i_Model, Engine i_EngineToVehicle)
            : base(i_LicenseNumber, i_Model, k_NumOfWheels, i_EngineToVehicle)
        {
        }       

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            internal set
            {
                if (value >= 0 && value <= k_MaxOfEngineCapacity)
                {
                    m_EngineCapacity = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, k_MaxOfEngineCapacity, 0);
                }
            }
        }

        public eTypeOfLicense TypeOfLicense
        {
            get
            {
                return m_TypeOfLicense;
            }

            set
            {               
                    m_TypeOfLicense = value;
            }
        }

        public override void SetWheelsProperty(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            initWheelsList(i_ManufacturerName, i_CurrentAirPressure, k_MaxAirPressure, k_NumOfWheels);
        }
        
        public override string ToString()
        {
            return string.Format(
@"{0}
the engine capacity is:{1} , the type of license is:{2},", base.ToString(), m_EngineCapacity, m_TypeOfLicense);
        }
        
        public enum eTypeOfLicense : byte
        {
            A,
            A1,
            B1,
            B2
        }
    }
}