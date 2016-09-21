using ArchitectureCheckList.Dtos;
using ArchitectureCheckList.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ArchitectureCheckList.Controllers
{
    [Authorize]
    [RoutePrefix("api/projectMember")]
    public class ProjectMemberController : ApiController
    {
        public ProjectMemberController(IProjectMemberService projectMemberService)
        {
            _projectMemberService = projectMemberService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(ProjectMemberAddOrUpdateResponseDto))]
        public IHttpActionResult Add(ProjectMemberAddOrUpdateRequestDto dto) { return Ok(_projectMemberService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(ProjectMemberAddOrUpdateResponseDto))]
        public IHttpActionResult Update(ProjectMemberAddOrUpdateRequestDto dto) { return Ok(_projectMemberService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<ProjectMemberDto>))]
        public IHttpActionResult Get() { return Ok(_projectMemberService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(ProjectMemberDto))]
        public IHttpActionResult GetById(int id) { return Ok(_projectMemberService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_projectMemberService.Remove(id)); }

        protected readonly IProjectMemberService _projectMemberService;


    }
}
