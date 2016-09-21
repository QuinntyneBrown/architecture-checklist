namespace ArchitectureCheckList.Dtos
{
    public class CategoryDto
    {
        public CategoryDto(ArchitectureCheckList.Models.Category entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public CategoryDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
