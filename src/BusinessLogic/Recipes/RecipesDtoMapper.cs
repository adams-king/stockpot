using Stockpot.BusinessLogic.PreparationSteps;
using Stockpot.BusinessLogic.RecipeIngredients;
using Stockpot.BusinessLogic.RecipeTags;
using Stockpot.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stockpot.BusinessLogic.Recipes
{
    public class RecipesDtoMapper : IDtoMapper<Recipe, RecipeDto>
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

        public IEnumerable<RecipeDtoFull> ToDtoFull(IEnumerable<Recipe> entities)
        {
            return entities.Select(e => ToDtoFull(e));
        }

        public RecipeDtoFull ToDtoFull(Recipe entity)
        {
            var dto = new RecipeDtoFull();
            UpdateDto(dto, entity);
            dto.Ingredients = _recipeIngredientsDtoMapper.ToDto(entity.RecipeIngredients).ToArray();
            dto.PreparationSteps = _preparationStepsDtoMapper.ToDto(entity.PreparationSteps).ToArray();
            dto.Tags = _recipeTagsDtoMapper.ToDto(entity.RecipeTags).ToArray();
            return dto;
        }

        public IEnumerable<RecipeDto> ToDto(IEnumerable<Recipe> entities)
        {
            return entities.Select(e => ToDto(e));
        }

        public RecipeDto ToDto(Recipe entity)
        {
            var dto = new RecipeDto();
            UpdateDto(dto, entity);
            return dto;
        }

        public void UpdateDto(RecipeDto dto, Recipe entity)
        {
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Description = entity.Description;
        }

        public Recipe ToEntity(RecipeDto dto)
        {
            var entity = new Recipe();
            UpdateEntity(entity, dto);
            return entity;
        }

        public void UpdateEntity(Recipe entity, RecipeDto dto)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
        }
    }
}
