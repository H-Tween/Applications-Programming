using ConsoleAppProject.App03;
using System;

namespace ConsoleAppUnitTest
{
    [TestClass]
    public class App03Test
    {
        [TestMethod]
        public void CheckStudent01Grade()
        {
            StudentGrades student = new StudentGrades();
            student.CreateDictionary();
            student.choice = 1;
            student.studentNumber = 1;
            student.newMark = 70;
            student.Grade(student.newMark);

            Grades expectedOutput = Grades.A;
            var actualOutput = student.grade;

            Assert.AreEqual(expectedOutput, actualOutput);
        }

    }
}