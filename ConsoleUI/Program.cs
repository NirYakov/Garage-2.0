using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class Program // book add ref to GarageLogic for checking 
    {
        public static void Main()
        {      
           
            //Testing();
            TestingYosi();

            Console.ReadLine();
            
        }

        public static void TestingYosi()
        {
            try
            {
               GarageLogic.ElectricCar stam = GarageLogic.CreatorVehicle.CreateVehicle("CreateElectricCar,") as GarageLogic.ElectricCar;
                Console.WriteLine(stam.CarColor);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           

           // Console.WriteLine(stam.CarColor);
            Console.ReadLine();
            
        }
    }
}
