using Stockpot.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stockpot.BusinessLogic.Tags
{
    public class TagsDtoMapper : IDtoMapper<Tag, TagDto>
    {
        public IEnumerable<TagDto> ToDto(IEnumerable<Tag> entities)
        {
            return entities.Select(e => ToDto(e));
        }

        public TagDto ToDto(Tag entity)
        {
            return new TagDto
            {
                Id = entity.Id,
                Name = entity.Name,
                IsRootTag = entity.IsRootTag
            };
        }

        public Tag ToEntity(TagDto dto)
        {
            var entity = new Tag();
            UpdateEntity(entity, dto);
            return entity;
        }

        public void UpdateEntity(Tag entity, TagDto dto)
        {
            entity.Name = dto.Name;
            entity.IsRootTag = dto.IsRootTag;
        }
    }
}
