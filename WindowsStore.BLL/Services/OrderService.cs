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
				.Include(o => o.OrderedWindows).ThenInclude(y => y.Window)
				.Include(o => o.OrderedWindows).ThenInclude(o => o.OrderedWindowSubElements).ThenInclude(o => o.SubElement)
				.OrderBy(o => o.OrderName)
                .ToListAsync();

            var result = _mapper.Map<List<OrderDTO>>(orders);

            return result;
        }

        public async Task<OrderedWindowSubElementDTO> AddSubElementToOrderAsync(AddSubElementToOrderedWindowDTO addSubElementToOrderedWindowDTO)
        {
            var orderedWindowSubElement = _mapper.Map<OrderedWindowSubElement>(addSubElementToOrderedWindowDTO);

            await context.OrderedWindowSubElements.AddAsync(orderedWindowSubElement);

            await context.SaveChangesAsync();

            var result = _mapper.Map<OrderedWindowSubElementDTO>(orderedWindowSubElement);

            return result;
        }

        public async Task<OrderedWindowDTO> AddWindowToOrderAsync(AddWindowToOrderDTO addWindowToOrderDTO)
        {
            var orderedWindow = _mapper.Map<OrderedWindow>(addWindowToOrderDTO);

            await context.OrderedWindows.AddAsync(orderedWindow);

            await context.SaveChangesAsync();

            var result = _mapper.Map<OrderedWindowDTO>(orderedWindow);

            return result;
        }

        public async Task<OrderDTO> CreateOrderAsync(OrderCreateDTO orderUpdateDTO)
        {
            var order = _mapper.Map<Order>(orderUpdateDTO);

            await context.Orders.AddAsync(order);

            await context.SaveChangesAsync();

            var newOrder = _mapper.Map<OrderDTO>(order);

            return newOrder;
        }

        public async Task<bool> RemoveOrderAsync(int orderId)
        {
            var order = await context.Orders.FindAsync(orderId) 
                ?? throw new KeyNotFoundException($"Order with orderId = {orderId} not found for action remove");

            _ = context.Orders.Remove(order);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveSubElementFromOrderAsync(int orderedSubElementId)
        {
            var orderedSubElement = await context.OrderedWindowSubElements.FindAsync(orderedSubElementId)
                ?? throw new KeyNotFoundException($"Ordered SubElement with orderedSubElementId = {orderedSubElementId} not found for action remove");

            _ = context.OrderedWindowSubElements.Remove(orderedSubElement);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveWindowFromOrderAsync(int orderedWindowId)
        {
            var orderedWindow = await context.OrderedWindows.FindAsync(orderedWindowId)
                ?? throw new KeyNotFoundException($"Ordered Window with orderedWindowId = {orderedWindowId} not found for action remove");

            _ = context.OrderedWindows.Remove(orderedWindow);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<OrderDTO> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO)
        {
            var order = await context.Orders.FindAsync(orderUpdateDTO.OrderId)
                ?? throw new KeyNotFoundException($"Order with orderId = {orderUpdateDTO.OrderId} not found for action update");

            order = _mapper.Map(orderUpdateDTO, order);
            context.Orders.Update(order);

            await context.SaveChangesAsync();

            var orderUpdate = _mapper.Map<OrderDTO>(order);

            return orderUpdate;
        }
    }
}
