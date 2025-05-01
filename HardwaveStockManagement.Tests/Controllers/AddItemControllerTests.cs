using HardwaveStockManagement.Controllers;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using HardwaveStockManagement.GenerateID;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace HardwaveStockManagement.Tests.Controllers
{
    public class AddItemControllerTests : IDisposable
    {
        private readonly Case testCase = new(Guid.NewGuid(), "test case", "case", 11, 22.22, "test case description", "test form factor");
        private readonly CPU testCpu = new(Guid.NewGuid(), "test cpu", "cpu", 11, 22.22, "test cpu description", 33, 44, "test socket");
        private readonly Laptop testLaptop = new(Guid.NewGuid(), "test laptop", "laptop", 11, 22.22, "test laptop description", 33.33, 44, 55);
        private readonly GraphicsCard testGraphicsCard = new(Guid.NewGuid(), "test graphics card", "graphics card", 11, 22.22, "test graphics card description", 33, 44);
        private readonly Memory testMemory = new(Guid.NewGuid(), "test memory", "memory", 11, 22.22, "test memory description", "test memory type", 44, 55);
        private readonly Models.Monitor testMonitor = new (Guid.NewGuid(), "test monitor", "monitor", 11, 22.22, "test monitor description", 44.44, 55);
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
        private Mock<IGenerateItemID> mockGenerateItemID;
        private AddItemController addItemController;

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
            mockGenerateItemID = new Mock<IGenerateItemID>();
            addItemController = new AddItemController(mockCaseRepository.Object, mockCPURepository.Object, mockGraphicsCardRepository.Object,
                mockLaptopRepository.Object, mockMemoryRepository.Object, mockMonitorRepository.Object, mockMotherboardRepository.Object,
                mockStorageRepository.Object, mockGenerateItemID.Object);
        }

        public void Dispose()
        {
            addItemController.Dispose();
        }

        [Test]
        public void RedirectToAddItemForm()
        {
            mockGenerateItemID.Setup(x => x.GenerateID()).Returns(Guid.NewGuid());

            var addItemForm = (ViewResult)addItemController.AddItemView();

            Assert.That(addItemForm.ViewName, Is.Null);
            Mock.VerifyAll();
        }

        [Test]
        public void AddCaseUsingAddItemController()
        {
            mockCaseRepository.Setup(x => x.AddItem(It.IsAny<Case>())).Returns(testCase);

            var addedCase = (RedirectToActionResult)addItemController.AddCase(testCase.ID, testCase.Name, testCase.Type, testCase.Stock,
                testCase.Price, testCase.Description, testCase.FormFactor);

            Assert.Multiple(() =>
            {
                Assert.That(addedCase.ActionName, Is.EqualTo("Index"));
                Assert.That(addedCase.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }

        [Test]
        public void AddCPUUsingAddItemController()
        {
            mockCPURepository.Setup(x => x.AddItem(It.IsAny<CPU>())).Returns(testCpu);

            var addedCpu = (RedirectToActionResult)addItemController.AddCPU(testCpu.ID, testCpu.Name, testCpu.Type, testCpu.Stock,
                testCpu.Price, testCpu.Description, testCpu.Cores, testCpu.ClockSpeed, testCpu.Socket);

            Assert.Multiple(() =>
            {
                Assert.That(addedCpu.ActionName, Is.EqualTo("Index"));
                Assert.That(addedCpu.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }

        [Test]
        public void AddGraphicsCardUsingAddItemController()
        {
            mockGraphicsCardRepository.Setup(x => x.AddItem(It.IsAny<GraphicsCard>())).Returns(testGraphicsCard);

            var addedGraphicsCard = (RedirectToActionResult)addItemController.AddGraphicsCard(testGraphicsCard.ID, testGraphicsCard.Name, testGraphicsCard.Type,
                testGraphicsCard.Stock, testGraphicsCard.Price, testGraphicsCard.Description, testGraphicsCard.VRAM, testGraphicsCard.CudaCores);

            Assert.Multiple(() =>
            {
                Assert.That(addedGraphicsCard.ActionName, Is.EqualTo("Index"));
                Assert.That(addedGraphicsCard.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }

        [Test]
        public void AddLaptopUsingAddItemController()
        {
            mockLaptopRepository.Setup(x => x.AddItem(It.IsAny<Laptop>())).Returns(testLaptop);

            var addedLaptop = (RedirectToActionResult)addItemController.AddLaptop(testLaptop.ID, testLaptop.Name, testLaptop.Type, testLaptop.Stock,
                testLaptop.Price, testLaptop.Description, testLaptop.ScreenSize, testLaptop.RAM, testLaptop.Storage);

            Assert.Multiple(() =>
            {
                Assert.That(addedLaptop.ActionName, Is.EqualTo("Index"));
                Assert.That(addedLaptop.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }

        [Test]
        public void AddMemoryUsingAddItemController()
        {
            mockMemoryRepository.Setup(x => x.AddItem(It.IsAny<Memory>())).Returns(testMemory);

            var addedMemory = (RedirectToActionResult)addItemController.AddMemory(testMemory.ID, testMemory.Name, testMemory.Type, testMemory.Stock,
                testMemory.Price, testMemory.Description, testMemory.MemoryType, testMemory.MemorySize, testMemory.MemorySpeed);

            Assert.Multiple(() =>
            {
                Assert.That(addedMemory.ActionName, Is.EqualTo("Index"));
                Assert.That(addedMemory.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }

        [Test]
        public void AddMonitorUsingAddItemController()
        {
            mockMonitorRepository.Setup(x => x.AddItem(It.IsAny<Models.Monitor>())).Returns(testMonitor);

            var addedMonitor = (RedirectToActionResult)addItemController.AddMonitor(testMonitor.ID, testMonitor.Name, testMonitor.Type, testMonitor.Stock,
                testMonitor.Price, testMonitor.Description, testMonitor.ScreenSize, testMonitor.RefreshRate);

            Assert.Multiple(() =>
            {
                Assert.That(addedMonitor.ActionName, Is.EqualTo("Index"));
                Assert.That(addedMonitor.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }

        [Test]
        public void AddMotherboardUsingAddItemController()
        {
            mockMotherboardRepository.Setup(x => x.AddItem(It.IsAny<Motherboard>())).Returns(testMotherboard);

            var addedMotherboard = (RedirectToActionResult)addItemController.AddMotherboard(testMotherboard.ID, testMotherboard.Name, testMotherboard.Type, testMotherboard.Stock,
                testMotherboard.Price, testMotherboard.Description, testMotherboard.Socket, testMotherboard.FormFactor);

            Assert.Multiple(() =>
            {
                Assert.That(addedMotherboard.ActionName, Is.EqualTo("Index"));
                Assert.That(addedMotherboard.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }

        [Test]
        public void AddStorageUsingAddItemController()
        {
            mockStorageRepository.Setup(x => x.AddItem(It.IsAny<Storage>())).Returns(testStorage);

            var addedStorage = (RedirectToActionResult)addItemController.AddStorage(testStorage.ID, testStorage.Name, testStorage.Type, testStorage.Stock,
                testStorage.Price, testStorage.Description, testStorage.StorageType, testStorage.StorageSize);

            Assert.Multiple(() =>
            {
                Assert.That(addedStorage.ActionName, Is.EqualTo("Index"));
                Assert.That(addedStorage.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }
    }
}
