using Stockpot.DataAccess.Entities;

namespace Stockpot.BusinessLogic.RecipeIngredients
{
    public class RecipeIngredientsDtoMapper
        : DtoMapper<RecipeIngredient, RecipeIngredientDto, CreateRecipeIngredientDto, UpdateRecipeIngredientDto>
    {
        internal override RecipeIngredient CreateEntity(CreateRecipeIngredientDto createDto)
        {
            return new RecipeIngredient
            {
                IngredientId = createDto.IngredientId,
                Amount = createDto.Amount,
                Unit = createDto.Unit
            };
        }

        internal override RecipeIngredientDto ToDto(RecipeIngredient entity)
        {
            return new RecipeIngredientDto
            {
                IngredientId = entity.Ingredient.Id,
                IngredientName = entity.Ingredient.Name,
                Amount = entity.Amount,
                Unit = entity.Unit
            };
        }

        internal override void UpdateEntity(RecipeIngredient entity, UpdateRecipeIngredientDto updateDto)
        {
            entity.Amount = updateDto.Amount;
            entity.Unit = updateDto.Unit;
        }
    }
}
