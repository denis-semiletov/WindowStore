using Microsoft.AspNetCore.Mvc;
using WindowsStore.BLL.Interfaces;
using WindowStore.Shared.Window;

namespace WindowStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowsController(IWindowService windowService) : ControllerBase
    {
        private readonly IWindowService _windowService = windowService;

        [HttpGet]
        [Route("all")]
        public async Task<List<WindowDTO>> GetWidows()
        {
            var orders = await _windowService.GetWindowsAsync();

            return orders;
        }

        [HttpPost]
        [Route("")]
        public async Task<WindowDTO> CreateWindowAsync(WindowCreateDTO windowCreateDTO)
        {
            var newWindow = await _windowService.CreateWindowAsync(windowCreateDTO);

            return newWindow;
        }

        [HttpDelete]
        [Route("{windowId:int}")]
        public async Task<bool> RemoveWindowAsync(int windowId)
        {
            var result = await _windowService.RemoveWindowAsync(windowId);

            return result;
        }
    }
}
