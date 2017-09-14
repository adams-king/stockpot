using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Repositories;

namespace Stockpot.BusinessLogic.Ingredients
{
    public class IngredientsService
        : ServiceBaseSimple<IngredientsRepository, Ingredient, int, IngredientDto, CreateUpdateIngredientDto>
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

        protected override DtoMapperSimple<Ingredient, IngredientDto, CreateUpdateIngredientDto> DtoMapperSimple
            => _ingredientsDtoMapper;
    }
}
