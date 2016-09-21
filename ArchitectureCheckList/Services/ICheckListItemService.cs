using ArchitectureCheckList.Dtos;
using System.Collections.Generic;

namespace ArchitectureCheckList.Services
{
    public interface ICheckListItemService
    {
        CheckListItemAddOrUpdateResponseDto AddOrUpdate(CheckListItemAddOrUpdateRequestDto request);
        ICollection<CheckListItemDto> Get();
        CheckListItemDto GetById(int id);
        dynamic Remove(int id);
    }
}
