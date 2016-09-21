namespace ArchitectureCheckList.Dtos
{
    public class CheckListAddOrUpdateResponseDto: CheckListDto
    {
        public CheckListAddOrUpdateResponseDto(ArchitectureCheckList.Models.CheckList entity)
            :base(entity)
        {

        }
    }
}
