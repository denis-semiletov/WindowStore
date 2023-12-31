using WindowStore.Shared.Window;

namespace WindowsStore.BLL.Interfaces
{
    public interface IWindowService
    {
        Task<List<WindowDTO>> GetWindowsAsync();
        Task<WindowDTO> CreateWindowAsync(WindowCreateDTO windowDto);
        Task RemoveWindowAsync(int windowId);
    }
}
