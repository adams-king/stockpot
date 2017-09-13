using Stockpot.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stockpot.BusinessLogic.RecipeIngredients
{
    public class RecipeIngredientsDtoMapper : IDtoMapper<RecipeIngredient, RecipeIngredientDto>
    {
        public IEnumerable<RecipeIngredientDto> ToDto(IEnumerable<RecipeIngredient> entities)
        {
            return entities.Select(e => ToDto(e));
        }

        public RecipeIngredientDto ToDto(RecipeIngredient entity)
        {
            return new RecipeIngredientDto
            {
                IngredientId = entity.Ingredient.Id,
                IngredientName = entity.Ingredient.Name,
                Amount = entity.Amount,
                Unit = entity.Unit
            };
        }

        public RecipeIngredient ToEntity(RecipeIngredientDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEntity(RecipeIngredient entity, RecipeIngredientDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
