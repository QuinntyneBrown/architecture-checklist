using System.Collections.Generic;

namespace ArchitectureCheckList.Models
{
    public class CheckList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<CheckListItem> CheckListItems { get; set; } = new HashSet<CheckListItem>();
        public bool IsDeleted { get; set; }
    }
}
