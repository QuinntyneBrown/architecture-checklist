namespace ArchitectureCheckList.Dtos
{
    public class ProjectMemberDto
    {
        public ProjectMemberDto(ArchitectureCheckList.Models.ProjectMember entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public ProjectMemberDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
