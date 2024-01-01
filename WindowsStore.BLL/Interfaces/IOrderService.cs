using WindowStore.Shared.Order;
using WindowStore.Shared.OrderedWindow;
using WindowStore.Shared.OrderedWindowSubElement;

namespace WindowsStore.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDTO>> GetOrders();
        Task<OrderDTO> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO);
        Task<OrderDTO> CreateOrderAsync(OrderCreateDTO orderCreteDTO);
        Task<bool> RemoveOrderAsync(int orderId);
        Task<OrderedWindowDTO> AddWindowToOrderAsync(AddWindowToOrderDTO addWindowToOrderDTO);
        Task<bool> RemoveWindowFromOrderAsync(int orderedWindowId);
        Task<OrderedWindowSubElementDTO> AddSubElementToOrderAsync(AddSubElementToOrderedWindowDTO addSubElementToOrderedWindowDTO);
        Task<bool> RemoveSubElementFromOrderAsync(int orderedSubElementId);
    }
}
