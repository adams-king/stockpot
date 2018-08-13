using Microsoft.AspNetCore.Mvc;
using Stockpot.BusinessLogic.RecipeIngredients;
using Stockpot.BusinessLogic.Recipes;
using System.Threading.Tasks;

namespace Stockpot.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;

        public RecipesController(
            RecipesService recipeService)
        {
            _recipesService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recipes = await _recipesService.GetFull();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var recipe = await _recipesService.GetFull(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpGet("bytag/{tagId}")]
        public async Task<IActionResult> GetByTag(int tagId)
        {
            var recipes = await _recipesService.GetByTag(tagId);
            return Ok(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateRecipeDto createDto)
        {
            var dto = await _recipesService.AddFull(createDto);
            return NoContent();
        }

        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UpdateRecipeDto updateDto)
        {
            var changes = await _recipesService.Update(id, updateDto);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        */

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var changes = await _recipesService.Delete(id);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        /*
         * Ingredients
         */
        /*
        [HttpPost("{id}/ingredient/add")]
        public async Task<IActionResult> AddIngredient(int id, [FromBody]CreateRecipeIngredientDto createDto)
        {
            await _recipesService.AddIngredient(id, createDto);

            return NoContent();
        }

        [HttpPut("{id}/ingredient/update/{ingredientId}")]
        public async Task<IActionResult> UpdateIngredient(int id, int ingredientId, [FromBody]UpdateRecipeIngredientDto updateDto)
        {
            var changes = await _recipesService.UpdateIngredient(id, ingredientId, updateDto);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}/ingredient/delete/{ingredientId}")]
        public async Task<IActionResult> DeleteIngredient(int id, int ingredientId)
        {
            var changes = await _recipesService.DeleteIngredient(id, ingredientId);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        */

        /*
        * Tags
        */
        /*
        [HttpPost("{id}/tag/add/{tagId}")]
        public async Task<IActionResult> AddTag(int id, int tagId)
        {
            await _recipesService.AddTag(id, tagId);

            return NoContent();
        }

        [HttpDelete("{id}/tag/delete/{tagId}")]
        public async Task<IActionResult> DeleteTag(int id, int tagId)
        {
            var changes = await _recipesService.DeleteTag(id, tagId);

            if (changes == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
        */
    }
}
