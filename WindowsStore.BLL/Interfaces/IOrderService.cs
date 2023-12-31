using WindowStore.Shared.Order;
using WindowStore.Shared.OrderedWindow;
using WindowStore.Shared.OrderedWindowSubElement;

namespace WindowsStore.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetOrders();
        Task UpdateOderAsync(OrderUpdateDTO orderUpdateDTO);
        Task CreateOderAsync(OrderCreateDTO orderCreteDTO);
        Task RemoveOrderAsync(int orderId);
        Task AddWindowToOrderAsync(AddWindowToOrderDTO addWindowToOrderDTO);
        Task RemoveWindowFromOrderAsync(int orderedWindowId);
        Task AddSubElementToOrderAsync(AddSubElementToOrderedWindowDTO addSubElementToOrderedWindowDTO);
        Task RemoveSubElementFromOrderAsync(int orderedSubElementId);
    }
}
