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
                GarageLogic.PetrolMotorcycle stam = new GarageLogic.PetrolMotorcycle("jj", "09", "A1", 300);
                Console.WriteLine(stam.EngineCapacity);
                
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
