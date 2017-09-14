using Microsoft.EntityFrameworkCore;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Extentions;
using System.Linq;
using System.Threading.Tasks;

namespace Stockpot.DataAccess.Repositories
{
    public class RecipesRepository : RepositoryBase<Recipe, int>
    {
        public RecipesRepository(DbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Recipe[]> GetFull()
        {
            return await GetDbSet()
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.PreparationSteps)
                .Include(r => r.RecipeTags)
                .ThenInclude(rt => rt.Tag)
                .ToArrayAsync();
        }

        public async Task<Recipe> GetFull(int id)
        {
            return await GetDbSet()
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.PreparationSteps)
                .Include(r => r.RecipeTags)
                .ThenInclude(rt => rt.Tag)
                .Where(r => r.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<Recipe[]> GetByTag(int tagId)
        {
            // TODO: Resulting query is not optimal
            return await GetDbSet()
                .Where(r => r.RecipeTags.Any(rt => rt.TagId == tagId))
                .ToArrayAsync();
        }

        /*
        * Ingredients
        */
        public async Task<RecipeIngredient> GetIngredient(int recipeId, int ingredientId, bool tracked = false)
        {
            return await DbContext.RecipeIngredients
                .Where(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId)
                .SetTracking(tracked)
                .SingleOrDefaultAsync();
        }

        public void AddIngredient(RecipeIngredient recipeIngredient)
        {
            DbContext.RecipeIngredients.Add(recipeIngredient);
        }

        public void DeleteIngredient(RecipeIngredient recipeIngredient)
        {
            DbContext.RecipeIngredients.Remove(recipeIngredient);
        }

        /*
        * Tags
        */
        public async Task<RecipeTag> GetTag(int recipeId, int tagId, bool tracked = false)
        {
            return await DbContext.RecipeTags
                .Where(ri => ri.RecipeId == recipeId && ri.TagId == tagId)
                .SetTracking(tracked)
                .SingleOrDefaultAsync();
        }

        public void AddTag(RecipeTag recipeTag)
        {
            DbContext.RecipeTags.Add(recipeTag);
        }

        public void DeleteTag(RecipeTag recipeTag)
        {
            DbContext.RecipeTags.Remove(recipeTag);
        }
    }
}
