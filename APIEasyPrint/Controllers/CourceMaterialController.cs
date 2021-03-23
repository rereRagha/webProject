using APIEasyPrint.APIModels;
using APIEasyPrint.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIEasyPrint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]

    public class CourceMaterialController : ControllerBase
    {

        private readonly IPrintingShopsInterface _printingShops;
        public CourceMaterialController(IPrintingShopsInterface _printingShops)
        {
            this._printingShops = _printingShops;
        }


        // GET: api/<CourceMaterialController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CourceMaterialController>/5
        [HttpGet("{id}")]
        public async Task<List<CourceMaterialApiModel.Response>> GetAsync(string id)
        {
            List<CourceMaterialApiModel.Response> coursere = await _printingShops.GetMaterialsByID(new Guid(id));
            return coursere;
        }

        // POST api/<CourceMaterialController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CourceMaterialController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourceMaterialController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
