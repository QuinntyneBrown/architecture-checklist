namespace ArchitectureCheckList.Dtos
{
    public class CheckListItemAddOrUpdateResponseDto: CheckListItemDto
    {
        public CheckListItemAddOrUpdateResponseDto(Models.CheckListItem entity)
        :base(entity)
        {

        }
    }
}
