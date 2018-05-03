using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class Clint // if needed downgrade accsece.
    {
        private readonly string r_OnwerName;
        private readonly string r_PhoneNumber;
        private eStatusInGarage m_CarStatus = eStatusInGarage.InRepair;
        private Vehicle m_Vehicle;

        public Clint(string r_LicenseNumber,string r_Model, string i_OnwerName ,string i_PhoneNumber)
        {
            r_OnwerName = i_OnwerName;
            r_PhoneNumber = i_PhoneNumber;
            m_Vehicle;
        }

        public enum eStatusInGarage
        {
            InRepair ,
            DoneRepair,
            Paid
        }
    }
}
