using Stockpot.DataAccess.Entities;

namespace Stockpot.BusinessLogic.Tags
{
    public class TagsDtoMapper : DtoMapperSimple<Tag, TagDto, CreateUpdateTagDto>
    {
        internal override TagDto ToDto(Tag entity)
        {
            return new TagDto
            {
                Id = entity.Id,
                Name = entity.Name,
                IsRootTag = entity.IsRootTag
            };
        }

        internal override void UpdateEntity(Tag entity, CreateUpdateTagDto updateDto)
        {
            entity.Name = updateDto.Name;
            entity.IsRootTag = updateDto.IsRootTag;
        }
    }
}
