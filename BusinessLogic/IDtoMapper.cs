using System.Collections.Generic;

namespace Stockpot.BusinessLogic
{
    public interface IDtoMapper<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        IEnumerable<TDto> ToDto(IEnumerable<TEntity> entities);

        TDto ToDto(TEntity entity);

        TEntity ToEntity(TDto dto);

        void UpdateEntity(TEntity entity, TDto dto);
    }
}
