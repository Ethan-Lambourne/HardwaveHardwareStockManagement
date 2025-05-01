using HardwaveStockManagement.GenerateID;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using HardwaveStockManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HardwaveStockManagement.Controllers
{
    public class AddItemController : Controller
    {
        private readonly IItemsRepository<Case> _caseRepository;
        private readonly IItemsRepository<CPU> _cpuRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<Memory> _memoryRepository;
        private readonly IItemsRepository<Models.Monitor> _monitorRepository;
        private readonly IItemsRepository<Motherboard> _motherboardRepository;
        private readonly IItemsRepository<Storage> _storageRepository;
        private readonly IGenerateItemID _generateItemID;

        public AddItemController(IItemsRepository<Case> caseRepository, IItemsRepository<CPU> cpuRepository,
            IItemsRepository<GraphicsCard> graphicsCardRepository, IItemsRepository<Laptop> laptopRepository, 
            IItemsRepository<Memory> memoryRepository, IItemsRepository<Models.Monitor> monitorRepository, 
            IItemsRepository<Motherboard> motherboardRepository, IItemsRepository<Storage> storageRepository, IGenerateItemID generateItemID)
        {
            _caseRepository = caseRepository;
            _cpuRepository = cpuRepository;
            _graphicsCardRepository = graphicsCardRepository;
            _laptopRepository = laptopRepository;
            _memoryRepository = memoryRepository;
            _monitorRepository = monitorRepository;
            _motherboardRepository = motherboardRepository;
            _storageRepository = storageRepository;
            _generateItemID = generateItemID;
        }

        [Route("/AddItemForm")]
        public IActionResult AddItemView()
        {
            AddItemViewModel addItemViewModel = new()
            {
                ID = _generateItemID.GenerateID()
            };
            return View(addItemViewModel);
        }

        public IActionResult AddCase(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string FormFactor)
        {
            Case pcCase = new(ID, Name, Type, Stock, Price, Description, FormFactor);
            var addedCase = _caseRepository.AddItem(pcCase);
            if (addedCase.ID == pcCase.ID)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = true, itemRecentlyEdited = false, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult AddCPU(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, int Cores, double ClockSpeed, string Socket)
        {
            CPU Cpu = new(ID, Name, Type, Stock, Price, Description, Cores, ClockSpeed, Socket);
            var addedCpu = _cpuRepository.AddItem(Cpu);
            if (addedCpu.ID == Cpu.ID)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = true, itemRecentlyEdited = false, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult AddGraphicsCard(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, int VRAM, int CudaCores)
        {
            GraphicsCard graphicsCard = new(ID, Name, Type, Stock, Price, Description, VRAM, CudaCores);
            var addedGraphicsCard = _graphicsCardRepository.AddItem(graphicsCard);
            if (addedGraphicsCard.ID == graphicsCard.ID)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = true, itemRecentlyEdited = false, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult AddLaptop(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, double ScreenSize, int RAM, int Storage)
        {
            Laptop laptop = new(ID, Name, Type, Stock, Price, Description, ScreenSize, RAM, Storage);
            var addedLaptop = _laptopRepository.AddItem(laptop);
            if (addedLaptop.ID == laptop.ID)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = true, itemRecentlyEdited = false, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult AddMemory(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string MemoryType, int MemorySize, int MemorySpeed)
        {
            Memory memory = new(ID, Name, Type, Stock, Price, Description, MemoryType, MemorySize, MemorySpeed);
            var addedMemory = _memoryRepository.AddItem(memory);
            if (addedMemory.ID == memory.ID)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = true, itemRecentlyEdited = false, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult AddMonitor(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, double ScreenSize, int RefreshRate)
        {
            Models.Monitor monitor = new(ID, Name, Type, Stock, Price, Description, ScreenSize, RefreshRate);
            var addedMonitor = _monitorRepository.AddItem(monitor);
            if (addedMonitor.ID == monitor.ID)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = true, itemRecentlyEdited = false, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult AddMotherboard(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string Socket, string FormFactor)
        {
            Motherboard motherboard = new(ID, Name, Type, Stock, Price, Description, Socket, FormFactor);
            var addedMotherboard = _motherboardRepository.AddItem(motherboard);
            if (addedMotherboard.ID == motherboard.ID)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = true, itemRecentlyEdited = false, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult AddStorage(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string StorageType, int StorageSize)
        {
            Storage storage = new(ID, Name, Type, Stock, Price, Description, StorageType, StorageSize);
            var addedStorage = _storageRepository.AddItem(storage);
            if (addedStorage.ID == storage.ID)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyAdded = true, itemRecentlyEdited = false, itemRecentlyDeleted = false });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
