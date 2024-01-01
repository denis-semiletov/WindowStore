using Microsoft.AspNetCore.Mvc;
using WindowsStore.BLL.Interfaces;
using WindowStore.Shared.Order;
using WindowStore.Shared.OrderedWindow;
using WindowStore.Shared.OrderedWindowSubElement;

namespace WindowStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpGet]
        [Route("all")]
        public async Task<List<OrderDTO>> GetOrders()
        {
            var orders = await _orderService.GetOrders();

            return orders;
        }

        [HttpPost]
        [Route("")]
        public async Task<OrderDTO> CreateOrderAsync(OrderCreateDTO orderCreteDTO)
        {
            var order = await _orderService.CreateOrderAsync(orderCreteDTO);

            return order;
        }

        [HttpPut]
        [Route("")]
        public async Task<OrderDTO> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO)
        {
            var order = await _orderService.UpdateOrderAsync(orderUpdateDTO);

            return order;
        }

        [HttpDelete]
        [Route("{orderId:int}")]
        public async Task<bool> RemoveOrderAsync(int orderId)
        {
            var result = await _orderService.RemoveOrderAsync(orderId);

            return result;
        }

        [HttpPost]
        [Route("window")]
        public async Task<OrderedWindowDTO> AddWindowToOrderAsync(AddWindowToOrderDTO addWindowToOrderDTO)
        {
            var order = await _orderService.AddWindowToOrderAsync(addWindowToOrderDTO);

            return order;
        }

        [HttpDelete]
        [Route("window/{orderedWindowId:int}")]
        public async Task<bool> RemoveWindowFromOrderAsync(int orderedWindowId)
        {
            var result = await _orderService.RemoveWindowFromOrderAsync(orderedWindowId);

            return result;
        }

        [HttpPost]
        [Route("subElement")]
        public async Task<OrderedWindowSubElementDTO> AddWindowToOrderAsync(AddSubElementToOrderedWindowDTO dto)
        {
            var order = await _orderService.AddSubElementToOrderAsync(dto);

            return order;
        }

        [HttpDelete]
        [Route("subElement/{orderedSubElementId:int}")]
        public async Task<bool> RemoveSubElementFromOrderAsync(int orderedSubElementId)
        {
            var result = await _orderService.RemoveSubElementFromOrderAsync(orderedSubElementId);

            return result;
        }

    }
}
