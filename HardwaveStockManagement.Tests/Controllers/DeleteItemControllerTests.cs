using HardwaveStockManagement.Controllers;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HardwaveStockManagement.Tests.Controllers
{
    public class DeleteItemControllerTests : IDisposable
    {
        private readonly Case testCase = new(Guid.NewGuid(), "test case", "case", 11, 22.22, "test case description", "test form factor");
        private readonly CPU testCpu = new(Guid.NewGuid(), "test cpu", "cpu", 11, 22.22, "test cpu description", 33, 44, "test socket");
        private readonly Laptop testLaptop = new(Guid.NewGuid(), "test laptop", "laptop", 11, 22.22, "test laptop description", 33.33, 44, 55);
        private readonly GraphicsCard testGraphicsCard = new(Guid.NewGuid(), "test graphics card", "graphics card", 11, 22.22, "test graphics card description", 33, 44);
        private readonly Memory testMemory = new(Guid.NewGuid(), "test memory", "memory", 11, 22.22, "test memory description", "test memory type", 44, 55);
        private readonly Models.Monitor testMonitor = new(Guid.NewGuid(), "test monitor", "monitor", 11, 22.22, "test monitor description", 44.44, 55);
        private readonly Motherboard testMotherboard = new(Guid.NewGuid(), "test motherboard", "motherboard", 11, 22.22, "test motherboard description", "test socket", "test form factor");
        private readonly Storage testStorage = new(Guid.NewGuid(), "test storage", "storage", 11, 22.22, "test storage description", "test storage type", 33);

        private Mock<IItemsRepository<Case>> mockCaseRepository;
        private Mock<IItemsRepository<CPU>> mockCPURepository;
        private Mock<IItemsRepository<Laptop>> mockLaptopRepository;
        private Mock<IItemsRepository<GraphicsCard>> mockGraphicsCardRepository;
        private Mock<IItemsRepository<Memory>> mockMemoryRepository;
        private Mock<IItemsRepository<Models.Monitor>> mockMonitorRepository;
        private Mock<IItemsRepository<Motherboard>> mockMotherboardRepository;
        private Mock<IItemsRepository<Storage>> mockStorageRepository;
        private DeleteItemController deleteItemController;

        [SetUp]
        public void SetUp()
        {
            mockCaseRepository = new Mock<IItemsRepository<Case>>();
            mockCPURepository = new Mock<IItemsRepository<CPU>>();
            mockLaptopRepository = new Mock<IItemsRepository<Laptop>>();
            mockGraphicsCardRepository = new Mock<IItemsRepository<GraphicsCard>>();
            mockMemoryRepository = new Mock<IItemsRepository<Memory>>();
            mockMonitorRepository = new Mock<IItemsRepository<Models.Monitor>>();
            mockMotherboardRepository = new Mock<IItemsRepository<Motherboard>>();
            mockStorageRepository = new Mock<IItemsRepository<Storage>>();
            deleteItemController = new DeleteItemController(mockCaseRepository.Object, mockCPURepository.Object, 
                mockGraphicsCardRepository.Object,mockLaptopRepository.Object, mockMemoryRepository.Object, 
                mockMonitorRepository.Object, mockMotherboardRepository.Object, mockStorageRepository.Object);
        }

        public void Dispose()
        {
            deleteItemController.Dispose();
        }

        [Test]
        public void RedirectToDeleteItemConfirmationWithCase()
        {
            mockCaseRepository.Setup(x => x.GetItem(testCase.ID)).Returns(testCase);

            var caseDeleteConfirmation = (ViewResult)deleteItemController.DeleteItemView(testCase.ID);

            Assert.That(caseDeleteConfirmation.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void RedirectToDeleteItemConfirmationWithCPU()
        {
            mockCPURepository.Setup(x => x.GetItem(testCpu.ID)).Returns(testCpu);

            var cpuDeleteConfirmation = (ViewResult)deleteItemController.DeleteItemView(testCpu.ID);

            Assert.That(cpuDeleteConfirmation.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void RedirectToDeleteItemConfirmationWithLaptop()
        {
            mockLaptopRepository.Setup(x => x.GetItem(testLaptop.ID)).Returns(testLaptop);

            var laptopDeleteConfirmation = (ViewResult)deleteItemController.DeleteItemView(testLaptop.ID);

            Assert.That(laptopDeleteConfirmation.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void RedirectToDeleteItemConfirmationWithGraphicsCard()
        {
            mockGraphicsCardRepository.Setup(x => x.GetItem(testGraphicsCard.ID)).Returns(testGraphicsCard);

            var graphicsCardDeleteConfirmation = (ViewResult)deleteItemController.DeleteItemView(testGraphicsCard.ID);

            Assert.That(graphicsCardDeleteConfirmation.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void RedirectToDeleteItemConfirmationWithMemory()
        {
            mockMemoryRepository.Setup(x => x.GetItem(testMemory.ID)).Returns(testMemory);

            var memoryDeleteConfirmation = (ViewResult)deleteItemController.DeleteItemView(testMemory.ID);

            Assert.That(memoryDeleteConfirmation.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void RedirectToDeleteItemConfirmationWithMonitor()
        {
            mockMonitorRepository.Setup(x => x.GetItem(testMonitor.ID)).Returns(testMonitor);

            var monitorDeleteConfirmation = (ViewResult)deleteItemController.DeleteItemView(testMonitor.ID);

            Assert.That(monitorDeleteConfirmation.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void RedirectToDeleteItemConfirmationWithMotherboard()
        {
            mockMotherboardRepository.Setup(x => x.GetItem(testMotherboard.ID)).Returns(testMotherboard);

            var motherboardDeleteConfirmation = (ViewResult)deleteItemController.DeleteItemView(testMotherboard.ID);

            Assert.That(motherboardDeleteConfirmation.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void RedirectToDeleteItemConfirmationWithStorage()
        {
            mockStorageRepository.Setup(x => x.GetItem(testStorage.ID)).Returns(testStorage);

            var storageDeleteConfirmation = (ViewResult)deleteItemController.DeleteItemView(testStorage.ID);

            Assert.That(storageDeleteConfirmation.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void DeleteItemsUsingDeleteItemController()
        {
            mockCaseRepository.Setup(x => x.DeleteItem(testCase.ID)).Returns(true);
            mockCaseRepository.Setup(x => x.GetItem(testCase.ID)).Returns(testCase);
            mockCPURepository.Setup(x => x.DeleteItem(testCpu.ID)).Returns(true);
            mockCPURepository.Setup(x => x.GetItem(testCpu.ID)).Returns(testCpu);
            mockGraphicsCardRepository.Setup(x => x.DeleteItem(testGraphicsCard.ID)).Returns(true);
            mockGraphicsCardRepository.Setup(x => x.GetItem(testGraphicsCard.ID)).Returns(testGraphicsCard);
            mockLaptopRepository.Setup(x => x.DeleteItem(testLaptop.ID)).Returns(true);
            mockLaptopRepository.Setup(x => x.GetItem(testLaptop.ID)).Returns(testLaptop);
            mockMemoryRepository.Setup(x => x.DeleteItem(testMemory.ID)).Returns(true);
            mockMemoryRepository.Setup(x => x.GetItem(testMemory.ID)).Returns(testMemory);
            mockMonitorRepository.Setup(x => x.DeleteItem(testMonitor.ID)).Returns(true);
            mockMonitorRepository.Setup(x => x.GetItem(testMonitor.ID)).Returns(testMonitor);
            mockMotherboardRepository.Setup(x => x.DeleteItem(testMotherboard.ID)).Returns(true);
            mockMotherboardRepository.Setup(x => x.GetItem(testMotherboard.ID)).Returns(testMotherboard);
            mockStorageRepository.Setup(x => x.DeleteItem(testStorage.ID)).Returns(true);
            mockStorageRepository.Setup(x => x.GetItem(testStorage.ID)).Returns(testStorage);

            var deletedCase = (RedirectToActionResult)deleteItemController.DeleteItem(testCase.ID);
            var deletedCpu = (RedirectToActionResult)deleteItemController.DeleteItem(testCpu.ID);
            var deletedGraphicsCard = (RedirectToActionResult)deleteItemController.DeleteItem(testGraphicsCard.ID);
            var deletedLaptop = (RedirectToActionResult)deleteItemController.DeleteItem(testLaptop.ID);
            var deletedMemory = (RedirectToActionResult)deleteItemController.DeleteItem(testMemory.ID);
            var deletedMonitor = (RedirectToActionResult)deleteItemController.DeleteItem(testMonitor.ID);
            var deletedMotherboard = (RedirectToActionResult)deleteItemController.DeleteItem(testMotherboard.ID);
            var deletedStorage = (RedirectToActionResult)deleteItemController.DeleteItem(testStorage.ID);

            Assert.Multiple(() =>
            {
                Assert.That(deletedCase.ActionName, Is.EqualTo("Index"));
                Assert.That(deletedCase.ControllerName, Is.EqualTo("Home"));
                Assert.That(deletedCpu.ActionName, Is.EqualTo("Index"));
                Assert.That(deletedCpu.ControllerName, Is.EqualTo("Home"));
                Assert.That(deletedGraphicsCard.ActionName, Is.EqualTo("Index"));
                Assert.That(deletedGraphicsCard.ControllerName, Is.EqualTo("Home"));
                Assert.That(deletedLaptop.ActionName, Is.EqualTo("Index"));
                Assert.That(deletedLaptop.ControllerName, Is.EqualTo("Home"));
                Assert.That(deletedMemory.ActionName, Is.EqualTo("Index"));
                Assert.That(deletedMemory.ControllerName, Is.EqualTo("Home"));
                Assert.That(deletedMonitor.ActionName, Is.EqualTo("Index"));
                Assert.That(deletedMonitor.ControllerName, Is.EqualTo("Home"));
                Assert.That(deletedMotherboard.ActionName, Is.EqualTo("Index"));
                Assert.That(deletedMotherboard.ControllerName, Is.EqualTo("Home"));
                Assert.That(deletedStorage.ActionName, Is.EqualTo("Index"));
                Assert.That(deletedStorage.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }
    }
}
