using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WindowsStore.BLL.Interfaces;
using WindowsStore.DAL;
using WindowsStore.DAL.Order;
using WindowsStore.DAL.OrderedWindow;
using WindowsStore.DAL.OrderedWindowSubElement;
using WindowStore.Shared.Order;
using WindowStore.Shared.OrderedWindow;
using WindowStore.Shared.OrderedWindowSubElement;

namespace WindowsStore.BLL.Services
{
    public class OrderService(BlazorWindowStoreContext context) : IOrderService
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();

        public async Task<List<OrderDTO>> GetOrders()
        {
            var orders = await context.Orders
                .Include(o => o.OrderedWindows)
                .ThenInclude(o => o.OrderedWindowSubElements)
                .OrderBy(o => o.OrderName)
                .ToListAsync();

            var result = _mapper.Map<List<OrderDTO>>(orders);

            return result;
        }

        public async Task AddSubElementToOrderAsync(AddSubElementToOrderedWindowDTO addSubElementToOrderedWindowDTO)
        {
            var orderedWindowSubElement = _mapper.Map<OrderedWindowSubElement>(addSubElementToOrderedWindowDTO);

            await context.OrderedWindowSubElements.AddAsync(orderedWindowSubElement);

            await context.SaveChangesAsync();
        }

        public async Task AddWindowToOrderAsync(AddWindowToOrderDTO addWindowToOrderDTO)
        {
            var orderedWindow = _mapper.Map<OrderedWindow>(addWindowToOrderDTO);

            await context.OrderedWindows.AddAsync(orderedWindow);

            await context.SaveChangesAsync();
        }

        public async Task CreateOderAsync(OrderCreateDTO orderUpdateDTO)
        {
            var order = _mapper.Map<Order>(orderUpdateDTO);

            await context.Orders.AddAsync(order);

            await context.SaveChangesAsync();
        }

        public async Task RemoveOrderAsync(int orderId)
        {
            var order = await context.Orders.FindAsync(orderId);
            if (order == null)
            {
                throw new KeyNotFoundException($"Order with orderId = {orderId} not found for remove action");
            }

            _ = context.Orders.Remove(order);

            await context.SaveChangesAsync();
        }

        public async Task RemoveSubElementFromOrderAsync(int orderedSubElementId)
        {
            var orderedSubElement = await context.OrderedWindowSubElements.FindAsync(orderedSubElementId)
                ?? throw new KeyNotFoundException($"Ordered SubElement with orderedSubElementId = {orderedSubElementId} not found for remove action");

            _ = context.OrderedWindowSubElements.Remove(orderedSubElement);

            await context.SaveChangesAsync();
        }

        public async Task RemoveWindowFromOrderAsync(int orderedWindowId)
        {
            var orderedWindow = await context.OrderedWindows.FindAsync(orderedWindowId)
                ?? throw new KeyNotFoundException($"Ordered Window with orderedWindowId = {orderedWindowId} not found for remove action");

            _ = context.OrderedWindows.Remove(orderedWindow);

            await context.SaveChangesAsync();
        }

        public async Task UpdateOderAsync(OrderUpdateDTO orderUpdateDTO)
        {
            var order = await context.Orders.FindAsync(orderUpdateDTO.OrderId)
                ?? throw new KeyNotFoundException($"Order with orderId = {orderUpdateDTO.OrderId} not found for update action");

            order = _mapper.Map(orderUpdateDTO, order);
            context.Orders.Update(order);

            await context.SaveChangesAsync();
        }
    }
}
