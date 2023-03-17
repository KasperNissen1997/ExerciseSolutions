using ExtensionMethods;

namespace ExtensionMethodsTestProject
{
    [TestClass]
    public class AgeUnitTests
    {
        [TestMethod]
        public void Age_ReturnOne_WhenRefDTIsOneYearOlderThanStartDT()
        {
            // Arrange
            DateTime startDT = new(1, 1, 1);
            DateTime refDT = new(2, 1, 1);

            // Act
            int age = startDT.Age(refDT);

            // Assert
            Assert.AreEqual(1, age);
        }

        [TestMethod]
        public void Age_ReturnsZero_WhenRefDTIsBeforeStartDT()
        {
            // Arrange
            DateTime startDT = new(2, 1, 1);
            DateTime refDT = new(1, 1, 1);

            // Act
            int age = startDT.Age(refDT);

            // Assert
            Assert.AreEqual(0, age);
        }

        [TestMethod]
        public void Age_ReturnsOne_WhenDifferenceIsDirty()
        {
            // Arrange
            DateTime startDT = new(1, 1, 1);
            DateTime refDT = new(2, 6, 22);

            // Act
            int age = startDT.Age(refDT);

            // Assert
            Assert.AreEqual(1, age);
        }

        [TestMethod]
        public void Age_ReturnsZero_WhenStartDTIsEndOfFebruaryInLeapYearAndRefDTIsEndOfFebruaryInNormalYear()
        {
            // Arrange
            DateTime startDT = new(4, 2, 29); // This is the earliest leap year AC
            DateTime refDT = new(5, 2, 28);

            // Act
            int age = startDT.Age(refDT);

            // Assert
            Assert.AreEqual(0, age);
        }

        [TestMethod]
        public void Age_Returns2000_WhenStartDTIs2000YearsOlderThanRefDT()
        {
            // Arrange
            DateTime startDT = new(1, 1, 1);
            DateTime refDT = new(2001, 1, 1);

            // Act
            int age = startDT.Age(refDT);

            // Assert
            Assert.AreEqual(2000, age);
        }

        [TestMethod]
        public void Age_ReturnsZero_WhenRefDTIsOlderThanStartDTExtremeCase()
        {
            // Arrange
            DateTime startDT = new(2001, 1, 1);
            DateTime refDT = new(1, 1, 1);

            // Act
            int age = startDT.Age(refDT);

            // Assert
            Assert.AreEqual(0, age);
        }
    }
}
