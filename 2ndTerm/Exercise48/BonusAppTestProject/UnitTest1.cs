using BonusApp;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BonusAppTestProject
{
    [TestClass]
    public class UnitTest1
    {
        delegate int DocsTest1(int x, int y);
        delegate int DocsTest2(int x);

        Order order;

        [TestInitialize]
        public void InitializeTest()
        {
            order = new Order();
            order.AddProduct(new Product
            {
                Name = "Mælk",
                Value = 10.0
            });
            order.AddProduct(new Product
            {
                Name = "Smør",
                Value = 15.0
            });
            order.AddProduct(new Product
            {
                Name = "Pålæg",
                Value = 20.0
            });
        }

        [TestMethod]
        public void TenPercent_Test()
        {
            Assert.AreEqual(4.5, Bonuses.TenPercent(45.0));
            Assert.AreEqual(40.0, Bonuses.TenPercent(400.0));
        }

        [TestMethod]
        public void FlatTwoIfAMountMoreThanFive_Test()
        {
            Assert.AreEqual(2.0, Bonuses.FlatTwoIfAmountMoreThanFive(10.0));
            Assert.AreEqual(0.0, Bonuses.FlatTwoIfAmountMoreThanFive(4.0));
        }

        [TestMethod]
        public void GetValueOfProducts_Test()
        {
            Assert.AreEqual(45.0, order.GetValueOfProducts());
        }

        [TestMethod]
        public void GetBonus_Test()
        {
            order.Bonus = Bonuses.TenPercent;
            Assert.AreEqual(4.5, order.GetBonus());
            

            order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(2.0, order.GetBonus());
        }

        [TestMethod]
        public void GetTotalPrice_Test()
        {
            order.Bonus = Bonuses.TenPercent;
            Assert.AreEqual(40.5, order.GetTotalPrice());

            order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive;
            Assert.AreEqual(43.0, order.GetTotalPrice());
        }

        [TestMethod]
        public void GetBonusAnonymous_Test()
        {
            // order.Bonus = Bonuses.TenPercent; // <- Change to anonymous method
            order.Bonus = delegate (double amount) { return amount * 0.1; };
            Assert.AreEqual(4.5, order.GetBonus());

            // order.Bonus = Bonuses.FlatTwoIfAmountMoreThanFive; // <- Change to anonymous method
            order.Bonus = delegate (double amount) { return amount > 5.0 ? 2.0 : 0.0; };
            Assert.AreEqual(2.0, order.GetBonus());
        }

        [TestMethod]
        public void Docs_Test1()
        {
            int x = 3, y = 2;

            DocsTest1 docsTest1 = (x, y) => x + y;

            Assert.AreEqual(5, docsTest1(x, y));
        }

        [TestMethod]
        public void Docs_Test2()
        {
            int x = 10;

            DocsTest2 docsTest2 = x => x * 9;

            Assert.AreEqual(90, docsTest2(x));
        }

        [TestMethod]
        public void Docs_Test3()
        {
            int x = 5;

            // First test
            DocsTest2 docsTest2 = x => (int) MathF.Pow(x, 2);

            Assert.AreEqual(25, docsTest2(x));

            // Second test
            docsTest2 = x => x * x;

            Assert.AreEqual(25, docsTest2(x));
        }

        [TestMethod]
        public void GetBonusLambda_Test()
        {
            order.Bonus = amount => amount * 0.1; // <- Change to lambda expression
            Assert.AreEqual(4.5, order.GetBonus());

            order.Bonus = amount => amount > 5.0 ? 2.0 : 0.0; // <- Change to lambda expression
            Assert.AreEqual(2.0, order.GetBonus());
        }

        [TestMethod]
        public void GetBonusByLambdaParameter_Test()
        {
            // Use TenPercent lambda expresssion as parameter to GetBonus
            Assert.AreEqual(4.5, order.GetBonus(amount => amount * 0.1));

            // Use FlatTwoIfAmountMoreThanFive lambda expresssion as parameter to GetBonus
            Assert.AreEqual(2.0, order.GetBonus(amount => amount > 5 ? 2 : 0));
        }

        [TestMethod]
        public void GetTotalPriceByLambdaParameter_Test()
        {
            Assert.AreEqual(40.5, order.GetTotalPrice(amount => amount * 0.1));

            Assert.AreEqual(43.0, order.GetTotalPrice(amount => amount > 5 ? 2 : 0));
        }
    }
}