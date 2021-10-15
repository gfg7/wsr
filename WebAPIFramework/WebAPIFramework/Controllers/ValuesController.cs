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
        IRepository<string> repository;

        public ValuesController(IRepository<string> repository)
        {
            this.repository = repository;
        }

        public ValuesController()
        {
            repository = new MockRepository();
        }

        // GET api/values
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await repository.GetAll());
        }
        
        public async Task<IHttpActionResult> Get(string filter)
        {
            return Ok(await repository.GetAll(filter));
        }

        // GET api/values/5
        public async Task<IHttpActionResult> Get(int i)
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

        // POST api/values
        [HttpPost]
        public async Task<IHttpActionResult> Add(string item)
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
        public async Task<IHttpActionResult> AddOnIndex(string item, int i)
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

        // PUT api/values/5
        [HttpPut]
        public async Task<IHttpActionResult> Update(int i,  string item)
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

        // DELETE api/values/5
        public async Task<IHttpActionResult> Delete(string item)
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

        // DELETE api/values/5
        [HttpDelete, ActionName("idx")]
        public async Task<IHttpActionResult> DeleteByIndex(int i)
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
