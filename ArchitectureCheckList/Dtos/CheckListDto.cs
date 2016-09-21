namespace ArchitectureCheckList.Dtos
{
    public class CheckListDto
    {
        public CheckListDto(ArchitectureCheckList.Models.CheckList entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
        }

        public CheckListDto()
        {
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
