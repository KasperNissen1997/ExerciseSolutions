using ExerciseProject.Exercise14;

namespace SimpleBankTest
{
    [TestClass]
    public class UnitTester
    {
        [TestMethod]
        public void DepositToBankAccount () {
            // #### ARRANGE ####
            BankAccount BobsAccount = new BankAccount("Bob", 5000);

            // #### ACT ####
            BobsAccount.Deposit(5000);

            // #### ASSERT ####
            Assert.AreEqual(10000, BobsAccount.Balance);
        }
        [TestMethod]
        public void DepositDecimalToBankAccount () {
            // #### ARRANGE ####
            BankAccount BobsAccount = new BankAccount("Bob", 5000);

            // #### ACT ####
            BobsAccount.Deposit(24.57);

            // #### ASSERT ####
            Assert.AreEqual(5024.57, BobsAccount.Balance);
        }

        [TestMethod]
        public void DepositToLockedBankAccount () {
            // #### ARRANGE ####
            BankAccount BobsAccount = new BankAccount("Bob", 5000);

            // #### ACT ####
            BobsAccount.ChangeLockState();
            BobsAccount.Deposit(5000);

            // #### ASSERT ####
            Assert.AreEqual(5000, BobsAccount.Balance);
        }

        [TestMethod]
        public void WithdrawFromBankAccount () {
            // #### ARRANGE ####
            BankAccount BobsAccount = new BankAccount("Bob", 5000);

            // #### ACT ####
            BobsAccount.Withdraw(5000);

            // #### ASSERT ####
            Assert.AreEqual(0, BobsAccount.Balance);
        }

        [TestMethod]
        public void WithdrawDecimalFromBankAccount () {
            // #### ARRANGE ####
            BankAccount BobsAccount = new BankAccount("Bob", 5000);

            // #### ACT ####
            BobsAccount.Withdraw(24.57);

            // #### ASSERT ####
            Assert.AreEqual(4975.43, BobsAccount.Balance);
        }
        [TestMethod]
        public void WithdrawFromLockedBankAccount () {
            // #### ARRANGE ####
            BankAccount BobsAccount = new BankAccount("Bob", 5000);

            // #### ACT ####
            BobsAccount.ChangeLockState();
            BobsAccount.Withdraw(5000);

            // #### ASSERT ####
            Assert.AreEqual(5000, BobsAccount.Balance);
        }

        [TestMethod]
        public void WithdrawTooMuchFromBankAccount () {
            // #### ARRANGE ####
            BankAccount BobsAccount = new BankAccount("Bob", 5000);

            // #### ACT ####
            BobsAccount.Withdraw(10000);

            // #### ASSERT ####
            Assert.AreEqual(5000, BobsAccount.Balance);
        }

        [TestMethod]
        public void ConstructorAndChangeLockStateBankAccount () {
            // #### ARRANGE ####
            BankAccount BobsAccount = new BankAccount("Bob", 5000, true);

            // #### ACT ####
            BobsAccount.ChangeLockState();
            BobsAccount.Deposit(42);

            // #### ASSERT ####

            Assert.AreEqual(5042, BobsAccount.Balance);
        }

        [TestMethod]
        public void OverrideToStringBankAccount () {
            // #### ARRANGE ####
            BankAccount BobsAccount = new BankAccount(5000);
            BobsAccount.Name = "Bob";

            // #### ACT ####
            BobsAccount.ChangeLockState();
            BobsAccount.Deposit(100);
            BobsAccount.ChangeLockState();
            BobsAccount.Deposit(42);

            // #### ASSERT ####
            Assert.AreEqual("Name: Bob, Balance: 5042", BobsAccount.ToString());
        }

        [TestMethod]
        public void OverrideToStringNoNameBankAccount () {
            // #### ARRANGE ####
            BankAccount NobodysAccount = new BankAccount(5000);

            // #### ACT ####
            NobodysAccount.Deposit(100);
            NobodysAccount.ChangeLockState();
            NobodysAccount.Deposit(42);

            // #### ASSERT ####
            Assert.AreEqual("Name: , Balance: 5100", NobodysAccount.ToString());
        }

