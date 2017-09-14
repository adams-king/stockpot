using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;

namespace Stockpot.BusinessLogic
{
    public abstract class ServiceBaseSimple<TRepository, TEntity, TKey, TDto, TCreateUpdateDto>
        : ServiceBase<TRepository, TEntity, TKey, TDto, TCreateUpdateDto, TCreateUpdateDto>
        where TRepository : RepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TDto : class
        where TCreateUpdateDto : class
    {
        internal ServiceBaseSimple(DbContextProvider dbContextProvider, TRepository repository)
            : base(dbContextProvider, repository)
        {
        }

        protected override DtoMapper<TEntity, TDto, TCreateUpdateDto, TCreateUpdateDto> DtoMapper => DtoMapperSimple;

        protected abstract DtoMapperSimple<TEntity, TDto, TCreateUpdateDto> DtoMapperSimple { get; }
    }
}
