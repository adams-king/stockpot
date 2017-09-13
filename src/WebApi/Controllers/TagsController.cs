using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stockpot.BusinessLogic.Tags;
using System.Threading.Tasks;

namespace Stockpot.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly TagsService _tagsService;
        private readonly ILogger<TagsController> _logger;

        public TagsController(
            TagsService tagsService,
            ILogger<TagsController> logger)
        {
            _tagsService = tagsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ingredients = await _tagsService.Get();
            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TagDto tagDto)
        {
            await _tagsService.Add(tagDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]TagDto tagDto)
        {
            var changes = await _tagsService.Update(id, tagDto);

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
