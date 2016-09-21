using ArchitectureCheckList.Dtos;
using ArchitectureCheckList.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace ArchitectureCheckList.Controllers
{
    [Authorize]
    [RoutePrefix("api/checkListItem")]
    public class CheckListItemController : ApiController
    {
        public CheckListItemController(ICheckListItemService checkListItemService)
        {
            _checkListItemService = checkListItemService;
        }

        [Route("add")]
        [HttpPost]
        [ResponseType(typeof(CheckListItemAddOrUpdateResponseDto))]
        public IHttpActionResult Add(CheckListItemAddOrUpdateRequestDto dto) { return Ok(_checkListItemService.AddOrUpdate(dto)); }

        [Route("update")]
        [HttpPut]
        [ResponseType(typeof(CheckListItemAddOrUpdateResponseDto))]
        public IHttpActionResult Update(CheckListItemAddOrUpdateRequestDto dto) { return Ok(_checkListItemService.AddOrUpdate(dto)); }

        [Route("get")]
        [AllowAnonymous]
        [HttpGet]
        [ResponseType(typeof(ICollection<CheckListItemDto>))]
        public IHttpActionResult Get() { return Ok(_checkListItemService.Get()); }

        [Route("getById")]
        [HttpGet]
        [ResponseType(typeof(CheckListItemDto))]
        public IHttpActionResult GetById(int id) { return Ok(_checkListItemService.GetById(id)); }

        [Route("remove")]
        [HttpDelete]
        [ResponseType(typeof(int))]
        public IHttpActionResult Remove(int id) { return Ok(_checkListItemService.Remove(id)); }

        protected readonly ICheckListItemService _checkListItemService;


    }
}
