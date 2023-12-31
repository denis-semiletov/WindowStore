﻿using WindowStore.Shared.Window;

namespace WindowsStore.BLL.Interfaces
{
    public interface IWindowService
    {
        Task<List<WindowDTO>> GetWindowsAsync();
        Task<WindowDTO> CreateWindowAsync(WindowCreateDTO windowDto);
        Task<bool> RemoveWindowAsync(int windowId);
        Task<int> GetOrdersCountByWindowIdAsync(int windowId);
    }
}
