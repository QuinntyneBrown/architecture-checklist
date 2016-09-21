using ArchitectureCheckList.Dtos;
using ArchitectureCheckList.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ArchitectureCheckList.Controllers
{
    [Authorize]
    [RoutePrefix("api/checkList")]
    public class CheckListController : ApiController
    {
        public CheckListController(ICheckListService checkListService)
        {
            _checkListService = checkListService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(CheckListAddOrUpdateResponseDto))]
        public IHttpActionResult Add(CheckListAddOrUpdateRequestDto dto) { return Ok(_checkListService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(CheckListAddOrUpdateResponseDto))]
        public IHttpActionResult Update(CheckListAddOrUpdateRequestDto dto) { return Ok(_checkListService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<CheckListDto>))]
        public IHttpActionResult Get() { return Ok(_checkListService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(CheckListDto))]
        public IHttpActionResult GetById(int id) { return Ok(_checkListService.GetById(id)); }

        [Route("getByName")]
        [HttpGet]
        [ResponseType(typeof(CheckListDto))]
        public IHttpActionResult GetByName(string name) { return Ok(_checkListService.GetByName(name)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_checkListService.Remove(id)); }

        protected readonly ICheckListService _checkListService;


    }
}
