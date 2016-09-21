using ArchitectureCheckList.Dtos;
using System.Collections.Generic;

namespace ArchitectureCheckList.Services
{
    public interface IProjectCheckListItemService
    {
        ProjectCheckListItemAddOrUpdateResponseDto AddOrUpdate(ProjectCheckListItemAddOrUpdateRequestDto request);
        ICollection<ProjectCheckListItemDto> Get();
        ProjectCheckListItemDto GetById(int id);
        dynamic Remove(int id);
    }
}
