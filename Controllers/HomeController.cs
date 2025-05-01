using System.Diagnostics;
using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using HardwaveStockManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HardwaveStockManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemsRepository<Case> _caseRepository;
        private readonly IItemsRepository<CPU> _cpuRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<Memory> _memoryRepository;
        private readonly IItemsRepository<Models.Monitor> _monitorRepository;
        private readonly IItemsRepository<Motherboard> _motherboardRepository;
        private readonly IItemsRepository<Storage> _storageRepository;

        public HomeController(IItemsRepository<Case> caseRepository, IItemsRepository<CPU> cpuRepository, 
            IItemsRepository<GraphicsCard> graphicsCardRepository, IItemsRepository<Laptop> laptopRepository, IItemsRepository<Memory> memoryRepository, 
            IItemsRepository<Models.Monitor> monitorRepository, IItemsRepository<Motherboard> motherboardRepository, IItemsRepository<Storage> storageRepository)
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

        public IActionResult Index(bool itemRecentlyAdded, bool itemRecentlyEdited, bool itemRecentlyDeleted, bool userRecentlyCreated, bool userRecentlyDeleted, List<Items>? searchOutput)
        {
            HomeViewModel homeViewModel = new(_caseRepository.GetAllItems(), _cpuRepository.GetAllItems(), _graphicsCardRepository.GetAllItems(),
                _laptopRepository.GetAllItems(), _memoryRepository.GetAllItems(), _monitorRepository.GetAllItems(), _motherboardRepository.GetAllItems(), 
                _storageRepository.GetAllItems(), itemRecentlyAdded, itemRecentlyEdited, itemRecentlyDeleted, userRecentlyCreated, userRecentlyDeleted, null, searchOutput);
            return View(homeViewModel);
        }

        public IActionResult Settings()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SearchItems(string SearchInput)
        {
            if (SearchInput.IsNullOrEmpty())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                List<Items> itemList = new();
                itemList.AddRange(_caseRepository.GetAllItems());
                itemList.AddRange(_cpuRepository.GetAllItems());
                itemList.AddRange(_graphicsCardRepository.GetAllItems());
                itemList.AddRange(_laptopRepository.GetAllItems());
                itemList.AddRange(_memoryRepository.GetAllItems());
                itemList.AddRange(_monitorRepository.GetAllItems());
                itemList.AddRange(_motherboardRepository.GetAllItems());
                itemList.AddRange(_storageRepository.GetAllItems());
                List<Items> resultsList = new();
                foreach (var item in itemList)
                {
                    if (item.ID.ToString().Contains(SearchInput))
                    {
                        resultsList.Add(item);
                    }
                    if (item.Name.Contains(SearchInput))
                    {
                        resultsList.Add(item);
                    }
                    if (item.Type.Contains(SearchInput))
                    {
                        resultsList.Add(item);
                    }
                    if (item.Price.ToString()!.Contains(SearchInput))
                    {
                        resultsList.Add(item);
                    }
                    if (item.Stock.ToString()!.Contains(SearchInput))
                    {
                        resultsList.Add(item);
                    }
                }
                HomeViewModel homeViewModel = new(_caseRepository.GetAllItems(), _cpuRepository.GetAllItems(), _graphicsCardRepository.GetAllItems(),
                    _laptopRepository.GetAllItems(), _memoryRepository.GetAllItems(), _monitorRepository.GetAllItems(), _motherboardRepository.GetAllItems(),
                    _storageRepository.GetAllItems(), false, false, false, false, false, null, resultsList.Distinct().ToList());
                return View("Index", homeViewModel);
            }
        }
    }
}
