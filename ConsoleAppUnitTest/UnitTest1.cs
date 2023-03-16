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
            student.newMark = 70;
            Grades grade = student.Grade(student.newMark);

            Grades expectedOutput = Grades.A;

            Assert.AreEqual(expectedOutput, grade);
        }

        [TestMethod]
        public void CheckStudent02Grade()
        {
            StudentGrades student = new StudentGrades();
            student.newMark = 60;
            Grades grade = student.Grade(student.newMark);

            Grades expectedOutput = Grades.B;

            Assert.AreEqual(expectedOutput, grade);
        }

        [TestMethod]
        public void CheckStudent03Grade()
        {
            StudentGrades student = new StudentGrades();
            student.newMark = 50;
            Grades grade = student.Grade(student.newMark);

            Grades expectedOutput = Grades.C;

            Assert.AreEqual(expectedOutput, grade);
        }

        [TestMethod]
        public void CheckStudent04Grade()
        {
            StudentGrades student = new StudentGrades();
            student.newMark = 40;
            Grades grade = student.Grade(student.newMark);

            Grades expectedOutput = Grades.D;

            Assert.AreEqual(expectedOutput, grade);
        }

        [TestMethod]
        public void CheckStudent05Grade()
        {
            StudentGrades student = new StudentGrades();
            student.newMark = 30;
            Grades grade = student.Grade(student.newMark);

            Grades expectedOutput = Grades.F;

            Assert.AreEqual(expectedOutput, grade);
        }
    }
}