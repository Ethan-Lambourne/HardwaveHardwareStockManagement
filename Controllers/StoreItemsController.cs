using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HardwaveStockManagement.Controllers
{
    public class StoreItemsController : Controller
    {
        private readonly IItemsRepository<Case> _caseRepository;
        private readonly IItemsRepository<CPU> _cpuRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<Memory> _memoryRepository;
        private readonly IItemsRepository<Models.Monitor> _monitorRepository;
        private readonly IItemsRepository<Motherboard> _motherboardRepository;
        private readonly IItemsRepository<Storage> _storageRepository;

        public StoreItemsController(IItemsRepository<Case> caseRepository, IItemsRepository<CPU> cpuRepository,
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

        [Route("/StoreCaseDetails/{caseId}")]
        public IActionResult StoreCaseView(Guid caseId)
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

        [Route("/StoreCpuDetails/{cpuId}")]
        public IActionResult StoreCPUView(Guid cpuId)
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

        [Route("/StoreGraphicsCardDetails/{graphicsCardId}")]
        public IActionResult StoreGraphicsCardView(Guid graphicsCardId)
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

        [Route("/StoreLaptopDetails/{laptopId}")]
        public IActionResult StoreLaptopView(Guid laptopId)
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

        [Route("/StoreMemoryDetails/{memoryId}")]
        public IActionResult StoreMemoryView(Guid memoryId)
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

        [Route("/StoreMonitorDetails/{monitorId}")]
        public IActionResult StoreMonitorView(Guid monitorId)
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

        [Route("/StoreMotherboardDetails/{motherboardId}")]
        public IActionResult StoreMotherboardView(Guid motherboardId)
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

        [Route("/StoreStorageDetails/{storageId}")]
        public IActionResult StoreStorageView(Guid storageId)
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
    }
}
