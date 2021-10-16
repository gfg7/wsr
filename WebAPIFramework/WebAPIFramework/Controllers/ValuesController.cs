using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPIFramework.Interfaces;
using WebAPIFramework.Repository;

namespace WebAPIFramework.Controllers
{
    public class ValuesController : ApiController
    {
        private IRepository<string> repository;

        public ValuesController(IRepository<string> repository)
        {
            this.repository = repository;
        }

        public ValuesController()
        {
            repository = new MockRepository();
        }

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await repository.GetAll());
        }
        
        public async Task<IHttpActionResult> Get([FromUri] string filter)
        {
            return Ok(await repository.GetAll(filter));
        }

        public async Task<IHttpActionResult> Get([FromUri] int i)
        {
            try
            {
                return Ok(await repository.GetByIndex(i));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> Add([FromBody] string item)
        {
            try
            {
                return Ok(await repository.AddItem(item));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost, ActionName("idx")]
        public async Task<IHttpActionResult> AddOnIndex([FromBody] string item, [FromUri] int i)
        {
            try
            {
                return Created(i.ToString(), await repository.AddOnIndex(item, i));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update([FromUri] int i, [FromBody] string item)
        {
            try
            {
                return Ok(await repository.UpdateByIndex(item, i));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public async Task<IHttpActionResult> Delete([FromBody] string item)
        {
            try
            {
                return Ok(await repository.DeleteByItem(item));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete, ActionName("idx")]
        public async Task<IHttpActionResult> DeleteByIndex([FromUri] int i)
        {
            try
            {
                return Ok(await repository.DeleteByIndex(i));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
