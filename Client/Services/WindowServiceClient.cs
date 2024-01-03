using System.Net.Http.Json;
using WindowStore.Shared.Window;

namespace WindowStore.Client.Services
{
    public class WindowServiceClient(HttpClient httpClient) : IWindowServiceClient
    {
        public async Task<WindowDTO?> CreateWindowAsync(WindowCreateDTO windowDto)
        {
            var response = await httpClient.PostAsJsonAsync("/api/windows", windowDto);

            return await response.Content.ReadFromJsonAsync<WindowDTO>();
        }

        public async Task<int> GetOrdersCountByWindowIdAsync(int windowId)
        {
            return await httpClient.GetFromJsonAsync<int>($"/api/windows/ordersCount/{windowId}");
        }

        public async Task<List<WindowDTO>?> GetWindowsAsync()
        {
            return await httpClient.GetFromJsonAsync<List<WindowDTO>>("/api/windows/all");
        }

        public async Task<bool> RemoveWindowAsync(int windowId)
        {
            var response = await httpClient.DeleteAsync($"/api/windows/{windowId}");

            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}
