using ConsoleAppProject.App01;

namespace ConsoleAppUnitTest
{
    public class App01Test
    {
        [TestMethod]
        public void TestFeetToMiles()
        {
            DistanceConverter converter = new DistanceConverter();
            converter.choice = 2;
            converter.value = 5280;
            converter.CalculateDistance();

            double expectedOutput = 1.0;

            Assert.AreEqual(expectedOutput, converter.newValue);
        }
        [TestMethod]
        public void TestMilesToFeet()
        {
            DistanceConverter converter = new DistanceConverter();
            converter.choice = 1;
            converter.value = 1;
            converter.CalculateDistance();

            double expectedOutput = 5280;

            Assert.AreEqual(expectedOutput, converter.newValue);
        }
        [TestMethod]
        public void TestMilesToMeters()
        {
            DistanceConverter converter = new DistanceConverter();
            converter.choice = 3;
            converter.value = 2;
            converter.CalculateDistance();

            double expectedOutput = 3218.68;

            Assert.AreEqual(expectedOutput, converter.newValue);
        }
    }
}