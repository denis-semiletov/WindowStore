using WindowStore.Shared.Window;

namespace WindowStore.Client.Services
{
    public interface IWindowServiceClient
    {
        Task<List<WindowDTO>?> GetWindowsAsync();
        Task<WindowDTO?> CreateWindowAsync(WindowCreateDTO windowDto);
        Task<bool> RemoveWindowAsync(int windowId);
        Task<int> GetOrdersCountByWindowIdAsync(int windowId);
    }
}
