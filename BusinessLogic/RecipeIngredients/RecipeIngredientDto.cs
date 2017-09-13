using Stockpot.DataAccess.Entities.Enums;

namespace Stockpot.BusinessLogic.RecipeIngredients
{
    public class RecipeIngredientDto
    {
        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public float Amount { get; set; }

        public Unit Unit { get; set; }
    }

    public class NewRecipeIngredientDto
    {
        public int IngredientId { get; set; }

        public float Amount { get; set; }

        public Unit Unit { get; set; }
    }

    public class UpdateRecipeIngredientDto
    {
        public float Amount { get; set; }

        public Unit Unit { get; set; }
    }
}