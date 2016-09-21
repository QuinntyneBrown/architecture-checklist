namespace ArchitectureCheckList.Dtos
{
    public class ProjectCheckListItemDto
    {
        public ProjectCheckListItemDto(ArchitectureCheckList.Models.ProjectCheckListItem entity)
        {
            this.Id = entity.Id;
        }

        public ProjectCheckListItemDto()
        {
            
        }

        public int Id { get; set; }
    }
}
