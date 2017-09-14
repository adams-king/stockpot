namespace Stockpot.BusinessLogic.Tags
{
    public class TagDto : CreateUpdateTagDto
    {
        public int Id { get; set; }
    }

    public class CreateUpdateTagDto
    {
        public string Name { get; set; }

        public bool IsRootTag { get; set; }
    }
}
