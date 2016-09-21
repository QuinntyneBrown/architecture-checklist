namespace ArchitectureCheckList.Dtos
{
    public class ProjectDto
    {
        public ProjectDto(ArchitectureCheckList.Models.Project entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public ProjectDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
