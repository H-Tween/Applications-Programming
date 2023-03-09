using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ConsoleAppProject.Helpers;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel.Design;

namespace ConsoleAppProject.App03
{
    /// <summary>
    /// At the moment this class just tests the
    /// Grades enumeration names and descriptions
    /// </summary>
    public class StudentGrades
    {
        public int choice;

        public int newMark;
        public string grade;
        public int meanMark;


        private bool running = true;


        public void Run()
        {
            var Students = CreateDictionary();
            while (running == true)
            {
                Input();
                Program(Students);
            }

        }

        public Dictionary<int, int> CreateDictionary()
        {
            var Students = new Dictionary<int, int>
            {
                // Student number, student mark
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 },
                { 7, 0 },
                { 8, 0 },
                { 9, 0 },
                { 10, 0 }
            };
            return Students;
        }


        public void Input()
        {
            Console.WriteLine();
            Console.WriteLine("Student Marks");
            Console.WriteLine();
            Console.WriteLine("1. Input Student Marks");
            Console.WriteLine("2. Output Student Mark");
            Console.WriteLine("3. Output Student Grade");
            Console.WriteLine("4. Output Mean Student Marks");
            Console.WriteLine("5. Output Grade Boundaries");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Enter number > ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
        }
        public void Program(Dictionary<int, int> Students)
        {
            if (choice == 1)
            {
                while (running == true)
                {
                    Console.Write("Enter number of student > ");
                    int studentNumber = Convert.ToInt32(Console.ReadLine());

                    if (Students.TryGetValue(studentNumber, out newMark))
                    {
                        Console.Write("Enter mark of student > ");
                        newMark = int.Parse(Console.ReadLine());
                        Students[studentNumber] = newMark;
                    }

                    else { Console.WriteLine("Student doesn't exist"); }
                    
                    Console.WriteLine();
                    Console.Write("Would you like to enter another students mark? (y/n) > ");
                    string decision = Console.ReadLine();
                    if (decision == "y") { running = true; }

                    else if (decision == "n" || decision != "y") { running = false; }
                }
                running = true;
            }
            else if (choice == 2 || choice == 4)
            {
                foreach (KeyValuePair<int, int> student in Students)
                {
                    if (choice == 2) { Console.WriteLine("Student {0} :, Mark: {1}", student.Key, student.Value); }
                    else
                    {
                        meanMark += student.Value;
                    }
                }
                if (choice == 4)
                {
                    meanMark = meanMark / Students.Count; //length of dictionary
                    Console.WriteLine($"The average/mean marks were {meanMark}");
                }
            }
            else if (choice == 3)
            {
                foreach (KeyValuePair<int, int> student in Students)
                {
                    int mark = student.Value;
                    Grades grade = Grade(mark);
                    Console.WriteLine("Student: {0}, Grade: {1}", student.Key, grade);
                }
            }
            else if (choice == 5)
            {
                //Console.WriteLine(Grades.A); // write description of grades
            }
            else if (choice == 6)
            {
                running = false;
                Console.WriteLine("Exiting...");
            }
            else { Console.WriteLine("Invalid input"); }

        }

        public Grades Grade(int mark)
        {
            if (mark >= 70)
            {
                return Grades.A;
            }
            else if (mark >= 60)
            {
                return Grades.B;
            }
            else if (mark >= 50)
            {
                return Grades.C;
            }
            else if (mark >= 40)
            {
                return Grades.D;
            }
            else
            {
                return Grades.F;
            }
        }
    }
}
