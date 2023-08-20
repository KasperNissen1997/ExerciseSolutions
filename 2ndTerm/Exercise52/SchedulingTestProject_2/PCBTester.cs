using Scheduling_2;

namespace SchedulingTestProject_2
{
    [TestClass]
    public class PCBTester
    {
        PCB dummyPCB;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            dummyPCB = new("Dummy process", 1);
        }

        #region Constructor Tests
        [TestMethod]
        public void SimpleConstructorName()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new("'Ew' process", 2);

            // Assert
            Assert.AreEqual("'Ew' process", oldPeoplePeeCB.ProcessName);
        }

        [TestMethod]
        public void SimpleConstructorPriority()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new("'Ew' process", 2);

            // Assert
            Assert.AreEqual(2, oldPeoplePeeCB.ProcessPriority);
        }

        [TestMethod]
        public void SimpleConstructorState()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new("'Ew' process", 2);

            // Assert
            Assert.AreEqual(PCB.ProcessStateType.New, oldPeoplePeeCB.ProcessState);
        }

        [TestMethod]
        public void InlineConstructorName()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new()
            {
                ProcessName = "'Ew' process",
                ProcessPriority = 1
            };

            // Assert
            Assert.AreEqual("'Ew' process", oldPeoplePeeCB.ProcessName);
        }

        [TestMethod]
        public void InlineConstructorPriority()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new()
            {
                ProcessName = "'Ew' process",
                ProcessPriority = 1
            };

            // Assert
            Assert.AreEqual(1, oldPeoplePeeCB.ProcessPriority);
        }

        [TestMethod]
        public void InlineConstructorState()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new()
            {
                ProcessName = "'Ew' process",
                ProcessPriority = 1
            };

            // Assert
            Assert.AreEqual(PCB.ProcessStateType.New, oldPeoplePeeCB.ProcessState);
        }
        
        [TestMethod]
        public void ManualConstructorName()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new();

            oldPeoplePeeCB.ProcessName = "'Ew' process";
            oldPeoplePeeCB.ProcessPriority = 1;

            // Assert
            Assert.AreEqual("'Ew' process", oldPeoplePeeCB.ProcessName);
        }

        [TestMethod]
        public void ManualConstructorPriority()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new();

            oldPeoplePeeCB.ProcessName = "'Ew' process";
            oldPeoplePeeCB.ProcessPriority = 1;

            // Assert
            Assert.AreEqual(1, oldPeoplePeeCB.ProcessPriority);
        }

        [TestMethod]
        public void ManualConstructorState()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new();

            oldPeoplePeeCB.ProcessName = "'Ew' process";
            oldPeoplePeeCB.ProcessPriority = 1;

            // Assert
            Assert.AreEqual(PCB.ProcessStateType.New, oldPeoplePeeCB.ProcessState);
        }

        [TestMethod]
        public void DefaultConstructorName()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new();

            // Assert
            Assert.AreEqual("Name not specified", oldPeoplePeeCB.ProcessName);
        }

        [TestMethod]
        public void DefaultConstructorPriority()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new();

            // Assert
            Assert.AreEqual(1, oldPeoplePeeCB.ProcessPriority);
        }

        [TestMethod]
        public void DefaultConstructorState()
        {
            // Arrange
            PCB oldPeoplePeeCB;

            // Act
            oldPeoplePeeCB = new();

            // Assert
            Assert.AreEqual(PCB.ProcessStateType.New, oldPeoplePeeCB.ProcessState);
        }

        #endregion

        #region Invalid Values
        [TestMethod]
        public void InvalidPriority()
        {
            // Act
            dummyPCB.ProcessPriority = 0;

            // Assert
            Assert.AreEqual(1, dummyPCB.ProcessPriority);
        }

        [TestMethod]
        public void InvalidConstructorPriority()
        {
            // Act
            PCB youngPeoplePeeCB = new("'Still ew' process", -10);

            // Assert
            Assert.AreEqual(1, dummyPCB.ProcessPriority);
        }

        [TestMethod]
        public void InvalidConstructorNameEmpty()
        {
            // Act
            PCB youngPeoplePeeCB = new("", 1);

            // Assert
            Assert.AreEqual("Name not specified", youngPeoplePeeCB.ProcessName);
        }

        [TestMethod]
        public void InvalidConstructorNameNull()
        {
            // Act
            PCB youngPeoplePeeCB = new(null, 1);

            // Assert
            Assert.AreEqual("Name not specified", youngPeoplePeeCB.ProcessName);
        }
        #endregion

        #region Methods
        [TestMethod]
        public void ToStringOfPCB()
        {
            // Act
            string dummyPCBstring = dummyPCB.ToString();

            // Assert
            Assert.AreEqual("Dummy process(1)", dummyPCBstring);
        }
        #endregion
    }
}