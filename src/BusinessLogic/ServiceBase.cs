using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stockpot.BusinessLogic
{
    public abstract class ServiceBase<TRepository, TEntity, TKey, TDto, TCreateDto, TUpdateDto>
        where TRepository : RepositoryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        private readonly DbContextProvider _dbContextProvider;
        private readonly TRepository _repository;

        internal ServiceBase(DbContextProvider dbContextProvider, TRepository repository)
        {
            _dbContextProvider = dbContextProvider;
            _repository = repository;
        }

        protected abstract DtoMapper<TEntity, TDto, TCreateDto, TUpdateDto> DtoMapper { get; }

        protected DbContextProvider DbContextProvider => _dbContextProvider;

        protected TRepository Repository => _repository;

        public virtual async Task<IEnumerable<TDto>> Get()
        {
            var items = await _repository.Get();
            var dto = DtoMapper.ToDto(items);
            return dto;
        }

        public virtual async Task<TDto> GetSingleOrDefault(TKey id)
        {
            var item = await _repository.GetSingleOrDefault(id);
            var dto = DtoMapper.ToDto(item);
            return dto;
        }

        public virtual async Task<int> Add(TCreateDto createDto)
        {
            var entity = DtoMapper.CreateEntity(createDto);
            _repository.Add(entity);
            return await _dbContextProvider.SaveChangesAsync();
        }

        public virtual async Task<int> Update(TKey id, TUpdateDto updateDto)
        {
            var entity = await _repository.GetSingleOrDefault(id, true);

            if (entity == null)
            {
                return 0;
            }

            DtoMapper.UpdateEntity(entity, updateDto);

            return await _dbContextProvider.SaveChangesAsync();
        }

        public virtual async Task<int> Delete(TKey id)
        {
            await _repository.Delete(id);
            return await _dbContextProvider.SaveChangesAsync();
        }
    }
}
