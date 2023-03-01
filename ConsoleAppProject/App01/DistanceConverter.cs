using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Take the users choice of conversion and the number they wish to convert and return the conversion.
    /// </summary>
    /// <author>
    /// Harrison Tween version 0.1
    /// </author>
    public class DistanceConverter
    {
        // Distance conversion constants
        public const int FEET_TO_MILES = 5280;
        public const double METRES_TO_MILES = 1609.34;
        public const double FEET_TO_METRES = 3.28084;

        // Distance unit names
        public const string FEET = "Feet";
        public const string MILES = "Miles";
        public const string METRES = "Metres";

        public string unit;

        public string newUnit;
        public int choice;
        public double value;

        public double newValue;
        public bool successfull = false;

        public void Run()
        {
            Input();
            CalculateDistance();
            Output();
        }

        private void Input()
        {
            // Input
            Console.WriteLine();
            Console.WriteLine($"1. {MILES} to {FEET}");
            Console.WriteLine($"2. {FEET} to {MILES}");
            Console.WriteLine($"3. {MILES} to {METRES}");
            while (successfull == false)
            {
                try
                {
                    Console.WriteLine("Enter number: ");
                    choice = Convert.ToInt16(Console.ReadLine());
                    if (choice > 3 || choice < 0) 
                    {
                        Console.WriteLine("Invalid choice, try again");
                        Console.WriteLine();
                    }
                    else
                    {
                        successfull = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            successfull = false;
            Console.WriteLine();
            while (successfull == false)
            {
                try
                {
                    Console.WriteLine("Enter conversion number");
                    value = Convert.ToDouble(Console.ReadLine());
                    successfull = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void CalculateDistance()
        {
            switch (choice)
            {
                // Miles to feet
                case 1: 
                    unit = MILES;
                    newUnit = FEET;
                    newValue = value * FEET_TO_MILES;
                break;

                // Feet to miles
                case 2: 
                    unit = FEET;
                    newUnit = MILES; 
                    newValue = value / FEET_TO_MILES; 
                break;

                // Miles to metres
                case 3: 
                    unit = MILES;
                    newUnit = METRES; 
                    newValue = METRES_TO_MILES * value;
                break;
            }
            
        }

        public void Output()
        {
            // Output
            Console.WriteLine($"{value} {unit} is {newValue} {newUnit}");
        }
    }
}
