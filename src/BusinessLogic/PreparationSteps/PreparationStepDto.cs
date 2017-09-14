namespace Stockpot.BusinessLogic.PreparationSteps
{
    public class PreparationStepDto : UpdatePreparationStepDto
    {
        public int Id { get; set; }

        public byte Order { get; set; }
    }

    public class CreatePreparationStepDto : UpdatePreparationStepDto
    {
        public int RecipeId { get; set; }
    }

    public class UpdatePreparationStepDto
    {
        public string Description { get; set; }
    }
}
