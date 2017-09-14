using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Repositories;

namespace Stockpot.BusinessLogic.Tags
{
    public class TagsService
        : ServiceBaseSimple<TagsRepository, Tag, int, TagDto, CreateUpdateTagDto>
    {
        private readonly TagsDtoMapper _tagsDtoMapper;

        public TagsService(
            DbContextProvider dbContextProvider,
            TagsDtoMapper tagsDtoMapper,
            TagsRepository tagsRepository)
            : base(dbContextProvider, tagsRepository)
        {
            _tagsDtoMapper = tagsDtoMapper;
        }

        protected override DtoMapperSimple<Tag, TagDto, CreateUpdateTagDto> DtoMapperSimple
            => _tagsDtoMapper;
    }
}
