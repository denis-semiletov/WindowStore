using System.Net.Http.Json;
using WindowStore.Shared.Order;
using WindowStore.Shared.OrderedWindow;
using WindowStore.Shared.OrderedWindowSubElement;

namespace WindowStore.Client.Services
{
    public class OrderServiceClient(HttpClient httpClient) : IOrderServiceClient
    {
        public async Task<OrderedWindowSubElementDTO?> AddSubElementToOrderAsync(AddSubElementToOrderedWindowDTO addSubElementToOrderedWindowDTO)
        {
            var response = await httpClient.PostAsJsonAsync("/api/orders/subElement", addSubElementToOrderedWindowDTO);

            return await response.Content.ReadFromJsonAsync<OrderedWindowSubElementDTO>();
        }

        public async Task<OrderedWindowDTO?> AddWindowToOrderAsync(AddWindowToOrderDTO addWindowToOrderDTO)
        {
            var response = await httpClient.PostAsJsonAsync("/api/orders/window", addWindowToOrderDTO);

            return await response.Content.ReadFromJsonAsync<OrderedWindowDTO>();
        }

        public async Task<OrderDTO?> CreateOrderAsync(OrderCreateDTO orderCreteDTO)
        {
            var response = await httpClient.PostAsJsonAsync("/api/orders", orderCreteDTO);

            return await response.Content.ReadFromJsonAsync<OrderDTO>();
        }

        public async Task<IEnumerable<OrderDTO>?> GetOrders()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<OrderDTO>>("/api/orders/all");
        }

        public async Task<bool> RemoveOrderAsync(int orderId)
        {
            var response = await httpClient.DeleteAsync($"/api/orders/{orderId}");

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> RemoveSubElementFromOrderAsync(int orderedSubElementId)
        {
            var response = await httpClient.DeleteAsync($"/api/orders/subElement{orderedSubElementId}");

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> RemoveWindowFromOrderAsync(int orderedWindowId)
        {
            var response = await httpClient.DeleteAsync($"/api/orders/window{orderedWindowId}");

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<OrderDTO?> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO)
        {
            var response = await httpClient.PutAsJsonAsync("/api/orders", orderUpdateDTO);

            return await response.Content.ReadFromJsonAsync<OrderDTO>();
        }
    }
}
