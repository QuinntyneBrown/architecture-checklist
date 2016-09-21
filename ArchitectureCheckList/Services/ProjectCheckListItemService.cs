using System;
using System.Collections.Generic;
using ArchitectureCheckList.Data;
using ArchitectureCheckList.Dtos;
using System.Data.Entity;
using System.Linq;
using ArchitectureCheckList.Models;

namespace ArchitectureCheckList.Services
{
    public class ProjectCheckListItemService : IProjectCheckListItemService
    {
        public ProjectCheckListItemService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.ProjectCheckListItems;
            _cache = cacheProvider.GetCache();
        }

        public ProjectCheckListItemAddOrUpdateResponseDto AddOrUpdate(ProjectCheckListItemAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new ProjectCheckListItem());
            
            _uow.SaveChanges();
            return new ProjectCheckListItemAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<ProjectCheckListItemDto> Get()
        {
            ICollection<ProjectCheckListItemDto> response = new HashSet<ProjectCheckListItemDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new ProjectCheckListItemDto(entity)); }    
            return response;
        }


        public ProjectCheckListItemDto GetById(int id)
        {
            return new ProjectCheckListItemDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<ProjectCheckListItem> _repository;
        protected readonly ICache _cache;
    }
}
