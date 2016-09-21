using ArchitectureCheckList.Dtos;
using System.Collections.Generic;

namespace ArchitectureCheckList.Services
{
    public interface ICategoryService
    {
        CategoryAddOrUpdateResponseDto AddOrUpdate(CategoryAddOrUpdateRequestDto request);
        ICollection<CategoryDto> Get();
        CategoryDto GetById(int id);
        dynamic Remove(int id);
    }
}
