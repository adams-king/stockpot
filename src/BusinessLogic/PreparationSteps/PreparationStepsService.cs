using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace Stockpot.BusinessLogic.PreparationSteps
{
    public class PreparationStepsService
        : ServiceBase<PreparationStepsRepository, PreparationStep, int, PreparationStepDto, CreatePreparationStepDto, UpdatePreparationStepDto>
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

        protected override DtoMapper<PreparationStep, PreparationStepDto, CreatePreparationStepDto, UpdatePreparationStepDto> DtoMapper
            => _preparationStepsDtoMapper;

        public override async Task<int> Add(CreatePreparationStepDto createDto)
        {
            var preparationStep = DtoMapper.CreateEntity(createDto);
            var maxOder = await Repository.GetMaxOrder(createDto.RecipeId);
            preparationStep.Order = (byte)(maxOder + 1);

            Repository.Add(preparationStep);
            return await DbContextProvider.SaveChangesAsync();
        }

        public override async Task<int> Delete(int id)
        {
            var toDelete = await Repository.GetSingleOrDefault(id);

            if (toDelete == null)
            {
                return 0;
            }

            var changes = await base.Delete(id);

            // Update order of other preperation steps
            var preparationSteps = await Repository.GetByRecipe(toDelete.RecipeId, true);

            for (int i = 0; i < preparationSteps.Length; i++)
            {
                preparationSteps[i].Order = (byte)(i + 1);
            }

            changes = changes + await DbContextProvider.SaveChangesAsync();

            return changes;
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

            // Make sure both are part of the same recipe
            if (from.RecipeId != to.RecipeId)
            {
                throw new InvalidOperationException("Preparation steps must be part of the same recipe.");
            }

            var changes = 0;

            var fromOrder = from.Order;
            var toOrder = to.Order;

            // Switch the order
            to.Order = 0;
            changes = changes + await DbContextProvider.SaveChangesAsync();

            from.Order = toOrder;
            changes = changes + await DbContextProvider.SaveChangesAsync();

            to.Order = fromOrder;
            changes = changes + await DbContextProvider.SaveChangesAsync();

            return changes;
        }
    }
}
