using System;
using System.Collections.Generic;
using ArchitectureCheckList.Data;
using ArchitectureCheckList.Dtos;
using System.Data.Entity;
using System.Linq;
using ArchitectureCheckList.Models;

namespace ArchitectureCheckList.Services
{
    public class ProjectMemberService : IProjectMemberService
    {
        public ProjectMemberService(IUow uow, ICacheProvider cacheProvider)
        {
            _uow = uow;
            _repository = uow.ProjectMembers;
            _cache = cacheProvider.GetCache();
        }

        public ProjectMemberAddOrUpdateResponseDto AddOrUpdate(ProjectMemberAddOrUpdateRequestDto request)
        {
            var entity = _repository.GetAll()
                .FirstOrDefault(x => x.Id == request.Id && x.IsDeleted == false);
            if (entity == null) _repository.Add(entity = new ProjectMember());
            entity.Name = request.Name;
            _uow.SaveChanges();
            return new ProjectMemberAddOrUpdateResponseDto(entity);
        }

        public dynamic Remove(int id)
        {
            var entity = _repository.GetById(id);
            entity.IsDeleted = true;
            _uow.SaveChanges();
            return id;
        }

        public ICollection<ProjectMemberDto> Get()
        {
            ICollection<ProjectMemberDto> response = new HashSet<ProjectMemberDto>();
            var entities = _repository.GetAll().Where(x => x.IsDeleted == false).ToList();
            foreach(var entity in entities) { response.Add(new ProjectMemberDto(entity)); }    
            return response;
        }


        public ProjectMemberDto GetById(int id)
        {
            return new ProjectMemberDto(_repository.GetAll().Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault());
        }

        protected readonly IUow _uow;
        protected readonly IRepository<ProjectMember> _repository;
        protected readonly ICache _cache;
    }
}
