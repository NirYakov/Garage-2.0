using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class FuelTrack : Vehicle // need change name of cs to FuelTrack
    {
        private const float k_MaxAirPressure = 28, k_MaxCapacityTank = 600_000f;
        private const byte k_NumOfWheels = 12;        
        private float m_TrunkCapacity;
        private bool m_IsHaveCoolTrunk;

        public FuelTrack(string i_LicenseNumber, string i_Model)
            : base(i_LicenseNumber, i_Model , k_NumOfWheels, new FuelEngine(6f,eFuelType.Soler))
        {
        }

        public override void SetWheelsProperty(string i_ManufacturerName, float i_CurrentAirPressure)
        {
            initWheelsList(i_ManufacturerName, i_CurrentAirPressure, k_MaxAirPressure, k_NumOfWheels);
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

        public override string ToString()
        {
            return string.Format(
@"{0}
type of fule is:{1}  , Fuel status is:{2}  , trunk capacity is:{3} ,HaveCoolTrunk:{4} "
, base.ToString(), eFuelType.Soler, m_PercentOfEnergy, m_TrunkCapacity, m_IsHaveCoolTrunk);
        }
    }
}