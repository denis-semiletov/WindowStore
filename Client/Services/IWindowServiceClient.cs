using WindowStore.Shared.Window;

namespace WindowStore.Client.Services
{
    public interface IWindowServiceClient
    {
        Task<IEnumerable<WindowDTO>?> GetWindowsAsync();
        Task<WindowDTO?> CreateWindowAsync(WindowCreateDTO windowDto);
        Task<bool> RemoveWindowAsync(int windowId);
    }
}
