using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Repositories;
using System.Threading.Tasks;

namespace Stockpot.BusinessLogic.PreparationSteps
{
    public class PreparationStepsService : ServiceBase<PreparationStepsRepository, PreparationStep, PreparationStepDto, int>
    {
        private readonly PreparationStepsDtoMapper _preparationStepsDtoMapper;

        public PreparationStepsService(
            DbContextProvider dbContextProvider,
            PreparationStepsDtoMapper preparationStepDtoMapper,
            PreparationStepsRepository preparationStepsRepository)
            : base(dbContextProvider, preparationStepsRepository)
        {
            _preparationStepsDtoMapper = preparationStepDtoMapper;
        }

        protected override IDtoMapper<PreparationStep, PreparationStepDto> DtoMapper => _preparationStepsDtoMapper;

        public override async Task<int> Add(PreparationStepDto dto)
        {
            // Override the order given in the dto
            var maxOder = await Repository.GetMaxOrder(dto.RecipeId);
            dto.Order = (byte)(maxOder + 1);

            return await base.Add(dto);
        }

        public async Task<int> SwitchOrder(int fromId, int toId)
        {
            // Get from and to entities
            var from = await Repository.GetSingleOrDefault(fromId, true);
            var to = await Repository.GetSingleOrDefault(toId, true);

            // Return 0 when any of the entities does not exist
            if (from == null || to == null)
            {
                return 0;
            }

            var changes = 0;

            var fromOrder = from.Order;
            var toOrder = to.Order;

            // Switch the order
            to.Order = 0;
            changes = changes + await DbContextProvider.SaveChangesAsync();

            from.Order = toOrder;
            to.Order = fromOrder;

            changes = changes + await DbContextProvider.SaveChangesAsync();

            return changes;
        }
    }
}
