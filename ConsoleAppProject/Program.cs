﻿using ConsoleAppProject.App01;
using ConsoleAppProject.App02;
using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// Derek Peacock 05/02/2022
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            //Console.WriteLine();
            //Console.WriteLine(" =================================================");
            //Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
            //Console.WriteLine("        by Harrison Tween                         ");
            //Console.WriteLine(" =================================================");
            //Console.WriteLine();


            //Console.WriteLine("1. App01 - Distance converter");
            //Console.WriteLine("2. App02 - BMI");
            //Console.WriteLine("3. App03 - StudentMarks");
            //Console.WriteLine("4. App04 - NewsFeed");
            //Console.Write("Enter Number > ");

            string heading = "BNU CO453 Applications Programming 2022-2023!";
            ConsoleHelper.OutputHeading(heading);
            bool quit = false;
            do
            {
                string[] choices = new string[] { "App01 - Distance converter", "App02 - BMI", "App03 - StudentMarks", "App04 - NewsFeed", "Quit" };

                int choice = ConsoleHelper.SelectChoice(choices);


                //string app = Console.ReadLine();
                //int currentApp = 0;

                switch (choice)
                {
                    case 1:
                        DistanceConverter converter = new DistanceConverter();
                        converter.Run();
                        break;

                    case 2:
                        BMI bmi = new BMI();
                        bmi.Run();
                        break;

                    case 3:
                        StudentGrades student = new StudentGrades();
                        student.Run();
                        break;

                    case 4:
                        Post post = new Post();
                        post.DisplayMenu();
                        break;

                    case 5: quit = true; Console.WriteLine(); Console.WriteLine("    Exiting...  "); break;
                }
            } while (!quit);
        }
    }
}
