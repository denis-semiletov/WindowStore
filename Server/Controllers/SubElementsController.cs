using Microsoft.AspNetCore.Mvc;
using WindowsStore.BLL.Interfaces;
using WindowStore.Shared.SubElement;

namespace WindowStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubElementsController(ISubElementService subElementService) : ControllerBase
    {
        private readonly ISubElementService _subElementService = subElementService;

        [HttpGet]
        [Route("All")]
        public async Task<List<SubElementDTO>> GetSubElements()
        {
            var subElements = await _subElementService.GetSubElements();

            return subElements;
        }

        [HttpPost]
        [Route("")]
        public async Task<SubElementDTO> CreateSubElementAsync(SubElementCreateDTO subElementCreateDTO)
        {
            var newWindow = await _subElementService.CreateSubElementAsync(subElementCreateDTO);

            return newWindow;
        }

        [HttpPut]
        [Route("")]
        public async Task<SubElementDTO> UpdateSubElementAsync(SubElementUpdateDTO subElementUpdateDTO)
        {
            var subElement = await _subElementService.UpdateSubElementAsync(subElementUpdateDTO);

            return subElement;
        }

        [HttpDelete]
        [Route("{subElementId:int}")]
        public async Task<bool> RemoveSubElementAsync(int subElementId)
        {
            var result = await _subElementService.SubElementRemoveAsync(subElementId);

            return result;
        }
    }
}
