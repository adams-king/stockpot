using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stockpot.DataAccess.Entities
{
    public class Recipe : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public ICollection<PreparationStep> PreparationSteps { get; set; }

        public ICollection<RecipeTag> RecipeTags { get; set; }
    }
}