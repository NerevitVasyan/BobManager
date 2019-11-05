using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BobManager.DataAccess;
using BobManager.DataAccess.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace BobManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ApplicationContext AppContext;

        public ValuesController(ApplicationContext AppContext)
        {
            this.AppContext = AppContext;
        }


        // GET api/values
        [HttpGet]
        public object Get()
        {
            return AppContext.SpendingCategories.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

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
