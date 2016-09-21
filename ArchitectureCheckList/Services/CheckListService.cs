using System;
using System.Collections.Generic;
using ArchitectureCheckList.Data;
using ArchitectureCheckList.Dtos;
using System.Data.Entity;
using System.Linq;
using ArchitectureCheckList.Models;

namespace ArchitectureCheckList.Services
{
    public class CheckListService : ICheckListService
    {
        public CheckListService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.CheckLists;
            _cache = cacheProvider.GetCache();
        }

        public CheckListAddOrUpdateResponseDto AddOrUpdate(CheckListAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new CheckList());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new CheckListAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<CheckListDto> Get()
        {
            ICollection<CheckListDto> response = new HashSet<CheckListDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new CheckListDto(entity)); }    
            return response;
        }


        public CheckListDto GetById(int id)
        {
            return new CheckListDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        public CheckListDto GetByName(string name)
        {
            return new CheckListDto(_repository.GetAll()
                .Include(x=>x.CheckListItems)
                .Where(x => x.Name == name && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<CheckList> _repository;
        protected readonly ICache _cache;
    }
}
