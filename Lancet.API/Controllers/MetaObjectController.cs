using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lancet.Models.Domain.Dtos;
using Lancet.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lancet.API
{
    [Produces("application/json")]
    [Route("api/MetaObject")]
    public class MetaObjectController : Controller
    {
        private ILancetService _lancetService;
        public MetaObjectController(ILancetService lancetService)
        {
            _lancetService = lancetService;
        }
        // GET: api/MetaObject
        [HttpGet(Name = "Get")]
        public IEnumerable<MetaObjectDto> Get([FromQuery]Guid id)
        {
            IEnumerable<MetaObjectDto> result = null;
            if (id != Guid.Empty)
            {
                result = _lancetService.GetMetaObjectById(id);
            }
            else
            {
                result = _lancetService.GetAllMetaObjects();
            }
            return result;
        }

        // POST: api/MetaObject
        [HttpPost(Name = "Create")]
        public Guid Post([FromBody]MetaObjectDto metaObjectDto)
        {
            return _lancetService.CreateMetaObject(metaObjectDto);
        }

        // PUT: api/MetaObject/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
