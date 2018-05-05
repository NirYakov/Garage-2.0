﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GarageLogic;

namespace ConsoleUI
{
    public class SecretariatOfGarage
    {
        private readonly GarageLogic.GarageActs r_Garage;


        public SecretariatOfGarage()
        {
            r_Garage = new GarageLogic.GarageActs();
        }

        public void OpenGarage()
        {
            const byte outOfChoiseRange = 200;
            bool quit = false;
            eGarageAction actionToDo;
            Console.WriteLine(k_MenuMsg);
            while (!quit)
            {
                actionToDo = (eGarageAction)(byte.TryParse(Console.ReadLine(), out byte userInputChoise) ? userInputChoise : outOfChoiseRange);
                Console.Clear();
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
                    createNewVehicle();
                    break;
                default:
                    Console.WriteLine("worng input , insert again");
                    break;
            }

            Console.WriteLine(option);
            return quit;
        }

        private void createNewVehicle()
        {
            string[] allVehcleTypes = Enum.GetNames(typeof(eVehicleOption));
            byte idx = 0;
            foreach (string vehicleType in allVehcleTypes)
            {
                Console.WriteLine("{0}. {1}", idx++, vehicleType);
            }

           // Vehicle v = Clint.returnFuelCar(); //  nir delete

            Console.WriteLine("Insert your number of choice then press 'enter'");
            

            eVehicleOption vehicleChoise;
            const byte outOfChoiseRange = 200;
            vehicleChoise = (eVehicleOption)(byte.TryParse(Console.ReadLine(), out byte userInputChoise) ? userInputChoise : outOfChoiseRange);

            string licenceNum = "123" , modelNum = "456";
            // yosi start
            // question- if vehicleChoise = outOfChoiseRange what happend?
            Console.WriteLine("insert the licence number" );
            licenceNum = Console.ReadLine();
            // yosi end

            while (r_Garage.IsAlreadyInGarage(licenceNum))
            {
                Console.WriteLine("The car in already in the garge , insert anther licence number .");
                licenceNum = Console.ReadLine();
            }

            // yosi start 
            Console.WriteLine("insert the model of car");
            modelNum = Console.ReadLine(); // need change to modelName ?
            // yosi end 

            Vehicle newVehicle= VehicleCreator.CreateVehicle(vehicleChoise, licenceNum, modelNum);

            switch (vehicleChoise)
            {
                case eVehicleOption.FuelCar:
                case eVehicleOption.ElecticCar:
                    CarPropertise(newVehicle);
                    break;
                case eVehicleOption.FuelMotorcycle:
                case eVehicleOption.ElectricMotorcycle:
                    // yosi start
                    MotorcyclePropertise(newVehicle);
                    // yosi end 
                    break;
                case eVehicleOption.FuelTrack:
                    
                    break;
            }

        }
        
        void CarPropertise(Vehicle i_Car)
        {
            Console.WriteLine("Insert plase number of doors between 2 - 5 and then press 'enter' (defualt is 2)");
            if (!byte.TryParse(Console.ReadLine() , out byte numOfDoors ) || !(numOfDoors >= 2 && numOfDoors <= 5))
            {
                numOfDoors = 2;
            }

            Console.WriteLine("Now insert your car color (defualt is Gray)");
            Console.WriteLine("Insert your number of choice then press 'enter'"); // to do it in maybe another place the Msg. becuse if commeon.
            
            string[] allCarColors = Enum.GetNames(typeof(Car.eCarColor));
            byte idx = 0;
            foreach (string color in allCarColors)
            {
                Console.WriteLine("{0}. {1}", idx++, color);
            }

            Car.eCarColor chosenColor;
            const byte outOfChoiseRange = 200;
            chosenColor = (Car.eCarColor)(byte.TryParse(Console.ReadLine(), out byte userInputChoise) ? userInputChoise : outOfChoiseRange);

            VehicleCreator.CarPropertise(i_Car , numOfDoors , chosenColor);
        }

        void MotorcyclePropertise(Vehicle i_Moto)
        {
            // yosi start
            Console.WriteLine("Insert plase Engine Capacity between 0 - 7,000 and then press 'enter' (defualt is 500)");
            if (!int.TryParse(Console.ReadLine(), out int engineCapacity) || !(engineCapacity >= 0 && engineCapacity <= 7_000))
            {
                engineCapacity = 500;
            }

            Console.WriteLine("choos type of license   (difult is A)");
            string[] allTypeOfLicense = Enum.GetNames(typeof(Motorcycle.eTypeOfLicense));
            byte idx = 0;
            foreach (string typeLicense in allTypeOfLicense)
            {
                Console.WriteLine("{0}. {1}", idx++, typeLicense);
            }

            Motorcycle.eTypeOfLicense typeOfLicense;
            if ( !(Enum.TryParse<Motorcycle.eTypeOfLicense>(Console.ReadLine(), out typeOfLicense)) || ! ((byte)typeOfLicense < idx) )
            {
                typeOfLicense = Motorcycle.eTypeOfLicense.A;
            }
            // yosi end
            VehicleCreator.MotorcyclePropertise(i_Moto,engineCapacity,typeOfLicense);
        }

        void TrackPropertise(Vehicle i_Track)
        {
            //yosi start
            //m_IsHaveCoolTrunk
            Console.WriteLine("Insert plase Trunk Capacity between 0 - 600,000 and then press 'enter' (defualt is 100,000)");
            if (!float.TryParse(Console.ReadLine(), out float trunkCapacity) || !(trunkCapacity >= 0 && trunkCapacity <= 600_000f))
            {
                trunkCapacity = 100_000f;
            }
            Console.WriteLine("insert 1 is you want Trunk With Cooling Cell another for Trunk less Cooling");
            if (!bool.TryParse(Console.ReadLine(), out bool isHaveCoolTrunk))
            {
                isHaveCoolTrunk  false;
            }


            VehicleCreator.TrackPropertise();
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
