using APIEasyPrint.APIModels;
using APIEasyPrint.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIEasyPrint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IOrdersInterface _ordersInterface;

        public AddressController(IOrdersInterface _ordersInterface)
        {
            this._ordersInterface = _ordersInterface;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public AddressApiModel.Response Get(string id)
        {
            return _ordersInterface.GetAddress(new Guid(id));
        }

        // POST api/<AddressController>
        [HttpPost]
        public Task<AddressApiModel.Response> Post(AddressApiModel.Request request)
        {

            return _ordersInterface.PostNewAdress(request);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
