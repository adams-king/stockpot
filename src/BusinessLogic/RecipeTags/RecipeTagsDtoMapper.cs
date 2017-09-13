using Stockpot.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stockpot.BusinessLogic.RecipeTags
{
    public class RecipeTagsDtoMapper : IDtoMapper<RecipeTag, RecipeTagDto>
    {
        public IEnumerable<RecipeTagDto> ToDto(IEnumerable<RecipeTag> entities)
        {
            return entities.Select(e => ToDto(e));
        }

        public RecipeTagDto ToDto(RecipeTag entity)
        {
            return new RecipeTagDto
            {
                TagId = entity.Tag.Id,
                TagName = entity.Tag.Name,
                IsRootTag = entity.Tag.IsRootTag
            };
        }

        public RecipeTag ToEntity(RecipeTagDto dto)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(RecipeTag entity, RecipeTagDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
