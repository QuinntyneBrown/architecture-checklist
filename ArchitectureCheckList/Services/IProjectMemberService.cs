using ArchitectureCheckList.Dtos;
using System.Collections.Generic;

namespace ArchitectureCheckList.Services
{
    public interface IProjectMemberService
    {
        ProjectMemberAddOrUpdateResponseDto AddOrUpdate(ProjectMemberAddOrUpdateRequestDto request);
        ICollection<ProjectMemberDto> Get();
        ProjectMemberDto GetById(int id);
        dynamic Remove(int id);
    }
}
