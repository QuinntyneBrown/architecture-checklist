using System.Collections.Generic;

namespace ArchitectureCheckList.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProjectMember> ProjectMembers { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }
}
