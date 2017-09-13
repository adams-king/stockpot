using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Repositories;

namespace Stockpot.BusinessLogic.Ingredients
{
    public class IngredientsService : ServiceBase<IngredientsRepository, Ingredient, IngredientDto, int>
    {
        private readonly IngredientsDtoMapper _ingredientsDtoMapper;

        public IngredientsService(
            DbContextProvider dbContextProvider,
            IngredientsDtoMapper ingredientsDtoMapper,
            IngredientsRepository ingredientsRepository)
            : base(dbContextProvider, ingredientsRepository)
        {
            _ingredientsDtoMapper = ingredientsDtoMapper;
        }

        protected override IDtoMapper<Ingredient, IngredientDto> DtoMapper => _ingredientsDtoMapper;
    }
}
