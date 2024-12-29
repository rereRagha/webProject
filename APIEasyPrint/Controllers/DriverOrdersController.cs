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
    public class DriverOrdersController : ControllerBase
    {
        private readonly IOrdersInterface _ordersInterface;

        public DriverOrdersController(IOrdersInterface _ordersInterface)
        {
            this._ordersInterface = _ordersInterface;
        }
        // GET: api/<DriverOrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DriverOrdersController>/5
        [HttpGet("{id}")]
        public DriverOrders.Response Get(string id)
        {
            return _ordersInterface.GetFirstOrder(new Guid(id));
        }

        // POST api/<DriverOrdersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DriverOrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DriverOrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
