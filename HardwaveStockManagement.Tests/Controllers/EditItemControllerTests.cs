using HardwaveStockManagement.Controllers;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace HardwaveStockManagement.Tests.Controllers
{
    public class EditItemControllerTests : IDisposable
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
        private EditItemController editItemController;

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
            editItemController = new EditItemController(mockCaseRepository.Object, mockCPURepository.Object,
                mockGraphicsCardRepository.Object, mockLaptopRepository.Object, mockMemoryRepository.Object,
                mockMonitorRepository.Object, mockMotherboardRepository.Object, mockStorageRepository.Object);
        }

        public void Dispose()
        {
            editItemController.Dispose();
        }

        [Test]
        public void EnsureEditItemControllerRedirectsWork()
        {
            mockCaseRepository.Setup(x => x.GetItem(testCase.ID)).Returns(testCase);
            mockCPURepository.Setup(x => x.GetItem(testCpu.ID)).Returns(testCpu);
            mockGraphicsCardRepository.Setup(x => x.GetItem(testGraphicsCard.ID)).Returns(testGraphicsCard);
            mockLaptopRepository.Setup(x => x.GetItem(testLaptop.ID)).Returns(testLaptop);
            mockMemoryRepository.Setup(x => x.GetItem(testMemory.ID)).Returns(testMemory);
            mockMonitorRepository.Setup(x => x.GetItem(testMonitor.ID)).Returns(testMonitor);
            mockMotherboardRepository.Setup(x => x.GetItem(testMotherboard.ID)).Returns(testMotherboard);
            mockStorageRepository.Setup(x => x.GetItem(testStorage.ID)).Returns(testStorage);

            var editCaseForm = (ViewResult)editItemController.EditCaseView(testCase.ID);
            var editCpuForm = (ViewResult)editItemController.EditCPUView(testCpu.ID);
            var editGraphicsCardForm = (ViewResult)editItemController.EditGraphicsCardView(testGraphicsCard.ID);
            var editLaptopForm = (ViewResult)editItemController.EditLaptopView(testLaptop.ID);
            var editMemoryForm = (ViewResult)editItemController.EditMemoryView(testMemory.ID);
            var editMonitorForm = (ViewResult)editItemController.EditMonitorView(testMonitor.ID);
            var editMotherboardForm = (ViewResult)editItemController.EditMotherboardView(testMotherboard.ID);
            var editStorageForm = (ViewResult)editItemController.EditStorageView(testStorage.ID);

            Assert.Multiple(() =>
            {
                Assert.That(editCaseForm.ViewName, Is.Null);
                Assert.That(editCpuForm.ViewName, Is.Null);
                Assert.That(editGraphicsCardForm.ViewName, Is.Null);
                Assert.That(editLaptopForm.ViewName, Is.Null);
                Assert.That(editMemoryForm.ViewName, Is.Null);
                Assert.That(editMonitorForm.ViewName, Is.Null);
                Assert.That(editMotherboardForm.ViewName, Is.Null);
                Assert.That(editStorageForm.ViewName, Is.Null);
            });
            Mock.VerifyAll();
        }

        [Test]
        public void EditItemsUsingEditItemController()
        {
            mockCaseRepository.Setup(x => x.EditItem(It.IsAny<Case>(), testCase.ID)).Returns(testCase);
            mockCPURepository.Setup(x => x.EditItem(It.IsAny<CPU>(), testCpu.ID)).Returns(testCpu);
            mockGraphicsCardRepository.Setup(x => x.EditItem(It.IsAny<GraphicsCard>(), testGraphicsCard.ID)).Returns(testGraphicsCard);
            mockLaptopRepository.Setup(x => x.EditItem(It.IsAny<Laptop>(), testLaptop.ID)).Returns(testLaptop);
            mockMemoryRepository.Setup(x => x.EditItem(It.IsAny<Memory>(), testMemory.ID)).Returns(testMemory);
            mockMonitorRepository.Setup(x => x.EditItem(It.IsAny<Models.Monitor>(), testMonitor.ID)).Returns(testMonitor);
            mockMotherboardRepository.Setup(x => x.EditItem(It.IsAny<Motherboard>(), testMotherboard.ID)).Returns(testMotherboard);
            mockStorageRepository.Setup(x => x.EditItem(It.IsAny<Storage>(), testStorage.ID)).Returns(testStorage);

            var editedCase = (RedirectToActionResult)editItemController.EditCase(testCase.ID, testCase.Name, testCase.Type,
                testCase.Stock, testCase.Price, testCase.Description, testCase.FormFactor);
            var editedCpu = (RedirectToActionResult)editItemController.EditCPU(testCpu.ID, testCpu.Name, testCpu.Type,
                testCpu.Stock, testCpu.Price, testCpu.Description, testCpu.Cores, testCpu.ClockSpeed, testCpu.Socket);
            var editedGraphicsCard = (RedirectToActionResult)editItemController.EditGraphicsCard(testGraphicsCard.ID, testGraphicsCard.Name, testGraphicsCard.Type,
                testGraphicsCard.Stock, testGraphicsCard.Price, testGraphicsCard.Description, testGraphicsCard.VRAM, testGraphicsCard.CudaCores);
            var editedLaptop = (RedirectToActionResult)editItemController.EditLaptop(testLaptop.ID, testLaptop.Name, testLaptop.Type,
                testLaptop.Stock, testLaptop.Price, testLaptop.Description, testLaptop.ScreenSize, testLaptop.RAM, testLaptop.Storage);
            var editedMemory = (RedirectToActionResult)editItemController.EditMemory(testMemory.ID, testMemory.Name, testMemory.Type,
                testMemory.Stock, testMemory.Price, testMemory.Description, testMemory.MemoryType, testMemory.MemorySize, testMemory.MemorySpeed);
            var editedMonitor = (RedirectToActionResult)editItemController.EditMonitor(testMonitor.ID, testMonitor.Name, testMonitor.Type,
                testMonitor.Stock, testMonitor.Price, testMonitor.Description, testMonitor.ScreenSize, testMonitor.RefreshRate);
            var editedMotherboard = (RedirectToActionResult)editItemController.EditMotherboard(testMotherboard.ID, testMotherboard.Name, testMotherboard.Type,
                testMotherboard.Stock, testMotherboard.Price, testMotherboard.Description, testMotherboard.Socket, testMotherboard.FormFactor);
            var editedStorage = (RedirectToActionResult)editItemController.EditStorage(testStorage.ID, testStorage.Name, testStorage.Type,
                testStorage.Stock, testStorage.Price, testStorage.Description, testStorage.StorageType, testStorage.StorageSize);

            Assert.Multiple(() =>
            {
                Assert.That(editedCase.ActionName, Is.EqualTo("Index"));
                Assert.That(editedCase.ControllerName, Is.EqualTo("Home"));
                Assert.That(editedCpu.ActionName, Is.EqualTo("Index"));
                Assert.That(editedCpu.ControllerName, Is.EqualTo("Home"));
                Assert.That(editedGraphicsCard.ActionName, Is.EqualTo("Index"));
                Assert.That(editedGraphicsCard.ControllerName, Is.EqualTo("Home"));
                Assert.That(editedLaptop.ActionName, Is.EqualTo("Index"));
                Assert.That(editedLaptop.ControllerName, Is.EqualTo("Home"));
                Assert.That(editedMemory.ActionName, Is.EqualTo("Index"));
                Assert.That(editedMemory.ControllerName, Is.EqualTo("Home"));
                Assert.That(editedMonitor.ActionName, Is.EqualTo("Index"));
                Assert.That(editedMonitor.ControllerName, Is.EqualTo("Home"));
                Assert.That(editedMotherboard.ActionName, Is.EqualTo("Index"));
                Assert.That(editedMotherboard.ControllerName, Is.EqualTo("Home"));
                Assert.That(editedStorage.ActionName, Is.EqualTo("Index"));
                Assert.That(editedStorage.ControllerName, Is.EqualTo("Home"));
            });
            Mock.VerifyAll();
        }
    }
}
