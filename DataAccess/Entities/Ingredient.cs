using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stockpot.DataAccess.Entities
{
    public class Ingredient : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}