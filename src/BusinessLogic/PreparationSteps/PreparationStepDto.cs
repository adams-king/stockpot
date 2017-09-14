namespace Stockpot.BusinessLogic.PreparationSteps
{
    public class PreparationStepDto
    {
        public int Id { get; set; }

        public byte Order { get; set; }

        public string Description { get; set; }

        public int RecipeId { get; set; }
    }
}
