using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BobManager.Dto.DtoResults;
using BobManager.Helpers.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            return null;
        }

        [HttpGet("[action]")]
        [Authorize]
        public ActionResult<string> GetAuth()
        {
            return "YOU ARE AUTHRIZED";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) 
            => "value";

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
