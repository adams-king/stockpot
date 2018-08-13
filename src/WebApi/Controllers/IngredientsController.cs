using Microsoft.AspNetCore.Mvc;
using Stockpot.BusinessLogic.Ingredients;
using System.Threading.Tasks;

namespace Stockpot.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;

        public IngredientsController(
            IngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ingredients = await _ingredientsService.Get();
            return Ok(ingredients);
        }

        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ingredient = await _ingredientsService.GetSingleOrDefault(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUpdateIngredientDto createDto)
        {
            var dto = await _ingredientsService.Add(createDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]CreateUpdateIngredientDto updateDto)
        {
            var changes = await _ingredientsService.Update(id, updateDto);

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
        */
    }
}
