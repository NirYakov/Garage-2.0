using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public class GarageActs
    {
        private readonly Dictionary<string, Clint> r_WorkCards = new Dictionary<string, Clint>();

        public GarageActs()
        {
        }

        public void InsertNewClint(Clint clint)
        {
            r_WorkCards.Add(clint.Vehicle.LicenseNumber, clint);
        }

        public bool IsAlreadyInGarage(string i_LicenceNum)
        {
            bool isInTheGarage = false;
            foreach (string licenceNumInGarage in r_WorkCards.Keys)
            {
                if (licenceNumInGarage == i_LicenceNum)
                {
                    isInTheGarage = true;
                    break;
                }
            }

            return isInTheGarage;
        }
    }
}