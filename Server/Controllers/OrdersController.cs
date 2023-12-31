using Microsoft.AspNetCore.Mvc;
using WindowsStore.BLL.Interfaces;
using WindowStore.Shared.Order;

namespace WindowStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpGet]
        [Route("All")]
        public async Task<List<OrderDTO>> GetOrders()
        {
            var orders = await _orderService.GetOrders();

            return orders;
        }
    }
}
