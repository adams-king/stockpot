using Stockpot.BusinessLogic.RecipeIngredients;
using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stockpot.BusinessLogic.Recipes
{
    public class RecipesService
        : ServiceBaseSimple<RecipesRepository, Recipe, int, RecipeDto, CreateUpdateRecipeDto>
    {
        private readonly RecipesDtoMapper _recipesDtoMapper;
        private readonly RecipeIngredientsDtoMapper _recipeIngredientsDtoMapper;
        private readonly IngredientsRepository _ingredientsRepository;
        private readonly TagsRepository _tagsRepository;

        public RecipesService(
            DbContextProvider dbContextProvider,
            RecipesDtoMapper recipesDtoMapper,
            RecipeIngredientsDtoMapper recipeIngredientsDtoMapper,
            RecipesRepository recipesRepository,
            IngredientsRepository ingredientsRepository,
            TagsRepository tagsRepository)
            : base(dbContextProvider, recipesRepository)
        {
            _recipesDtoMapper = recipesDtoMapper;
            _recipeIngredientsDtoMapper = recipeIngredientsDtoMapper;
            _ingredientsRepository = ingredientsRepository;
            _tagsRepository = tagsRepository;
        }

        protected override DtoMapperSimple<Recipe, RecipeDto, CreateUpdateRecipeDto> DtoMapperSimple
            => _recipesDtoMapper;

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
        public async Task<int> AddIngredient(int recipeId, CreateRecipeIngredientDto createRecipeIngredient)
        {
            var recipeIngredient = _recipeIngredientsDtoMapper.CreateEntity(createRecipeIngredient);
            recipeIngredient.RecipeId = recipeId;

            Repository.AddIngredient(recipeIngredient);

            return await DbContextProvider.SaveChangesAsync();
        }

        public async Task<int> UpdateIngredient(int recipeId, int ingredientId, UpdateRecipeIngredientDto updateRecipeIngredientDto)
        {
            var recipeIngredient = await Repository.GetIngredient(recipeId, ingredientId, true);

            if (recipeIngredient != null)
            {
                _recipeIngredientsDtoMapper.UpdateEntity(recipeIngredient, updateRecipeIngredientDto);
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
