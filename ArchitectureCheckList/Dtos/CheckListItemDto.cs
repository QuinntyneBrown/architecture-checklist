namespace ArchitectureCheckList.Dtos
{
    public class CheckListItemDto
    {
        public CheckListItemDto()
        {

        }

        public CheckListItemDto(Models.CheckListItem entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
