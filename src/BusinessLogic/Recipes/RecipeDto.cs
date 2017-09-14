using Stockpot.BusinessLogic.PreparationSteps;
using Stockpot.BusinessLogic.RecipeIngredients;
using Stockpot.BusinessLogic.RecipeTags;
using System.ComponentModel.DataAnnotations;

namespace Stockpot.BusinessLogic.Recipes
{
    public class RecipeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }

    public class RecipeDtoFull : RecipeDto
    {
        public RecipeIngredientDto[] Ingredients { get; set; }

        public PreparationStepDto[] PreparationSteps { get; set; }

        public RecipeTagDto[] Tags { get; set; }
    }
}