using System.Collections.Generic;
using System.Linq;

namespace Stockpot.BusinessLogic
{
    public abstract class DtoMapper<TEntity, TDto, TCreateDto, TUpdateDto>
        where TEntity : class
        where TDto : class
        where TCreateDto : class
        where TUpdateDto : class
    {
        internal virtual IEnumerable<TDto> ToDto(IEnumerable<TEntity> entities)
        {
            return entities.Select(e => ToDto(e));
        }

        internal abstract TDto ToDto(TEntity entity);

        internal abstract TEntity CreateEntity(TCreateDto createDto);

        internal abstract void UpdateEntity(TEntity entity, TUpdateDto updateDto);
    }
}