        [TestMethod]
        public void TestArraySort1 () {
            // #### ARRANGE ####
            IntArrayHelper arrayHelper = new IntArrayHelper();
            int[] thisIntArray = { 3, 2, 4, 1 };

            // #### ACT ####
            arrayHelper.Sort(thisIntArray);

            // #### ASSERT ####
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4 }, thisIntArray);
        }
        [TestMethod]
        public void TestArraySort2 () {
            // #### ARRANGE ####
            IntArrayHelper arrayHelper = new IntArrayHelper();
            int[] thisIntArray = { 3, 2, 4, 1, 17, 3 };

            // #### ACT ####
            arrayHelper.Sort(thisIntArray);

            // #### ASSERT ####
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 3, 4, 17 }, thisIntArray);
        }
        [TestMethod]
        public void TestArraySort3 () {
            // #### ARRANGE ####
            IntArrayHelper arrayHelper = new IntArrayHelper();
            int[] thisIntArray = { 5, 2, 1, 5, 3, 4, 3 };

            // #### ACT ####
            arrayHelper.Sort(thisIntArray);

            // #### ASSERT ####
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 3, 4, 5, 5 }, thisIntArray);
        }
        [TestMethod]
        public void TestArraySort4 () {
            // #### ARRANGE ####
            IntArrayHelper arrayHelper = new IntArrayHelper();
            int[] thisIntArray = { 1, 1, 3, 1, 2, 1, 3, 3, 3, 3, 1, 3, 4, 5, 4, 3, 7, 5, 4, 9, 1, 2 };

            // #### ACT ####
            arrayHelper.Sort(thisIntArray);

            // #### ASSERT ####
            CollectionAssert.AreEqual(new int[] { 1, 1, 1, 1, 1, 1, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 5, 5, 7, 9 }, thisIntArray);
        }

        [TestMethod]
        public void TestArrayReverse1 () {
            // #### ARRANGE ####
            IntArrayHelper arrayHelper = new IntArrayHelper();
            int[] thisIntArray = { 3, 2, 4, 1 };

            // #### ACT ####
            arrayHelper.Reverse(thisIntArray);

            // #### ASSERT ####
            CollectionAssert.AreEqual(new int[] { 4, 3, 2, 1 }, thisIntArray);
        }
        [TestMethod]
        public void TestArrayReverse2 () {
            // #### ARRANGE ####
            IntArrayHelper arrayHelper = new IntArrayHelper();
            int[] thisIntArray = { 3, 2, 4, 1, 17, 3 };

            // #### ACT ####
            arrayHelper.Reverse(thisIntArray);

            // #### ASSERT ####
            CollectionAssert.AreEqual(new int[] { 17, 4, 3, 3, 2, 1 }, thisIntArray);
        }
        [TestMethod]
        public void TestArrayReverse3 () {
            // #### ARRANGE ####
            IntArrayHelper arrayHelper = new IntArrayHelper();
            int[] thisIntArray = { 5, 2, 1, 5, 3, 4, 3 };

            // #### ACT ####
            arrayHelper.Reverse(thisIntArray);

            // #### ASSERT ####
            CollectionAssert.AreEqual(new int[] { 5, 5, 4, 3, 3, 2, 1 }, thisIntArray);
        }
        [TestMethod]
        public void TestArrayReverse4 () {
            // #### ARRANGE ####
            IntArrayHelper arrayHelper = new IntArrayHelper();
            int[] thisIntArray = { 11, 1, 3, 1, 2, 1, 3, 3, 3, 3, 1, 3, 4, 5, 4, 3, 7, 5, 4, 9, 1, 2 };

            // #### ACT ####
            arrayHelper.Reverse(thisIntArray);

            // #### ASSERT ####
            CollectionAssert.AreEqual(new int[] { 11, 9, 7, 5, 5, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 2, 2, 1, 1, 1, 1, 1 }, thisIntArray);
        }

    }
}