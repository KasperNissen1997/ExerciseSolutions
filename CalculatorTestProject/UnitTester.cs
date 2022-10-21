using ExerciseProject;
using ExerciseProject.Exercise5;

namespace TestExerciseSolutions
{
    [TestClass]
    public class UnitTester
    {
        Calculator calc = new Calculator();

        [TestMethod]
        public void TestAdd () {
            Assert.AreEqual(3, calc.Add(1, 2));
        }

        [TestMethod]
        public void TestSubtract () {
            Assert.AreEqual(6, calc.Subtract(8, 2));
        }

        [TestMethod]
        public void TestDivide1 () {
            Assert.AreEqual(4, calc.Divide(8, 2));
        }

        [TestMethod]
        public void TestDivide2 () {
            Assert.AreEqual(2.67, Math.Round(calc.Divide(8, 3), 2));
        }

        [TestMethod]
        public void TestMultiply () {
            Assert.AreEqual(8, calc.Multiply(4, 2));
        }

        #region Bonus exercises
        [TestMethod]
        public void SockMarchantTest1 () {
            int[] arr = { 10, 10, 20, 20, 30, 30, 40, 40, 50 };
            Assert.AreEqual(4, Program.SockMerchant(arr));
        }

        [TestMethod]
        public void SockMarchantTest2 () {
            int[] arr = { 40, 20, 10, 20, 30, 40, 40, 30, 40 };
            Assert.AreEqual(4, Program.SockMerchant(arr));
        }

        [TestMethod]
        public void SockMarchantTest3 () {
            int[] arr = { 1, 1, 3, 1, 2, 1, 3, 3, 3, 3, 1, 3, 4, 5, 4, 3, 7, 5, 4, 9, 1, 2 };
            Assert.AreEqual(9, Program.SockMerchant(arr));
        }

        [TestMethod]
        public void CandleBlower1 () {
            int[] arr = { 1, 1, 2, 2, 3, 4, 4 };
            Assert.AreEqual(2, Program.CandleBlower(arr));
        }

        [TestMethod]
        public void CandleBlower2 () {
            int[] arr = { 5, 2, 1, 5, 3, 4, 3 };
            Assert.AreEqual(2, Program.CandleBlower(arr));
        }

        [TestMethod]
        public void CandleBlower3 () {
            int[] arr = { 2, 6, 5, 2, 8, 3, 4, 7, 9, 2, 5, 6, 8, 9, 1, 4, 5, 6, 9, 2, 4, 8, 7 };
            Assert.AreEqual(3, Program.CandleBlower(arr));
        }
        #endregion
    }

}