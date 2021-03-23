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

    public class UpdateAddressController : ControllerBase
    {
        private readonly IOrdersInterface _ordersInterface;

        public UpdateAddressController(IOrdersInterface _ordersInterface)
        {
            this._ordersInterface = _ordersInterface;
        }
        // GET: api/<UpdateAddressController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UpdateAddressController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UpdateAddressController>
        [HttpPost]
        public Task<AddressApiModel.Response> Post(AddressApiModel.Request request)
        {

            return _ordersInterface.UpdateAdress(request);
        }

        // PUT api/<UpdateAddressController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UpdateAddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
