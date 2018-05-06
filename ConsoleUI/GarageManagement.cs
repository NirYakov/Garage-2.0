using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    public sealed class GarageManagement
    {
        private readonly GarageLogic.GarageActs r_Garage;

        public GarageManagement()
        {
            r_Garage = new GarageLogic.GarageActs();
        }

        public void OpenGarage()
        {
            const byte outOfChoiseRange = 200;
            bool quit = false;
            eGarageAction actionToDo;
            while (!quit)
            {
                
                Console.WriteLine(k_MenuMsg);
                actionToDo = (eGarageAction)(byte.TryParse(Console.ReadLine(), out byte userInputChoise) ? userInputChoise : outOfChoiseRange);
                quit = doActionInGarage(actionToDo);
            }
        }

        private bool doActionInGarage(eGarageAction option)
        {
            bool quit = false;
            switch (option)
            {
                case eGarageAction.Exit:
                    quit = true;
                    break;
                case eGarageAction.InsertCarToGarage:
                    createNewClient();
                    break;
                case eGarageAction.ListOfVehicles:
                    printListOfVehicleInGarage();
                    break;
                case eGarageAction.NewCarStatus:
                    changeVehicleStatus();
                    break;
                case eGarageAction.FillMaxWheelAir:
                    fillAirInWheelsToMaximum();
                    break;
                case eGarageAction.RefuelFuelVehicle:
                    refuelFuelVehicle();
                    break;
                case eGarageAction.ChargeElectricVehicle:
                    chargeElectricVehicle();
                    break;
                case eGarageAction.FullDataForOnwerAndVehicle:
                    fullDataForOnwerAndVehicle();
                    break;
                default:
                    Console.WriteLine("wrong input , insert again");
                    break;
            }

            Console.Clear();

            return quit;
        }

        public string EnumChoises(Type i_Type) // print all enum choises , all enum need start from 0
        {
            string[] allVehcleTypes = Enum.GetNames(i_Type);
            StringBuilder enumChoise = new StringBuilder(100);
            byte idx = 0;
            foreach (string vehicleType in allVehcleTypes)
            {
                enumChoise.AppendFormat("{0}. {1}{2}", idx++, vehicleType, Environment.NewLine);
            }

            return enumChoise.ToString();
        }
        
        private void getEnumChoise<T>(Type i_Type, out T o_Choise) where T : struct
        {
            T userChoise;
            while (!(Enum.TryParse(Console.ReadLine(), out userChoise) && Enum.IsDefined(i_Type, userChoise)))
            {
                Console.WriteLine("Wrong input, try again.");
            }

            o_Choise = userChoise;
        }

        private Vehicle createNewVehicle( out eVehicleOption o_CurretVehicle)
        {
            string licenceNum, modelNum;
            Console.WriteLine("insert the licence number");
            licenceNum = Console.ReadLine();
            while (r_Garage.IsAlreadyInGarage(licenceNum))
            {
                Console.WriteLine("The car in already in the garge , insert anther licence number .");
                licenceNum = Console.ReadLine();
            }

            Console.WriteLine(EnumChoises(typeof(eVehicleOption)));
            Console.WriteLine("Insert your number of choice then press 'enter'");
            getEnumChoise(typeof(eVehicleOption), out eVehicleOption currentChoise);
            Console.WriteLine("Insert model for the {0}", currentChoise);
            modelNum = Console.ReadLine();
            Vehicle newVehicle = VehicleCreator.CreateVehicle(currentChoise, licenceNum, modelNum);
            o_CurretVehicle = currentChoise;
            return newVehicle;
        }

        private void fullDataForOnwerAndVehicle()
        {
            Console.WriteLine("insert license number");
            try
            {
                Console.WriteLine(r_Garage.MsgFullDetailsVehicle(Console.ReadLine()));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void printListOfVehicleInGarage()
        {
            Console.WriteLine("insert true (any way) if you want order by status , any other input without status");
            if (!bool.TryParse(Console.ReadLine(), out bool userWantOrderByStatus))
            {
                userWantOrderByStatus = false;
            }

            Console.WriteLine(r_Garage.MsgOfAllVehicleInGarageFillterStatus(userWantOrderByStatus));
        }

        private void changeVehicleStatus()
        {
            string licenseNumber;

            Console.WriteLine("insert license number");
            licenseNumber = Console.ReadLine();
            Console.WriteLine( EnumChoises(typeof(Client.eStatusInGarage)) );
            getEnumChoise(typeof(Client.eStatusInGarage), out Client.eStatusInGarage chosenStatus);
            try
            {
                r_Garage.ChangeVehicleStatus(licenseNumber, chosenStatus);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void chargeElectricVehicle()
        {
            string licenseNumber;
            float chargingMinutesAmount;
            Console.WriteLine("insert license number");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("insert amount of hours charging you want to add");
            while (!float.TryParse(Console.ReadLine(), out chargingMinutesAmount))
            {
                Console.WriteLine("wrong input, try again");
            }

            try
            {
                r_Garage.ChargeBattary(licenseNumber, chargingMinutesAmount);
            }
            catch (ValueOutOfRangeException voore)
            {
                Console.WriteLine(voore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void fillAirInWheelsToMaximum()
        {
            Console.WriteLine("insert license number");
            try
            {
                r_Garage.FillMaxWheelsAir(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void createNewClient()
        {
            Vehicle newVehicle = createNewVehicle(out eVehicleOption curretVehicle);
            fillAndAddClientToTheGarage(newVehicle);
            VehiclePropertise(newVehicle);
            
            switch (curretVehicle)
            {
                case eVehicleOption.FuelCar:
                case eVehicleOption.ElecticCar:
                    CarPropertise(newVehicle);
                    break;
                case eVehicleOption.FuelMotorcycle:
                case eVehicleOption.ElectricMotorcycle:
                    MotorcyclePropertise(newVehicle);
                    break;
                case eVehicleOption.FuelTrack:
                    TrackPropertise(newVehicle);
                    break;
            }

        }

        private void fillAndAddClientToTheGarage(Vehicle i_NewVehicle)
        {
            string clientName, clientPhoneNumber;
            Console.WriteLine("insert your name");
            clientName = Console.ReadLine();
            Console.WriteLine("insert your phone number");
            clientPhoneNumber = Console.ReadLine();
            r_Garage.InsertNewClient(i_NewVehicle, clientName, clientPhoneNumber);
        }

        private void refuelFuelVehicle()
        {
            string licenseNumber;
            float fuelAmount;
            Console.WriteLine("insert license number");
            licenseNumber = Console.ReadLine();
            Console.WriteLine("insert the amount of fuel to add");
            while(!float.TryParse(Console.ReadLine(), out fuelAmount))
            {
                Console.WriteLine("wrong input, try again");
            }
            Console.WriteLine(EnumChoises(typeof(eFuelType)));
            getEnumChoise(typeof(eFuelType), out eFuelType chosenTypeFuel);
            try
            {
                r_Garage.RefuelVehicle(licenseNumber, fuelAmount, chosenTypeFuel);
            }
            catch(ValueOutOfRangeException voore)
            {
                Console.WriteLine(voore.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void wheelsProperty(Vehicle i_Vehicle)
        {
            bool clientInsertLegalPresser = false;
            string manufacturerNameOfWheels;
            float airPressure = 0;
            Console.WriteLine("insert name of manufacturer of wheels");
            manufacturerNameOfWheels = Console.ReadLine();
            Console.WriteLine("insert air pressure that you want in wheels");

            while (!clientInsertLegalPresser)
            {
                if (float.TryParse(Console.ReadLine(), out airPressure))
                {
                    try
                    {
                        VehicleCreator.VehicleWheelsProperty(i_Vehicle, manufacturerNameOfWheels, airPressure);
                        clientInsertLegalPresser = true;
                    }
                    catch (ValueOutOfRangeException voore)
                    {
                        Console.WriteLine(voore.Message);
                    }
                }
                else
                {
                    Console.WriteLine("it ilegal input try again");
                }
            }
        }

        private void setEnergyInVehicle(Vehicle i_Vehicle)
        {
            float currentPercentOfEnergy;
            Console.WriteLine("insert current percent energy in your vehicle");
            bool clientInsertLegalpercent = false;
            while (!clientInsertLegalpercent)
            {
                if (float.TryParse(Console.ReadLine(), out currentPercentOfEnergy))
                {
                    try
                    {
                        VehicleCreator.VehicleEnergyProperty(i_Vehicle, currentPercentOfEnergy);
                        clientInsertLegalpercent = true;
                    }
                    catch (ValueOutOfRangeException voore)
                    {
                        Console.WriteLine("insert percent between 0 to 100");
                    }
                }
                else
                {
                    Console.WriteLine("it ilegal input try again");
                }
            }
        }

        void VehiclePropertise(Vehicle i_Vehicle)
        {
            wheelsProperty(i_Vehicle);
            setEnergyInVehicle(i_Vehicle);
        }

        void CarPropertise(Vehicle i_Car) // its private ? -> need to be carPropertise
        {
            Console.WriteLine("Insert plase number of doors between 2 - 5 and then press 'enter' (defualt is 2)");
            if (!byte.TryParse(Console.ReadLine(), out byte numOfDoors) || !(numOfDoors >= 2 && numOfDoors <= 5))
            {
                numOfDoors = 2;
            }

            Console.WriteLine("Now insert your car color");
            Console.WriteLine("Insert your number of choice then press 'enter'"); // to do it in maybe another place the Msg. becuse if commeon.
            Console.WriteLine(EnumChoises(typeof(Car.eCarColor)));
            getEnumChoise(typeof(Car.eCarColor), out Car.eCarColor chosenColor);

            VehicleCreator.CarPropertise(i_Car, numOfDoors, chosenColor);
        }

        void MotorcyclePropertise(Vehicle i_Moto)
        {
            const int MaxEngieCapacity = 7_000;            
            Console.WriteLine(
                "Insert plase Engine Capacity between 0 - {0} and then press 'enter' (defualt is 500)"
                , MaxEngieCapacity);
            if (!int.TryParse(Console.ReadLine(), out int engineCapacity) || !(engineCapacity >= 0 && engineCapacity <= 7_000))
            {
                engineCapacity = 500;
            }

            Console.WriteLine("Choose type of license");
            Console.WriteLine(EnumChoises(typeof(Motorcycle.eTypeOfLicense)));
            getEnumChoise(typeof(Motorcycle.eTypeOfLicense), out Motorcycle.eTypeOfLicense typeOfLicense);
            VehicleCreator.MotorcyclePropertise(i_Moto, engineCapacity, typeOfLicense);
        }

        void TrackPropertise(Vehicle i_Track)
        {
            Console.WriteLine("Insert plase Trunk Capacity between 0 - 600,000 and then press 'enter' (defualt is 100,000)");
            if (!float.TryParse(Console.ReadLine(), out float trunkCapacity) || !(trunkCapacity >= 0 && trunkCapacity <= 600_000f))
            {
                trunkCapacity = 100_000f;
            }

            Console.WriteLine("insert true (any way) if you want Trunk With Cooling Cell, another for Trunk less Cooling Cell");
            if (!bool.TryParse(Console.ReadLine(), out bool isHaveCoolTrunk))
            {
                isHaveCoolTrunk = false;
            }

            VehicleCreator.TrackPropertise(i_Track, trunkCapacity, isHaveCoolTrunk);
        }

        private const string k_MenuMsg =
@"
Menu
============== Insert the number of Action you want and then press 'enter ' ==============
0. Exit
1. Insert car to garage
2. List of vehicles in progress , only licence number .  
3. New vehicle status
4. Fill untill Max wheel air to vehicle's
5. Refuel fuel vehicle
6. Charge electric vehicle
7. Full data for onwer and vehicle";

        private enum eGarageAction : byte
        {
            Exit,
            InsertCarToGarage,
            ListOfVehicles,
            NewCarStatus,
            FillMaxWheelAir,
            RefuelFuelVehicle,
            ChargeElectricVehicle,
            FullDataForOnwerAndVehicle,
        }
    }
}
