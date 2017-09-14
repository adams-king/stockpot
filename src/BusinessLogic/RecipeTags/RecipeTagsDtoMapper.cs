using Stockpot.DataAccess.Entities;
using System;

namespace Stockpot.BusinessLogic.RecipeTags
{
    public class RecipeTagsDtoMapper : DtoMapperSimple<RecipeTag, RecipeTagDto, object>
    {
        internal override RecipeTagDto ToDto(RecipeTag entity)
        {
            return new RecipeTagDto
            {
                TagId = entity.Tag.Id,
                TagName = entity.Tag.Name,
                IsRootTag = entity.Tag.IsRootTag
            };
        }

        internal override void UpdateEntity(RecipeTag entity, object updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
