using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Repositories;
using System.Threading.Tasks;

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

        public async Task<IngredientDto> GetOrCreate(string name)
        {
            var ingredient = await Repository.GetByName(name);

            if (ingredient == null)
            {
                var newIngredient = new Ingredient
                {
                    Name = name
                };

                Repository.Add(newIngredient);

                await DbContextProvider.SaveChangesAsync();

                ingredient = await Repository.GetSingle(newIngredient.Id);
            }

            var ingredientDto = DtoMapper.ToDto(ingredient);

            return ingredientDto;
        }
    }
}
