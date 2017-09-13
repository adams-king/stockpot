using Stockpot.DataAccess.Entities.Enums;

namespace Stockpot.DataAccess.Entities
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        public float Amount { get; set; }

        public Unit Unit { get; set; }
    }
}
