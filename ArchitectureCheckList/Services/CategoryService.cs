using System;
using System.Collections.Generic;
using ArchitectureCheckList.Data;
using ArchitectureCheckList.Dtos;
using System.Data.Entity;
using System.Linq;
using ArchitectureCheckList.Models;

namespace ArchitectureCheckList.Services
{
    public class CategoryService : ICategoryService
    {
        public CategoryService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.Categories;
            _cache = cacheProvider.GetCache();
        }

        public CategoryAddOrUpdateResponseDto AddOrUpdate(CategoryAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Category());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new CategoryAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<CategoryDto> Get()
        {
            ICollection<CategoryDto> response = new HashSet<CategoryDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new CategoryDto(entity)); }    
            return response;
        }


        public CategoryDto GetById(int id)
        {
            return new CategoryDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Category> _repository;
        protected readonly ICache _cache;
    }
}
