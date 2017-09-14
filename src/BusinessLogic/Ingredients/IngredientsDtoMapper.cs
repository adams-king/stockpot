using Stockpot.DataAccess.Entities;

namespace Stockpot.BusinessLogic.Ingredients
{
    public class IngredientsDtoMapper
        : DtoMapperSimple<Ingredient, IngredientDto, CreateUpdateIngredientDto>
    {
        internal override IngredientDto ToDto(Ingredient entity)
        {
            return new IngredientDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        internal override void UpdateEntity(Ingredient entity, CreateUpdateIngredientDto updateDto)
        {
            entity.Name = updateDto.Name;
        }
    }
}
