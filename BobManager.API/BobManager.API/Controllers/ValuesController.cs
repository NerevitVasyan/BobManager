using System;
using BobManager.Dto.DtoResults;
using BobManager.Helpers.Managers;
using Microsoft.AspNetCore.Mvc;

namespace BobManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ClientErrorManager clientErrorManager;
        public ValuesController(ClientErrorManager clientErrorManager) {
            this.clientErrorManager = clientErrorManager ?? throw new ArgumentNullException(nameof(clientErrorManager));
        }

        // GET api/values
        [HttpGet]
        public ActionResult<ResultDto> Get()
        {
            return new ResultDto { IsSuccessful = true, Message = "test" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) 
            => "value";
    }
}
