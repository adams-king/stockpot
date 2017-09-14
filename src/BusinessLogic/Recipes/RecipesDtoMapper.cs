using Stockpot.BusinessLogic.PreparationSteps;
using Stockpot.BusinessLogic.RecipeIngredients;
using Stockpot.BusinessLogic.RecipeTags;
using Stockpot.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stockpot.BusinessLogic.Recipes
{
    public class RecipesDtoMapper
        : DtoMapperSimple<Recipe, RecipeDto, CreateUpdateRecipeDto>
    {
        private readonly RecipeIngredientsDtoMapper _recipeIngredientsDtoMapper;
        private readonly PreparationStepsDtoMapper _preparationStepsDtoMapper;
        private readonly RecipeTagsDtoMapper _recipeTagsDtoMapper;

        public RecipesDtoMapper(
            RecipeIngredientsDtoMapper recipeIngredientsDtoMapper,
            PreparationStepsDtoMapper preparationStepsDtoMapper,
            RecipeTagsDtoMapper recipeTagsDtoMapper)
        {
            _recipeIngredientsDtoMapper = recipeIngredientsDtoMapper;
            _preparationStepsDtoMapper = preparationStepsDtoMapper;
            _recipeTagsDtoMapper = recipeTagsDtoMapper;
        }

        internal override RecipeDto ToDto(Recipe entity)
        {
            var dto = new RecipeDto();
            UpdateDto(dto, entity);
            return dto;
        }

        internal override void UpdateEntity(Recipe entity, CreateUpdateRecipeDto updateDto)
        {
            entity.Name = updateDto.Name;
            entity.Description = updateDto.Description;
        }

        public IEnumerable<RecipeDtoFull> ToDtoFull(IEnumerable<Recipe> entities)
        {
            return entities.Select(e => ToDtoFull(e));
        }

        public RecipeDtoFull ToDtoFull(Recipe entity)
        {
            var dto = new RecipeDtoFull();
            UpdateDto(dto, entity);
            dto.Ingredients = _recipeIngredientsDtoMapper.ToDto(entity.RecipeIngredients).ToArray();
            dto.PreparationSteps = _preparationStepsDtoMapper
                .ToDto(entity.PreparationSteps.OrderBy(ps => ps.Order))
                .ToArray();
            dto.Tags = _recipeTagsDtoMapper.ToDto(entity.RecipeTags).ToArray();
            return dto;
        }

        public void UpdateDto(RecipeDto dto, Recipe entity)
        {
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
        }
    }
}
