using ModelPersistence.Models;
using ModelPersistence.Persistence;

namespace LærerVikarUnitTest
{
    [TestClass]
    public class SchoolRepositoryTester
    {
        private SchoolRepository repo;

        private School hogwarts, uagadou;

        [TestInitialize]
        public void InitializeRepository()
        {
            // Arrange
            repo = new();

            hogwarts = repo.Create(12345678, "Hogwarts School of Witchcraft and Wizardry", "Hogwarts Castle, Highlands, Scotland, Great Britain");
            uagadou = repo.Create(23456789, "Ugandan school of magic", "Mountains of the Moon, Uganda, East Africa");
        }

        [TestCleanup]
        public void CleanupRepository()
        {
            repo.Delete(hogwarts);
            repo.Delete(uagadou);
        }

        [TestMethod]
        public void TestCreate()
        {
            // Act
            School beauxbaton = repo.Create(34567890, "Beauxbatons Academy of Magic", "French Pyrenees, France");
            repo.Delete(beauxbaton);

            // Assert
            Assert.IsNotNull(beauxbaton);
        }

        [TestMethod]
        public void TestRetrieveHogwarts() 
        {
            // Act
            School retrievedHogwarts = repo.Retrieve(hogwarts.Phone);

            // Assert
            Assert.AreEqual(hogwarts, retrievedHogwarts);
        }

        [TestMethod]
        public void TestRetrieveUagadou()
        {
            // Act
            School retrievedUagadou = repo.Retrieve(uagadou.Phone);

            // Assert
            Assert.AreEqual(uagadou, retrievedUagadou);
        }

        [TestMethod]
        public void TestRetrieveAll()
        {
            // Arrange
            List<School> schools = new()
            {
                hogwarts,
                uagadou
            };

            // Act
            List<School> retrievedSchools = repo.RetrieveAll();

            // Assert
            Assert.AreEqual(schools.Count, retrievedSchools.Count);
        }

        [TestMethod]
        public void TestUpdate()
        {
            // Act
            hogwarts.Name = "Hogpimples";

            repo.Update(hogwarts);

            School retrievedHogpimples = repo.Retrieve(hogwarts.Phone);

            // Assert
            Assert.AreEqual(hogwarts.Name, retrievedHogpimples.Name);
        }

        [TestMethod]
        public void TestDelete()
        {
            // Act
            repo.Delete(hogwarts);

            List<School> retrievedSchools = repo.RetrieveAll();

            // Assert
            Assert.IsTrue(retrievedSchools.Count == 1, "Found more/less than a single school.");
        }
    }
}