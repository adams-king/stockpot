using Microsoft.AspNetCore.Mvc;
using Stockpot.BusinessLogic.Tags;
using System.Threading.Tasks;

namespace Stockpot.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly TagsService _tagsService;

        public TagsController(
            TagsService tagsService)
        {
            _tagsService = tagsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ingredients = await _tagsService.Get();
            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUpdateTagDto dto)
        {
            await _tagsService.Add(dto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]CreateUpdateTagDto dto)
        {
            var changes = await _tagsService.Update(id, dto);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var changes = await _tagsService.Delete(id);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
