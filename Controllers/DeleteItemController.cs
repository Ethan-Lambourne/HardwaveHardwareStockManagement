using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using HardwaveStockManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HardwaveStockManagement.Controllers
{
    public class DeleteItemController : Controller
    {
        private readonly IItemsRepository<Case> _caseRepository;
        private readonly IItemsRepository<CPU> _cpuRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<Memory> _memoryRepository;
        private readonly IItemsRepository<Models.Monitor> _monitorRepository;
        private readonly IItemsRepository<Motherboard> _motherboardRepository;
        private readonly IItemsRepository<Storage> _storageRepository;

        public DeleteItemController(IItemsRepository<Case> caseRepository, IItemsRepository<CPU> cpuRepository,
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

        [Route("/DeleteItemConfirmation/{itemId}")]
        public IActionResult DeleteItemView(Guid itemId)
        {
            Case? Case = _caseRepository.GetItem(itemId);
            CPU? cpu = _cpuRepository.GetItem(itemId);
            GraphicsCard? graphicsCard = _graphicsCardRepository.GetItem(itemId);
            Laptop? laptop = _laptopRepository.GetItem(itemId);
            Memory? memory = _memoryRepository.GetItem(itemId);
            Models.Monitor? monitor = _monitorRepository.GetItem(itemId);
            Motherboard? motherboard = _motherboardRepository.GetItem(itemId);
            Storage? storage = _storageRepository.GetItem(itemId);
            if (Case != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(Case, null, null, null, null, null, null, null);
                return View(deleteItemViewModel);
            }
            else if (cpu != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(null, cpu, null, null, null, null, null, null);
                return View(deleteItemViewModel);
            }
            else if (graphicsCard != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(null, null, graphicsCard, null, null, null, null, null);
                return View(deleteItemViewModel);
            }
            else if (laptop != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(null, null, null, laptop, null, null, null, null);
                return View(deleteItemViewModel);
            }
            else if (memory != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(null, null, null, null, memory, null, null, null);
                return View(deleteItemViewModel);
            }
            else if (monitor != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(null, null, null, null, null, monitor, null, null);
                return View(deleteItemViewModel);
            }
            else if (motherboard != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(null, null, null, null, null, null, motherboard, null);
                return View(deleteItemViewModel);
            }
            else if (storage != null)
            {
                DeleteItemViewModel deleteItemViewModel = new(null, null, null, null, null, null, null, storage);
                return View(deleteItemViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult DeleteItem(Guid itemId)
        {
            Case? Case = _caseRepository.GetItem(itemId);
            CPU? cpu = _cpuRepository.GetItem(itemId);
            GraphicsCard? graphicsCard = _graphicsCardRepository.GetItem(itemId);
            Laptop? laptop = _laptopRepository.GetItem(itemId);
            Memory? memory = _memoryRepository.GetItem(itemId);
            Models.Monitor? monitor = _monitorRepository.GetItem(itemId);
            Motherboard? motherboard = _motherboardRepository.GetItem(itemId);
            Storage? storage = _storageRepository.GetItem(itemId);
            var isItemDeleted = false;
            if (Case != null)
            {
                isItemDeleted = _caseRepository.DeleteItem(itemId);
            }
            else if (cpu != null)
            {
                isItemDeleted = _cpuRepository.DeleteItem(itemId);
            }
            else if (graphicsCard != null)
            {
                isItemDeleted = _graphicsCardRepository.DeleteItem(itemId);
            }
            else if (laptop != null)
            {
                isItemDeleted = _laptopRepository.DeleteItem(itemId);
            }
            else if (memory != null)
            {
                isItemDeleted = _memoryRepository.DeleteItem(itemId);
            }
            else if (monitor != null)
            {
                isItemDeleted = _monitorRepository.DeleteItem(itemId);
            }
            else if (motherboard != null)
            {
                isItemDeleted = _motherboardRepository.DeleteItem(itemId);
            }
            else if (storage != null)
            {
                isItemDeleted = _storageRepository.DeleteItem(itemId);
            }

            if (isItemDeleted)
            {
                return RedirectToAction("Index", "Home", new { itemRecentlyDeleted = true });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
