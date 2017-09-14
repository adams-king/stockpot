using Stockpot.BusinessLogic.RecipeIngredients;
using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stockpot.BusinessLogic.Recipes
{
    public class RecipesService : ServiceBase<RecipesRepository, Recipe, RecipeDto, int>
    {
        private readonly IngredientsRepository _ingredientsRepository;
        private readonly TagsRepository _tagsRepository;
        private readonly RecipesDtoMapper _recipesDtoMapper;

        public RecipesService(
            DbContextProvider dbContextProvider,
            RecipesDtoMapper recipesDtoMapper,
            RecipesRepository recipesRepository,
            IngredientsRepository ingredientsRepository,
            TagsRepository tagsRepository)
            : base(dbContextProvider, recipesRepository)
        {
            _recipesDtoMapper = recipesDtoMapper;
            _ingredientsRepository = ingredientsRepository;
            _tagsRepository = tagsRepository;
        }

        protected override IDtoMapper<Recipe, RecipeDto> DtoMapper => _recipesDtoMapper;

        public async Task<IEnumerable<RecipeDtoFull>> GetFull()
        {
            var recipes = await Repository.GetFull();
            var dto = _recipesDtoMapper.ToDtoFull(recipes);
            return dto;
        }

        public async Task<RecipeDtoFull> GetFull(int id)
        {
            var recipe = await Repository.GetFull(id);
            var dto = _recipesDtoMapper.ToDtoFull(recipe);
            return dto;
        }

        public async Task<IEnumerable<RecipeDto>> GetByTag(int tagId)
        {
            var recipes = await Repository.GetByTag(tagId);
            var dto = _recipesDtoMapper.ToDto(recipes);
            return dto;
        }

        /*
        * Ingredients
        */
        public async Task<int> AddIngredient(int recipeId, AddRecipeIngredientDto addRecipeIngredient)
        {
            var recipe = await Repository.GetSingle(recipeId, true);
            var ingredient = await _ingredientsRepository.GetSingle(addRecipeIngredient.IngredientId, true);

            var recipeIngredient = new RecipeIngredient
            {
                Recipe = recipe,
                Ingredient = ingredient,
                Amount = addRecipeIngredient.Amount,
                Unit = addRecipeIngredient.Unit
            };

            Repository.AddIngredient(recipeIngredient);

            return await DbContextProvider.SaveChangesAsync();
        }

        public async Task<int> UpdateIngredient(int recipeId, int ingredientId, UpdateRecipeIngredientDto updateRecipeIngredientDto)
        {
            var recipeIngredient = await Repository.GetIngredient(recipeId, ingredientId, true);

            if (recipeIngredient != null)
            {
                recipeIngredient.Amount = updateRecipeIngredientDto.Amount;
                recipeIngredient.Unit = updateRecipeIngredientDto.Unit;
            }

            return await DbContextProvider.SaveChangesAsync();
        }

        public async Task<int> DeleteIngredient(int recipeId, int ingredientId)
        {
            var recipeIngredient = await Repository.GetIngredient(recipeId, ingredientId, true);

            if (recipeIngredient != null)
            {
                Repository.DeleteIngredient(recipeIngredient);
            }

            return await DbContextProvider.SaveChangesAsync();
        }

        /*
        * Tags
        */
        public async Task<int> AddTag(int recipeId, int tagId)
        {
            var recipe = await Repository.GetSingle(recipeId, true);
            var tag = await _tagsRepository.GetSingle(tagId, true);

            var recipeTag = new RecipeTag
            {
                Recipe = recipe,
                Tag = tag
            };

            Repository.AddTag(recipeTag);

            return await DbContextProvider.SaveChangesAsync();
        }

        public async Task<int> DeleteTag(int recipeId, int tagId)
        {
            var recipeTag = await Repository.GetTag(recipeId, tagId, true);

            if (recipeTag != null)
            {
                Repository.DeleteTag(recipeTag);
            }

            return await DbContextProvider.SaveChangesAsync();
        }
    }
}
