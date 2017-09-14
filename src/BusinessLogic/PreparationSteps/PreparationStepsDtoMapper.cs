using Stockpot.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stockpot.BusinessLogic.PreparationSteps
{
    public class PreparationStepsDtoMapper : IDtoMapper<PreparationStep, PreparationStepDto>
    {
        public IEnumerable<PreparationStepDto> ToDto(IEnumerable<PreparationStep> entities)
        {
            return entities.Select(e => ToDto(e));
        }

        public PreparationStepDto ToDto(PreparationStep entity)
        {
            return new PreparationStepDto
            {
                Id = entity.Id,
                Order = entity.Order,
                Description = entity.Description,
                RecipeId = entity.RecipeId
            };
        }

        public PreparationStep ToEntity(PreparationStepDto dto)
        {
            var entity = new PreparationStep();
            UpdateEntity(entity, dto);
            return entity;
        }

        public void UpdateEntity(PreparationStep entity, PreparationStepDto dto)
        {
            entity.Order = dto.Order;
            entity.Description = dto.Description;
            entity.RecipeId = dto.RecipeId;
        }
    }
}
