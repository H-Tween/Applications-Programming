using System;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// This app will take the users height in meters and weight in kilograms, calculate their BMI and return it to the user.
    /// </summary>
    /// <author>
    /// Harrison Tween version 0.1
    /// </author>
    public class BMI
    {
        public double choice;
        private double height;
        private double weight;
        private double bmi;

        public int stone;
        public int pound;
        public int feet;
        public int inch;


        public void Run()
        {
            Input();
            Calculation();
            Output();
        }

        private void Input()
        {
            Console.WriteLine();
            Console.WriteLine("BMI Calculator");
            Console.WriteLine();
            Console.WriteLine("1. Imperial Units - weight in stones and pounds and height in feet and inches");
            Console.WriteLine("2. Metric Units - Weight in Kilograms and height in metres");
            Console.WriteLine("Enter number");
            Console.WriteLine();
            choice = Convert.ToDouble(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter your height in feet:");
                feet = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your height in inches:");
                inch = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Enter your weight in stones");
                stone = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your weight in pounds");
                pound = Convert.ToInt32(Console.ReadLine());
       

            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter your height in Meters");
                height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter your weight in Kilograms");
                weight = Convert.ToDouble(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }

        }

        private void Calculation()
        {
            if (choice == 1)
            {
                weight = pound + (stone * 14);
                height = inch + (feet * 12);
                bmi = (weight * 703) / (height * height);
            }
            else if (choice == 2)
            {
                bmi = weight / (height * height);
            }
        }

        private void Output()
        {
            Console.WriteLine($"Your BMI is {bmi}");
            if (bmi < 18.50)
            {
                Console.WriteLine("You are Underweight");
            }
            else if (bmi >= 18.50 && bmi <= 24.90)
            {
                Console.WriteLine("You are Normal");
            }
            else if (bmi >= 25.0 && bmi <= 29.9)
            {
                Console.WriteLine("You are Overweight");
            }
            else if (bmi >= 30.0 && bmi <= 34.9)
            {
                Console.WriteLine("You are Obese class 1");
            }
            else if (bmi >= 35.0 && bmi <= 39.9)
            {
                Console.WriteLine("You are Obese class 2");
            }
            else if (bmi >= 40.0)
            {
                Console.WriteLine("You are Obese class 3");
            }
        }
    }
}
