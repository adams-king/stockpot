using Stockpot.DataAccess;
using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Repositories;

namespace Stockpot.BusinessLogic.Tags
{
    public class TagsService : ServiceBase<TagsRepository, Tag, TagDto, int>
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

        protected override IDtoMapper<Tag, TagDto> DtoMapper => _tagsDtoMapper;
    }
}
