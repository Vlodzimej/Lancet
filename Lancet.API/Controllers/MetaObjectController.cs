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
        [HttpGet]
        public string Get()
        {
            return "value";
        }

        [HttpGet("{metaObjectId}", Name = "GetById")]
        public MetaObjectDto GetById([FromQuery]Guid metaObjectId)
        {
            return _lancetService.GetMetaObjectById(metaObjectId);
        }
       
        // POST: api/MetaObject
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
