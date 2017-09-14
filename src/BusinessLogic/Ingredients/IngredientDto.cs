namespace Stockpot.BusinessLogic.Ingredients
{
    public class IngredientDto : CreateUpdateIngredientDto
    {
        public int Id { get; set; }
    }

    public class CreateUpdateIngredientDto
    {
        public string Name { get; set; }
    }
}
