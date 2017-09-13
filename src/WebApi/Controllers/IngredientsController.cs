using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stockpot.BusinessLogic.Ingredients;
using System.Threading.Tasks;

namespace Stockpot.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;
        private readonly ILogger<IngredientsController> _logger;

        public IngredientsController(
            IngredientsService ingredientsService,
            ILogger<IngredientsController> logger)
        {
            _ingredientsService = ingredientsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ingredients = await _ingredientsService.Get();
            return Ok(ingredients);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IngredientDto ingredientDto)
        {
            await _ingredientsService.Add(ingredientDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]IngredientDto ingredientDto)
        {
            var changes = await _ingredientsService.Update(id, ingredientDto);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var changes = await _ingredientsService.Delete(id);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
