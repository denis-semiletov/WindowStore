using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WindowsStore.BLL.Interfaces;
using WindowsStore.DAL;
using WindowsStore.DAL.Window;
using WindowStore.Shared.Window;

namespace WindowsStore.BLL.Services
{
    public class WindowService(BlazorWindowStoreContext context) : IWindowService
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();

        public async Task<List<WindowDTO>> GetWindowsAsync()
        {
            var windows = await context.Windows
                .OrderBy(o => o.WindowName)
                .ToListAsync();

            var result = _mapper.Map<List<WindowDTO>>(windows);

            return result;
        }

        public async Task<WindowDTO> CreateWindowAsync(WindowCreateDTO windowDto)
        {
            var window = _mapper.Map<Window>(windowDto);

            await context.Windows.AddAsync(window);

            await context.SaveChangesAsync();

            var dto = _mapper.Map<WindowDTO>(window);

            return dto;
        }

        public async Task<bool> RemoveWindowAsync(int windowId)
        {
            var window = await context.Windows.FindAsync(windowId)
                ?? throw new KeyNotFoundException($"Window with WindowId = {windowId} not found for remove action");

            context.Windows.Remove(window);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<int> GetOrdersCountByWindowIdAsync(int windowId)
        {
            var count = await context.Orders.Include(r => r.OrderedWindows).CountAsync(o => o.OrderedWindows.Any(w => w.WindowId == windowId));

            return count;
        }
    }
}
