using HardwaveStockManagement.DataManagement;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;

namespace HardwaveStockManagement.Tests.Repositories
{
    public class CaseRepositoryTests
    {
        private readonly CaseRepository _caseRepository;

        public CaseRepositoryTests() 
        { 
            ItemContext context = new();
            _caseRepository = new(context);
        }

        private Case item;

        [SetUp]
        public void Setup()
        {
            item = new(Guid.NewGuid(), "test case", "case", 11, 22.22, "test case description", "test form factor");
        }

        [Test]
        public void GetIndividualCaseUsingCaseRepository()
        {
            _caseRepository.AddItem(item);

            var check = _caseRepository.GetItem(item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.FormFactor, Is.EqualTo(item.FormFactor));
            });
            _caseRepository.DeleteItem(item.ID);
        }

        [Test]
        public void GetAllCasesUsingCaseRepository()
        {
            List<Case> check = _caseRepository.GetAllItems();
            for (int i = 0; i < check.Count; i++)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(check[i].Name, Is.EqualTo(_caseRepository.GetAllItems()[i].Name));
                    Assert.That(check[i].Stock, Is.EqualTo(_caseRepository.GetAllItems()[i].Stock));
                    Assert.That(check[i].Price, Is.EqualTo(_caseRepository.GetAllItems()[i].Price));
                    Assert.That(check[i].Description, Is.EqualTo(_caseRepository.GetAllItems()[i].Description));
                    Assert.That(check[i].FormFactor, Is.EqualTo(_caseRepository.GetAllItems()[i].FormFactor));
                });
            }
        }

        [Test]
        public void AddCaseUsingCaseRepository()
        {
            var check = _caseRepository.AddItem(item);

            Assert.Multiple(() =>
            {
                Assert.That(check.Name, Is.EqualTo(item.Name));
                Assert.That(check.Stock, Is.EqualTo(item.Stock));
                Assert.That(check.Price, Is.EqualTo(item.Price));
                Assert.That(check.Description, Is.EqualTo(item.Description));
                Assert.That(check.FormFactor, Is.EqualTo(item.FormFactor));
            });
            _caseRepository.DeleteItem(item.ID);
        }

        [TestCase("test name", 50, 100, "test case description", "test form factor")]
        [TestCase("TEST NAME", 0, 50.5, "TEST CASE DESCRIPTION", "TEST FORM FACTOR")]
        [TestCase("Test Name123", 10000, 999.99, "Test Case Description123", "Test Form Factor123")]
        [TestCase("test name!&*^%4", 1, 0, "test case description!&*^%4", "test form factor!&*^%4")]
        public void EditCaseUsingCaseRepository(string testName, int testStock, double testPrice, string testDescription, string testFormFactor)
        {
            Case ExampleItem = new(item.ID, testName, item.Type, testStock, testPrice, testDescription, testFormFactor);
            _caseRepository.AddItem(item);

            var check = _caseRepository.EditItem(ExampleItem, item.ID);

            Assert.Multiple(() =>
            {
                Assert.That(check, Is.Not.EqualTo(null));
                Assert.That(check!.Name, Is.EqualTo(testName));
                Assert.That(check.Stock, Is.EqualTo(testStock));
                Assert.That(check.Price, Is.EqualTo(testPrice));
                Assert.That(check.Description, Is.EqualTo(testDescription));
                Assert.That(check.FormFactor, Is.EqualTo(testFormFactor));
            });
            _caseRepository.DeleteItem(item.ID);
        }

        [Test]
        public void DeleteCaseUsingCaseRepository()
        {
            _caseRepository.AddItem(item);

            bool check = _caseRepository.DeleteItem(item.ID);

            Assert.That(check, Is.EqualTo(true));
        }
    }
}
