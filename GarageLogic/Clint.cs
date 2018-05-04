using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public sealed class Clint
    {
        private readonly string r_OnwerName, r_PhoneNumber;        
        private eStatusInGarage m_CarStatus = eStatusInGarage.InRepair;
        private Vehicle r_Vehicle;

        internal Clint(string r_LicenseNumber, string r_Model, Vehicle m_Vehicle, string i_OnwerName, string i_PhoneNumber)
        {
            r_OnwerName = i_OnwerName;
            r_PhoneNumber = i_PhoneNumber;
            r_Vehicle = m_Vehicle;
        }

        public Vehicle Vehicle
        {
            get
            {
                return r_Vehicle;
            }
        }

        public eStatusInGarage CarStatus
        {
            get
            {
                return m_CarStatus;
            }

            set
            {
                m_CarStatus = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        // static public Vehicle returnFuelCar() { return new FuelCar("123","456"); } // nir delete 

        public enum eStatusInGarage
        {
            InRepair,
            DoneRepair,
            Paid
        }
    }
}
