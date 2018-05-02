using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class PetrolMotorcycle : Motorcycle
    {
        const float k_MaxFuelTank = 6f;
        private PetrolEngin m_PetrolEngin;

        public PetrolMotorcycle(string i_Model, string i_LicenseNumber, string i_TypeOfLicense, int i_EngineCapacity)
            : base(i_Model, i_LicenseNumber, i_TypeOfLicense, i_EngineCapacity)
        {
            m_PetrolEngin = new PetrolEngin(PetrolEngin.eFuelType.Octan96, k_MaxFuelTank);
            m_PercentOfEnergy = 0;
        }

        public float CurrentFuelTank
        {
            get
            {
                return m_PetrolEngin.CurrentFuelTank;
            }
        }

        public float MaxFuelTank
        {
            get
            {
                return m_PetrolEngin.MaxFuelTank;
            }

        }
        public void Refuel(string i_FuelType, float i_FuelAmout)
        {
            m_PetrolEngin.Refuel(i_FuelType, i_FuelAmout);
            m_PercentOfEnergy = m_PetrolEngin.CurrentFuelTank / m_PetrolEngin.MaxFuelTank;
        }
    }
}