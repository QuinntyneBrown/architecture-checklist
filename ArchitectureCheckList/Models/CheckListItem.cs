namespace ArchitectureCheckList.Models
{
    public class CheckListItem
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? CheckListId { get; set; }
        public Category Category { get; set; }
        public CheckList CheckList { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
