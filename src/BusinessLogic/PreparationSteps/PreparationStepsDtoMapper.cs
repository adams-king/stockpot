using Stockpot.DataAccess.Entities;

namespace Stockpot.BusinessLogic.PreparationSteps
{
    public class PreparationStepsDtoMapper
        : DtoMapper<PreparationStep, PreparationStepDto, CreatePreparationStepDto, UpdatePreparationStepDto>
    {
        internal override PreparationStep CreateEntity(CreatePreparationStepDto createDto)
        {
            return new PreparationStep
            {
                Description = createDto.Description,
                RecipeId = createDto.RecipeId
            };
        }

        internal override PreparationStepDto ToDto(PreparationStep entity)
        {
            return new PreparationStepDto
            {
                Id = entity.Id,
                Order = entity.Order,
                Description = entity.Description
            };
        }

        internal override void UpdateEntity(PreparationStep entity, UpdatePreparationStepDto updateDto)
        {
            entity.Description = updateDto.Description;
        }
    }
}
