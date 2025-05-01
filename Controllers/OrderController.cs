using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using HardwaveStockManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HardwaveStockManagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly IItemsRepository<Case> _caseRepository;
        private readonly IItemsRepository<CPU> _cpuRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<Memory> _memoryRepository;
        private readonly IItemsRepository<Models.Monitor> _monitorRepository;
        private readonly IItemsRepository<Motherboard> _motherboardRepository;
        private readonly IItemsRepository<Storage> _storageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IItemsRepository<Case> caseRepository, IItemsRepository<CPU> cpuRepository,
            IItemsRepository<GraphicsCard> graphicsCardRepository, IItemsRepository<Laptop> laptopRepository,
            IItemsRepository<Memory> memoryRepository, IItemsRepository<Models.Monitor> monitorRepository,
            IItemsRepository<Motherboard> motherboardRepository, IItemsRepository<Storage> storageRepository,
            IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _caseRepository = caseRepository;
            _cpuRepository = cpuRepository;
            _graphicsCardRepository = graphicsCardRepository;
            _laptopRepository = laptopRepository;
            _memoryRepository = memoryRepository;
            _monitorRepository = monitorRepository;
            _motherboardRepository = motherboardRepository;
            _storageRepository = storageRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        [Route("/Order")]
        public IActionResult OrderView()
        {
            OrderViewModel orderViewModel = new(_orderRepository.GetOrderContent()!, _caseRepository.GetAllItems(), _cpuRepository.GetAllItems(),
                _graphicsCardRepository.GetAllItems(), _laptopRepository.GetAllItems(), _memoryRepository.GetAllItems(), _monitorRepository.GetAllItems(),
                _motherboardRepository.GetAllItems(), _storageRepository.GetAllItems());
            return View(orderViewModel);
        }

        public IActionResult AddItemToOrder(Guid itemId, int orderAmount)
        {
            var isItemAdded = _orderRepository.AddItemToOrder(itemId, orderAmount);
            if (isItemAdded)
            {
                return RedirectToAction("StoreView", "Store");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult DeleteItemFromOrder(Guid itemId)
        {
            var isItemDeleted = _orderRepository.DeleteItemFromOrder(itemId);
            if (isItemDeleted)
            {
                OrderViewModel orderViewModel = new(_orderRepository.GetOrderContent()!, _caseRepository.GetAllItems(), _cpuRepository.GetAllItems(),
                _graphicsCardRepository.GetAllItems(), _laptopRepository.GetAllItems(), _memoryRepository.GetAllItems(), _monitorRepository.GetAllItems(),
                _motherboardRepository.GetAllItems(), _storageRepository.GetAllItems());
                return View("OrderView", orderViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult SubmitOrder()
        {
            var isOrderSubmitted = _orderRepository.SubmitOrder(_userRepository.GetCurrentUserID());
            if (isOrderSubmitted)
            {
                return RedirectToAction("StoreView", "Store");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
