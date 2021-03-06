using System;
using System.Collections.Generic;
using ArchitectureCheckList.Dtos;
using ArchitectureCheckList.Data;
using System.Linq;

namespace ArchitectureCheckList.Services
{
    public class CheckListItemService : ICheckListItemService
    {
        public CheckListItemService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.CheckListItems;
            _cache = cacheProvider.GetCache();
        }

        public CheckListItemAddOrUpdateResponseDto AddOrUpdate(CheckListItemAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new Models.CheckListItem());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new CheckListItemAddOrUpdateResponseDto(entity);
        }

        public ICollection<CheckListItemDto> Get()
        {
            ICollection<CheckListItemDto> response = new HashSet<CheckListItemDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach (var entity in entities) { response.Add(new CheckListItemDto(entity)); }
            return response;
        }

        public CheckListItemDto GetById(int id)
        {
            return new CheckListItemDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        protected readonly IUow _uow;
        protected readonly IRepository<Models.CheckListItem> _repository;
        protected readonly ICache _cache;
    }
}
