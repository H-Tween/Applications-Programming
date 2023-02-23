using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Derek version 0.1
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

        private string unit;

        private string newUnit;
        private string choice;
        private double value;

        private double newValue;

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
            Console.WriteLine("Enter number: ");
            choice = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter conversion number");
            value = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine(miles);
        }

        private void CalculateDistance()
        {
            switch (choice)
            {
                // Miles to feet
                case "1": 
                    unit = MILES;
                    newUnit = FEET;
                    newValue = value * FEET_TO_MILES;
                break;

                // Feet to miles
                case "2": 
                    unit = FEET;
                    newUnit = MILES; 
                    newValue = value / FEET_TO_MILES; 
                break;

                // Miles to metres
                case "3": 
                    unit = MILES;
                    newUnit = METRES; 
                    newValue = METRES_TO_MILES * value;
                break;
            }
            
        }

        private void Output()
        {
            // Output
            Console.WriteLine($"{value} {unit} is {newValue} {newUnit}");
        }
    }
}
