using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class FuelTruck : Vehicle
    {
        private const float k_MaxFuelTank = 6f, k_MaxAirPressure = 28, k_MaxCapacityTank = 600_000f;
        private const byte k_NumOfWheels = 12;        
        private float m_TrunkCapacity;
        private bool m_IsHaveCoolTrunk;

        public FuelTruck(string i_Model, string i_LicenseNumber, byte i_NumOfWheels)
            : base(i_Model, i_LicenseNumber, i_NumOfWheels)
        {
        }

        public bool HaveCoolTrunk
        {
            get
            {
                return m_IsHaveCoolTrunk;
            }

            set
            {
                m_IsHaveCoolTrunk = value;
            }
        }

        public float TrunkCapacity
        {
            get
            {
                return m_TrunkCapacity;
            }

            set
            {
                if (value >= 0 && value <= k_MaxCapacityTank)
                {
                    m_TrunkCapacity = value;
                }

                else
                {
                    throw new ValueOutOfRangeException(null, k_MaxCapacityTank, 0);
                }
            }
        }
    }
}