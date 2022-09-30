using ExerciseProject;

namespace TheHundredAcreWoodTestProject
{
    [TestClass]
    public class UnitTester
    {
        [TestMethod]
        public void TestMethod1 () {
            Assert.AreEqual("12,12", Program.JumpTiggerAndVinnie(0, 3, 4, 2));
        }
        [TestMethod]
        public void TestMethod2 () {
            Assert.AreEqual("NO", Program.JumpTiggerAndVinnie(0, 2, 5, 3));
        }
        [TestMethod]
        public void TestMethod3 () {
            Assert.AreEqual("182,182", Program.JumpTiggerAndVinnie(14, 4, 98, 2));
        }
        [TestMethod]
        public void TestMethod4 () {
            Assert.AreEqual("NO", Program.JumpTiggerAndVinnie(21, 6, 47, 3));
        }
        [TestMethod]
        public void TestMethod5 () {
            Assert.AreEqual("198,198", Program.JumpTiggerAndVinnie(42, 3, 94, 2));
        }
        [TestMethod]
        public void TestMethod6 () {
            Assert.AreEqual("2480675,2480675", Program.JumpTiggerAndVinnie(4523, 8092, 9419, 8076));
        }
        [TestMethod]
        public void TestMethod7 () {
            Assert.AreEqual("NO", Program.JumpTiggerAndVinnie(6644, 5868, 8349, 3477));
        }

    }
}