using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HardwaveStockManagement.Controllers
{
    public class EditItemController : Controller
    {
        private readonly IItemsRepository<Case> _caseRepository;
        private readonly IItemsRepository<CPU> _cpuRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<Memory> _memoryRepository;
        private readonly IItemsRepository<Models.Monitor> _monitorRepository;
        private readonly IItemsRepository<Motherboard> _motherboardRepository;
        private readonly IItemsRepository<Storage> _storageRepository;

        public EditItemController(IItemsRepository<Case> caseRepository, IItemsRepository<CPU> cpuRepository,
            IItemsRepository<GraphicsCard> graphicsCardRepository, IItemsRepository<Laptop> laptopRepository,
            IItemsRepository<Memory> memoryRepository, IItemsRepository<Models.Monitor> monitorRepository,
            IItemsRepository<Motherboard> motherboardRepository, IItemsRepository<Storage> storageRepository)
        {
            _caseRepository = caseRepository;
            _cpuRepository = cpuRepository;
            _graphicsCardRepository = graphicsCardRepository;
            _laptopRepository = laptopRepository;
            _memoryRepository = memoryRepository;
            _monitorRepository = monitorRepository;
            _motherboardRepository = motherboardRepository;
            _storageRepository = storageRepository;
        }

        [Route("/EditCaseDetails/{caseId}")]
        public IActionResult EditCaseView(Guid caseId)
        {
            Case? Case = _caseRepository.GetItem(caseId);
            if (Case != null)
            {
                return View(Case);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("/EditCpuDetails/{cpuId}")]
        public IActionResult EditCPUView(Guid cpuId)
        {
            CPU? cpu = _cpuRepository.GetItem(cpuId);
            if (cpu != null)
            {
                return View(cpu);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("/EditGraphicsCardDetails/{graphicsCardId}")]
        public IActionResult EditGraphicsCardView(Guid graphicsCardId)
        {
            GraphicsCard? graphicsCard = _graphicsCardRepository.GetItem(graphicsCardId);
            if (graphicsCard != null)
            {
                return View(graphicsCard);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("/EditLaptopDetails/{laptopId}")]
        public IActionResult EditLaptopView(Guid laptopId)
        {
            Laptop? laptop = _laptopRepository.GetItem(laptopId);
            if (laptop != null)
            {
                return View(laptop);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("/EditMemoryDetails/{memoryId}")]
        public IActionResult EditMemoryView(Guid memoryId)
        {
            Memory? memory = _memoryRepository.GetItem(memoryId);
            if (memory != null)
            {
                return View(memory);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("/EditMonitorDetails/{monitorId}")]
        public IActionResult EditMonitorView(Guid monitorId)
        {
            Models.Monitor? monitor = _monitorRepository.GetItem(monitorId);
            if (monitor != null)
            {
                return View(monitor);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("/EditMotherboardDetails/{motherboardId}")]
        public IActionResult EditMotherboardView(Guid motherboardId)
        {
            Motherboard? motherboard = _motherboardRepository.GetItem(motherboardId);
            if (motherboard != null)
            {
                return View(motherboard);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("/EditStorageDetails/{storageId}")]
        public IActionResult EditStorageView(Guid storageId)
        {
            Storage? storage = _storageRepository.GetItem(storageId);
            if (storage != null)
            {
                return View(storage);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult EditCase(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string FormFactor)
        {
            Case exampleItem = new(ID, Name, Type, Stock, Price, Description, FormFactor);
            Case? editedItem = _caseRepository.EditItem(exampleItem, ID);
            if (editedItem != null && editedItem.Name == Name && editedItem.Stock == Stock && editedItem.Price == Price
                && editedItem.Description == Description && editedItem.FormFactor == FormFactor)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyEdited = true });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult EditCPU(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, int Cores, double ClockSpeed, string Socket)
        {
            CPU exampleItem = new(ID, Name, Type, Stock, Price, Description, Cores, ClockSpeed, Socket);
            CPU? editedItem = _cpuRepository.EditItem(exampleItem, ID);
            if (editedItem != null && editedItem.Name == Name && editedItem.Stock == Stock && editedItem.Price == Price
                && editedItem.Description == Description && editedItem.Cores == Cores && editedItem.ClockSpeed == ClockSpeed && editedItem.Socket == Socket)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyEdited = true });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult EditGraphicsCard(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, int VRAM, int CudaCores)
        {
            GraphicsCard exampleItem = new(ID, Name, Type, Stock, Price, Description, VRAM, CudaCores);
            GraphicsCard? editedItem = _graphicsCardRepository.EditItem(exampleItem, ID);
            if (editedItem != null && editedItem.Name == Name && editedItem.Stock == Stock && editedItem.Price == Price 
                && editedItem.Description == Description && editedItem.VRAM == VRAM && editedItem.CudaCores == CudaCores)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyEdited = true });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult EditLaptop(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, double ScreenSize, int RAM, int Storage)
        {
            Laptop exampleItem = new(ID, Name, Type, Stock, Price, Description, ScreenSize, RAM, Storage);
            Laptop? editedItem = _laptopRepository.EditItem(exampleItem, ID);
            if (editedItem != null && editedItem.Name == Name && editedItem.Stock == Stock && editedItem.Price == Price
                && editedItem.Description == Description && editedItem.ScreenSize == ScreenSize && editedItem.RAM == RAM && editedItem.Storage == Storage)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyEdited = true });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult EditMemory(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string MemoryType, int MemorySize, int MemorySpeed)
        {
            Memory exampleItem = new(ID, Name, Type, Stock, Price, Description, MemoryType, MemorySize, MemorySpeed);
            Memory? editedItem = _memoryRepository.EditItem(exampleItem, ID);
            if (editedItem != null && editedItem.Name == Name && editedItem.Stock == Stock && editedItem.Price == Price
                && editedItem.Description == Description && editedItem.MemoryType == MemoryType 
                && editedItem.MemorySize == MemorySize && editedItem.MemorySpeed == MemorySpeed)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyEdited = true });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult EditMonitor(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, double ScreenSize, int RefreshRate)
        {
            Models.Monitor exampleItem = new(ID, Name, Type, Stock, Price, Description, ScreenSize, RefreshRate);
            Models.Monitor? editedItem = _monitorRepository.EditItem(exampleItem, ID);
            if (editedItem != null && editedItem.Name == Name && editedItem.Stock == Stock && editedItem.Price == Price
                && editedItem.Description == Description && editedItem.ScreenSize == ScreenSize && editedItem.RefreshRate == RefreshRate)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyEdited = true });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult EditMotherboard(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string Socket, string FormFactor)
        {
            Motherboard exampleItem = new(ID, Name, Type, Stock, Price, Description, Socket, FormFactor);
            Motherboard? editedItem = _motherboardRepository.EditItem(exampleItem, ID);
            if (editedItem != null && editedItem.Name == Name && editedItem.Stock == Stock && editedItem.Price == Price
                && editedItem.Description == Description && editedItem.Socket == Socket && editedItem.FormFactor == FormFactor)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyEdited = true });
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult EditStorage(Guid ID, string Name, string Type, int? Stock, double? Price, string? Description, string StorageType, int StorageSize)
        {
            Storage exampleItem = new(ID, Name, Type, Stock, Price, Description, StorageType, StorageSize);
            Storage? editedItem = _storageRepository.EditItem(exampleItem, ID);
            if (editedItem != null && editedItem.Name == Name && editedItem.Stock == Stock && editedItem.Price == Price
                && editedItem.Description == Description && editedItem.StorageType == StorageType && editedItem.StorageSize == StorageSize)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyEdited = true });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
