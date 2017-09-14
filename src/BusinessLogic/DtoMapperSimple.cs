namespace Stockpot.BusinessLogic
{
    public abstract class DtoMapperSimple<TEntity, TViewDto, TCreateUpdateDto>
        : DtoMapper<TEntity, TViewDto, TCreateUpdateDto, TCreateUpdateDto>
        where TEntity : class, new()
        where TViewDto : class
        where TCreateUpdateDto : class
    {
        internal override TEntity CreateEntity(TCreateUpdateDto dto)
        {
            var e = new TEntity();
            UpdateEntity(e, dto);
            return e;
        }
    }
}
