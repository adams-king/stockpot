using System.ComponentModel.DataAnnotations;

namespace Stockpot.BusinessLogic.Tags
{
    public class TagDto : CreateUpdateTagDto
    {
        public int Id { get; set; }
    }

    public class CreateUpdateTagDto
    {
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        public bool IsRootTag { get; set; }
    }
}
