using Scheduling_2;

namespace SchedulingTestProject_2
{
    [TestClass]
    public class PriorityQueueTester
    {
        public PriorityQueue pq;

        [TestInitialize]
        public void InitializeTest()
        {
            pq = new PriorityQueue();
        }

        [TestMethod]
        public void TestPCBToString()
        {
            // Arrange
            PCB pcb = new PCB { ProcessName = "A", ProcessPriority = 2 };

            // Act

            // Assert
            Assert.AreEqual("A(2)", pcb.ToString());
        }

        [TestMethod]
        public void TestEmptyQueue()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual("{}", pq.ToString());
        }

        [TestMethod]
        public void TestEnqueueAndToString()
        {
            // Arrange
            PCB pcb = new PCB { ProcessName = "A", ProcessPriority = 2 };

            // Act
            pq.Enqueue(pcb);

            // Assert
            Assert.AreEqual("{A(2)}", pq.ToString());
        }

        [TestMethod]
        public void Test3EnqueuesAndToString()
        {
            // Arrange
            PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 2 };
            PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 2 };
            PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 2 };

            // Act
            pq.Enqueue(pcbA);
            pq.Enqueue(pcbB);
            pq.Enqueue(pcbC);

            // Assert
            Assert.AreEqual("{A(2),B(2),C(2)}", pq.ToString());
        }

        [TestMethod]
        public void Test3EnqueuesAndPriority()
        {
            // Arrange
            PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 2 };
            PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 3 };
            PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 1 };

            // Act
            pq.Enqueue(pcbA);
            pq.Enqueue(pcbB);
            pq.Enqueue(pcbC);

            // Assert
            Assert.AreEqual("{C(1),A(2),B(3)}", pq.ToString());
        }

        [TestMethod]
        public void TestEnqueueDequeue()
        {
            // Arrange
            PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 2 };
            PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 2 };
            PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 3 };
            PCB pcbD = new PCB { ProcessName = "D", ProcessPriority = 3 };
            PCB pcbE = new PCB { ProcessName = "E", ProcessPriority = 1 };

            // Act
            pq.Enqueue(pcbA);
            pq.Enqueue(pcbB);
            pq.Enqueue(pcbC);
            pq.Enqueue(pcbD);
            pq.Enqueue(pcbE);
            pq.Dequeue();
            pq.Dequeue();

            // Assert
            Assert.AreEqual("{B(2),C(3),D(3)}", pq.ToString());
        }

        [TestMethod]
        public void TestEnqueueDequeueReprioritize()
        {
            // Arrange
            PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 2 };
            PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 2 };
            PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 3 };
            PCB pcbD = new PCB { ProcessName = "D", ProcessPriority = 3 };
            PCB pcbE = new PCB { ProcessName = "E", ProcessPriority = 1 };

            // Act
            pq.Enqueue(pcbA);
            pq.Enqueue(pcbB);
            pq.Enqueue(pcbC);
            pq.Enqueue(pcbD);
            pq.Enqueue(pcbE);
            pq.Dequeue();
            pq.Dequeue();
            pq.Reprioritize("D", 2);

            // Assert
            Assert.AreEqual("{B(2),D(2),C(3)}", pq.ToString());
        }

        [TestMethod]
        public void TestEnqueueDequeueReprioritize2()
        {
            // Arrange
            PCB pcbA = new PCB { ProcessName = "A", ProcessPriority = 4 };
            PCB pcbB = new PCB { ProcessName = "B", ProcessPriority = 1 };
            PCB pcbC = new PCB { ProcessName = "C", ProcessPriority = 3 };
            PCB pcbD = new PCB { ProcessName = "D", ProcessPriority = 3 };
            PCB pcbE = new PCB { ProcessName = "E", ProcessPriority = 1 };

            // Act
            pq.Enqueue(pcbA);
            pq.Enqueue(pcbB);
            pq.Dequeue();
            pq.Enqueue(pcbC);
            pq.Reprioritize("A", 2);
            pq.Enqueue(pcbD);
            pq.Dequeue();
            pq.Enqueue(pcbE);

            // Assert
            Assert.AreEqual("{E(1),C(3),D(3)}", pq.ToString());
        }
    }
}
