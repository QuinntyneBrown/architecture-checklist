using ArchitectureCheckList.Models;

namespace ArchitectureCheckList.Data
{
    public interface IUow
    {
        IRepository<Category> Categories { get; }
        IRepository<CheckList> CheckLists { get; }
        IRepository<CheckListItem> CheckListItems { get; }
        IRepository<Project> Projects { get; }
        IRepository<ProjectCheckListItem> ProjectCheckListItems { get; }
        IRepository<ProjectMember> ProjectMembers { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        void SaveChanges();
    }
}
