using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic
{
    public sealed class GarageActs
    {
        private readonly Dictionary<string, Client> r_WorkCards = new Dictionary<string, Client>();

        public GarageActs()
        {
        }

        public void ChargeBattary(string i_LicenseNum, float i_MinuteToCharge)
        {
            const string electric = "Electric";          

            if (!r_WorkCards.TryGetValue(i_LicenseNum, out Client Client))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            Client.Vehicle.FillEnergy(i_MinuteToCharge, electric);
        }

        public void RefuelVehicle(string i_LicenseNum , float i_FuelAmount ,eFuelType i_FuelType) // Book tosee and fix the fuels fill.
        {
            if (!r_WorkCards.TryGetValue(i_LicenseNum, out Client Client))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            Client.Vehicle.FillEnergy(i_FuelAmount, i_FuelType.ToString());           
        }

        public void FillMaxWheelsAir(string i_LicenseNum)
        {
            if (!r_WorkCards.TryGetValue(i_LicenseNum, out Client Client))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            Client.Vehicle.FillMaxWheelsAir();
        }

        public void ChangeVehicleStatus(string i_LicenseNum, Client.eStatusInGarage i_NewStatus)
        {
            if (!r_WorkCards.TryGetValue(i_LicenseNum, out Client Client))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            Client.CarStatus = i_NewStatus;           
        }
        
        public string MsgFullDetailsVehicle(string i_LicenseNum)
        {
            if (!r_WorkCards.TryGetValue(i_LicenseNum, out Client Client))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            return Client.ToString();
        }

        public void ChargeElecticVehicle(string i_LicenseNum, float i_BattaryTime)
        {
            Vehicle vehicle = getCurretVehicle(i_LicenseNum);
        }

        public void InsertNewClient(Vehicle i_NewVehicle,string i_ClientName,string  i_ClientPhoneNumber)
        {
            Client newClient = new Client(i_NewVehicle, i_ClientName, i_ClientPhoneNumber);
            r_WorkCards.Add(newClient.Vehicle.LicenseNumber, newClient);
        }

        private Vehicle getCurretVehicle(string i_CurrentKeyNumber)
        {
            Client Client = null;
            if (!r_WorkCards.TryGetValue(i_CurrentKeyNumber, out Client))
            {
                throw new Exception("Vehicle doesn't exists");
            }

            return Client.Vehicle;
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
            foreach (Client Client in r_WorkCards.Values)
            {
                vehicles.AppendLine(Client.Vehicle.LicenseNumber);
            }

            return vehicles.ToString();
        }

        private string msgOfAllByStatus()
        {
            string newLine = Environment.NewLine;
            StringBuilder vehicleInRepair = new StringBuilder(string.Format("== Vehicles in repair =={0}",newLine), 60) ;
            StringBuilder vehicleDoneRepair = new StringBuilder(string.Format("{0}== Vehicles done repair =={0}", newLine), 60) ;
            StringBuilder vehiclePaid = new StringBuilder(string.Format("{0}== Vehicles paid =={0}", newLine), 60);

            foreach (Client Client in r_WorkCards.Values)
            {
                if (Client.CarStatus == Client.eStatusInGarage.InRepair)
                {
                    vehicleInRepair.AppendLine(Client.Vehicle.LicenseNumber);
                }
                else if (Client.CarStatus == Client.eStatusInGarage.DoneRepair)
                {
                    vehicleDoneRepair.AppendLine(Client.Vehicle.LicenseNumber);
                }
                else
                {
                    vehiclePaid.AppendLine(Client.Vehicle.LicenseNumber);
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