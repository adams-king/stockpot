using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stockpot.DataAccess.Entities
{
    public class Tag : IEntity<int>
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsRootTag { get; set; }

        public ICollection<RecipeTag> RecipeTags { get; set; }
    }
}
