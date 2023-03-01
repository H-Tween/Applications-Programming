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
        private double height;
        private double weight;
        private double bmi;

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
            Console.WriteLine("Enter your height in Meters");
            height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter your weight in Kilograms");
            weight = Convert.ToDouble(Console.ReadLine());

        }

        private void Calculation()
        {
            bmi = weight / (height * height);
        }

        private void Output()
        {
            if (bmi < 18.50)
            {
                Console.WriteLine("Underweight");
            }
            else if (bmi >= 18.50 && bmi <= 24.90)
            {
                Console.WriteLine("Normal");
            }
            else if (bmi >= 25.0 && bmi <= 29.9)
            {
                Console.WriteLine("Overweight");
            }
            else if (bmi >= 30.0 && bmi <= 34.9)
            {
                Console.WriteLine("Obese class 1");
            }
            else if (bmi >= 35.0 && bmi <= 39.9)
            {
                Console.WriteLine("Obese class 2");
            }
            else if (bmi >= 40.0)
            {
                Console.WriteLine("Obese class 3");
            }
        }
    }
}
