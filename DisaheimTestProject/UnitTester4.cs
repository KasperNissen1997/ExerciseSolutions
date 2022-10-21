using ExerciseProject.Exercise15x16x17x18x19;

namespace DisaheimTestProject
{
    [TestClass]
    public class UnitTester4
    {
        Book b1, b2, b3;
        Amulet a1, a2, a3;
        Course c1, c2;

        ValuableRepository valuables;

        [TestInitialize]
        public void Init () {
            // Arrange
            b1 = new Book("1");
            b2 = new Book("2", "Falling in Love with Yourself");
            b3 = new Book("3", "Spirits in the Night", 123.55);

            a1 = new Amulet("11");
            a2 = new Amulet("12", Level.high);
            a3 = new Amulet("13", Level.low, "Capricorn");

            c1 = new Course("Eufori med røg");
            c2 = new Course("Nuru Massage using Chia Oil", 157);

            valuables = new ValuableRepository();

            // Act
            valuables.AddValuable(b1);
            valuables.AddValuable(b2);
            valuables.AddValuable(b3);

            valuables.AddValuable(a1);
            valuables.AddValuable(a2);
            valuables.AddValuable(a3);

            valuables.AddValuable(c1);
            valuables.AddValuable(c2);
        }

        [TestMethod]
        public void TestGetBook () {
            // Assert
            Assert.AreEqual(b2, valuables.GetValuable("2"));
        }
        [TestMethod]
        public void TestGetAmulet () {
            // Assert
            Assert.AreEqual(a3, valuables.GetValuable("13"));
        }
        [TestMethod]
        public void TestGetCourse () {
            // Assert
            Assert.AreEqual(c1, valuables.GetValuable("Eufori med røg"));
        }
        [TestMethod]
        public void TestGetTotalValueForMerchandise () {
            // Assert
            Assert.AreEqual((123.55 + 60.0 + 2625.0), valuables.GetTotalValue()); // 123.55 for books, 60.0 for amulets, 2625.0 for courses
        }
    }

}
