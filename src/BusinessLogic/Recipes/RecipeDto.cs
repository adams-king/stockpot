using Stockpot.BusinessLogic.PreparationSteps;
using Stockpot.BusinessLogic.RecipeIngredients;
using Stockpot.BusinessLogic.RecipeTags;
using Stockpot.DataAccess.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Stockpot.BusinessLogic.Recipes
{
    public class CreateRecipeDto
    {
        public class IngredientDto
        {
            [Required]
            public string Name { get; set; }

            [Required]
            public float Amount { get; set; }

            [Required]
            public Unit Unit { get; set; }
        }

        public class PreparationStepDto
        {
            [Required]
            public string Description { get; set; }
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [MinLength(1)]
        public IngredientDto[] Ingredients { get; set; }

        [MinLength(1)]
        public PreparationStepDto[] PreparationSteps { get; set; }
    }

    public class RecipeDto : CreateUpdateRecipeDto
    {
        public int Id { get; set; }
    }

    public class CreateUpdateRecipeDto
    {
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
