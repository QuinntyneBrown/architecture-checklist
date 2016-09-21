using ArchitectureCheckList.Models;
using System.Data.Entity;

namespace ArchitectureCheckList.Data
{
    public class DataContext: DbContext, IDbContext
    {
        public DataContext()
            : base(nameOrConnectionString: "ArchitectureCheckListDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<CheckListItem> CheckListItems { get; set; }
        public DbSet<Project> Projects { get; set; }        
        public DbSet<ProjectCheckListItem> ProjectCheckListItems { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        } 
    }
}
