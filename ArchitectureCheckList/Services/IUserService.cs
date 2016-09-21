using ArchitectureCheckList.Dtos;
using System.Collections.Generic;

namespace ArchitectureCheckList.Services
{
    public interface IUserService
    {
        UserAddOrUpdateResponseDto AddOrUpdate(UserAddOrUpdateRequestDto request);
        ICollection<UserDto> Get();
        UserDto GetById(int id);
        dynamic Remove(int id);
    }
}
