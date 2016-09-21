using System.Collections.Generic;

namespace ArchitectureCheckList.Models
{
    public class ProjectCheckListItem
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public Project Project { get; set; }
        public int? CheckListItemId { get; set; }
        public CheckListItem CheckListItem { get; set; }        
        public int Rating { get; set; }
        public bool IsDeleted { get; set; }
    }
}
