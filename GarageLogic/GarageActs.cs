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

        public void ChargeBattary(string i_LicenseNum, float i_MinuteToCharge)
        {
            const string electric = "Electric";          

            if (!r_WorkCards.TryGetValue(i_LicenseNum, out Clint clint))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            clint.Vehicle.FillEnergy(i_MinuteToCharge, electric);
        }

        public void RefuelVehicle(string i_LicenseNum , float i_FuelAmount ,eFuelType i_FuelType) // Book tosee and fix the fuels fill.
        {
            if (!r_WorkCards.TryGetValue(i_LicenseNum, out Clint clint))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            clint.Vehicle.FillEnergy(i_FuelAmount, i_FuelType.ToString());           
        }

        public void FillMaxWheelsAir(string i_LicenseNum)
        {
            if (!r_WorkCards.TryGetValue(i_LicenseNum, out Clint clint))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            clint.Vehicle.FillMaxWheelsAir();
        }

        public void ChangeVehicleStatus(string i_LicenseNum, Clint.eStatusInGarage i_NewStatus)
        {
            if (!r_WorkCards.TryGetValue(i_LicenseNum, out Clint clint))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            clint.CarStatus = i_NewStatus;           
        }
        // book to change to do this in PascalCase
        public string MsgFullDetailsVehicle(string i_LicenseNum)
        {
            if (!r_WorkCards.TryGetValue(i_LicenseNum, out Clint clint))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            return clint.ToString();
        }

        public void ChargeElecticVehicle(string i_LicenseNum, float i_BattaryTime)
        {
            Vehicle vehicle = getCurretVehicle(i_LicenseNum);
        }

        public void InsertNewClint(Clint i_Clint)
        {
            r_WorkCards.Add(i_Clint.Vehicle.LicenseNumber, i_Clint);
        }

        private Vehicle getCurretVehicle(string i_CurrentKeyNumber)
        {
            Clint clint = null;
            if (!r_WorkCards.TryGetValue(i_CurrentKeyNumber, out clint))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            return clint.Vehicle;
        }

        public string MsgOfAllVehicleInGarageFillterStatus(bool i_OrderByStatus)
        {
            string msgAllVehicles;

            msgAllVehicles = i_OrderByStatus ? msgOfAllByStatus() : msgOfAllVehicleInGarage();               

            return msgAllVehicles;
        }

        private string msgOfAllVehicleInGarage()
        {
            StringBuilder vehicles = new StringBuilder(120);           
            vehicles.AppendLine("Vehicles in garage");
            foreach (Clint clint in r_WorkCards.Values)
            {
                vehicles.AppendLine(clint.Vehicle.LicenseNumber);
            }

            return vehicles.ToString();
        }

        private string msgOfAllByStatus()
        {
            string newLine = Environment.NewLine;
            StringBuilder vehicleInRepair = new StringBuilder(string.Format("== Vehicles in repair =={0}",newLine), 60) ;
            StringBuilder vehicleDoneRepair = new StringBuilder(string.Format("{0}== Vehicles done repair =={0}", newLine), 60) ;
            StringBuilder vehiclePaid = new StringBuilder(string.Format("{0}== Vehicles paid =={0}", newLine), 60);

            foreach (Clint clint in r_WorkCards.Values)
            {
                if (clint.CarStatus == Clint.eStatusInGarage.InRepair)
                {
                    vehicleInRepair.AppendLine(clint.Vehicle.LicenseNumber);
                }
                else if (clint.CarStatus == Clint.eStatusInGarage.DoneRepair)
                {
                    vehicleDoneRepair.AppendLine(clint.Vehicle.LicenseNumber);
                }
                else
                {
                    vehiclePaid.AppendLine(clint.Vehicle.LicenseNumber);
                }
            }

            vehicleInRepair.AppendFormat("{0}{1}", vehicleDoneRepair, vehiclePaid);
            return vehicleInRepair.ToString();
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