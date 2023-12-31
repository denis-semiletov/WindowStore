using System.Net.Http.Json;
using WindowStore.Shared.Order;
using WindowStore.Shared.OrderedWindow;
using WindowStore.Shared.OrderedWindowSubElement;

namespace WindowStore.Client.Services
{
    public class OrderServiceClient(HttpClient httpClient) : IOrderServiceClient
    {
        public async Task<IEnumerable<OrderDTO>?> GetOrders()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<OrderDTO>>("/api/orders/all");
        }

        public Task AddSubElementToOrderAsync(AddSubElementToOrderedWindowDTO addSubElementToOrderedWindowDTO)
        {
            throw new NotImplementedException();
        }

        public Task AddWindowToOrderAsync(AddWindowToOrderDTO addWindowToOrderDTO)
        {
            throw new NotImplementedException();
        }

        public Task CreateOderAsync(OrderCreateDTO orderCreteDTO)
        {
            throw new NotImplementedException();
        }

        public Task RemoveOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveSubElementFromOrderAsync(int orderedSubElementId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveWindowFromOrderAsync(int orderedWindowId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOderAsync(OrderUpdateDTO orderUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
