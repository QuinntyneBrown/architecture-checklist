using ArchitectureCheckList.Dtos;
using System.Collections.Generic;

namespace ArchitectureCheckList.Services
{
    public interface ICheckListService
    {
        CheckListAddOrUpdateResponseDto AddOrUpdate(CheckListAddOrUpdateRequestDto request);
        ICollection<CheckListDto> Get();
        CheckListDto GetById(int id);
        CheckListDto GetByName(string name);
        dynamic Remove(int id);
    }
}
