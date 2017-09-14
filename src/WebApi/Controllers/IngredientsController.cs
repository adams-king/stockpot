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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUpdateIngredientDto dto)
        {
            await _ingredientsService.Add(dto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]CreateUpdateIngredientDto dto)
        {
            var changes = await _ingredientsService.Update(id, dto);

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
