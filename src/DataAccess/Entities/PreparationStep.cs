using System.ComponentModel.DataAnnotations;

namespace Stockpot.DataAccess.Entities
{
    public class PreparationStep : IEntity<int>
    {
        public int Id { get; set; }

        public byte Order { get; set; }

        [Required]
        public string Description { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
