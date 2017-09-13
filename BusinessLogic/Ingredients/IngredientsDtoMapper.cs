using Stockpot.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stockpot.BusinessLogic.Ingredients
{
    public class IngredientsDtoMapper : IDtoMapper<Ingredient, IngredientDto>
    {
        public IEnumerable<IngredientDto> ToDto(IEnumerable<Ingredient> entities)
        {
            return entities.Select(e => ToDto(e));
        }

        public IngredientDto ToDto(Ingredient entity)
        {
            return new IngredientDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public Ingredient ToEntity(IngredientDto dto)
        {
            var entity = new Ingredient();
            UpdateEntity(entity, dto);
            return entity;
        }

        public void UpdateEntity(Ingredient entity, IngredientDto dto)
        {
            entity.Name = dto.Name;
        }
    }
}
