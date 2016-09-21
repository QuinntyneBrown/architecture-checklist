using System.Collections.Generic;

namespace ArchitectureCheckList.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CheckListItem> CheckListItems { get; set; }
        public bool IsDeleted { get; set; }
    }
}
