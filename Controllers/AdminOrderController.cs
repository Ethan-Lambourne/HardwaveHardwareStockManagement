using HardwaveStockManagement.Models;
using HardwaveStockManagement.Repository;
using HardwaveStockManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HardwaveStockManagement.Controllers
{
    public class AdminOrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IItemsRepository<Case> _caseRepository;
        private readonly IItemsRepository<CPU> _cpuRepository;
        private readonly IItemsRepository<GraphicsCard> _graphicsCardRepository;
        private readonly IItemsRepository<Laptop> _laptopRepository;
        private readonly IItemsRepository<Memory> _memoryRepository;
        private readonly IItemsRepository<Models.Monitor> _monitorRepository;
        private readonly IItemsRepository<Motherboard> _motherboardRepository;
        private readonly IItemsRepository<Storage> _storageRepository;

        public AdminOrderController(IOrderRepository orderRepository, IItemsRepository<Case> caseRepository, IItemsRepository<CPU> cpuRepository,
            IItemsRepository<GraphicsCard> graphicsCardRepository, IItemsRepository<Laptop> laptopRepository,
            IItemsRepository<Memory> memoryRepository, IItemsRepository<Models.Monitor> monitorRepository,
            IItemsRepository<Motherboard> motherboardRepository, IItemsRepository<Storage> storageRepository)
        {
            _orderRepository = orderRepository;
            _caseRepository = caseRepository;
            _cpuRepository = cpuRepository;
            _graphicsCardRepository = graphicsCardRepository;
            _laptopRepository = laptopRepository;
            _memoryRepository = memoryRepository;
            _monitorRepository = monitorRepository;
            _motherboardRepository = motherboardRepository;
            _storageRepository = storageRepository;
        }

        [Route("/Orders")]
        public IActionResult AdminOrderView() 
        {
            AdminOrdersViewModel adminOrdersViewModel = new(_orderRepository.GetAllOrders());
            return View(adminOrdersViewModel);
        }

        public IActionResult ResolveOrder(Guid orderId)
        {
            var order = _orderRepository.GetOrder(orderId);
            if (order != null)
            {
                for (int i = 0; i < order.OrderItems.Length; i++)
                {
                    var itemId = order.OrderItems[i];
                    var amount = order.OrderAmounts[i];
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
                        Case newItem = new(Case.ID, Case.Name, Case.Type, Case.Stock - amount, Case.Price, Case.Description, Case.FormFactor);
                        _caseRepository.EditItem(newItem, itemId);
                    }
                    else if (cpu != null)
                    {
                        CPU newItem = new(cpu.ID, cpu.Name, cpu.Type, cpu.Stock - amount, cpu.Price, cpu.Description, cpu.Cores, cpu.ClockSpeed, cpu.Socket);
                        _cpuRepository.EditItem(newItem, itemId);
                    }
                    else if (graphicsCard != null)
                    {
                        GraphicsCard newItem = new(graphicsCard.ID, graphicsCard.Name, graphicsCard.Type, graphicsCard.Stock - amount, graphicsCard.Price, graphicsCard.Description, graphicsCard.VRAM, graphicsCard.CudaCores);
                        _graphicsCardRepository.EditItem(newItem, itemId);
                    }
                    else if (laptop != null)
                    {
                        Laptop newItem = new(laptop.ID, laptop.Name, laptop.Type, laptop.Stock - amount, laptop.Price, laptop.Description, laptop.ScreenSize, laptop.RAM, laptop.Storage);
                        _laptopRepository.EditItem(newItem, itemId);
                    }
                    else if (memory != null)
                    {
                        Memory newItem = new(memory.ID, memory.Name, memory.Type, memory.Stock - amount, memory.Price, memory.Description, memory.MemoryType, memory.MemorySize, memory.MemorySpeed);
                        _memoryRepository.EditItem(newItem, itemId);
                    }
                    else if (monitor != null)
                    {
                        Models.Monitor newItem = new(monitor.ID, monitor.Name, monitor.Type, monitor.Stock - amount, monitor.Price, monitor.Description, monitor.ScreenSize, monitor.RefreshRate);
                        _monitorRepository.EditItem(newItem, itemId);
                    }
                    else if (motherboard != null)
                    {
                        Motherboard newItem = new(motherboard.ID, motherboard.Name, motherboard.Type, motherboard.Stock - amount, motherboard.Price, motherboard.Description, motherboard.Socket, motherboard.FormFactor);
                        _motherboardRepository.EditItem(newItem, itemId);
                    }
                    else if (storage != null)
                    {
                        Storage newItem = new(storage.ID, storage.Name, storage.Type, storage.Stock - amount, storage.Price, storage.Description, storage.StorageType, storage.StorageSize);
                        _storageRepository.EditItem(newItem, itemId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                _orderRepository.DeleteOrder(orderId);
                AdminOrdersViewModel adminOrdersViewModel = new(_orderRepository.GetAllOrders());
                return View("AdminOrderView", adminOrdersViewModel);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
