using System.ComponentModel.DataAnnotations;

namespace Stockpot.BusinessLogic.Ingredients
{
    public class IngredientDto : CreateUpdateIngredientDto
    {
        public int Id { get; set; }
    }

    public class CreateUpdateIngredientDto
    {
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
