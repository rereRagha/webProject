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
    public class CustomerOrderController : ControllerBase
    {
        private readonly IOrdersInterface _ordersInterface;

        public CustomerOrderController(IOrdersInterface _ordersInterface)
        {
            this._ordersInterface = _ordersInterface;
        }

        // GET: api/<CustomerOrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerOrderController>/5
        [HttpGet("{id}")]
        public List<OrderApiModel.Response> Get(string id)
        {
            return _ordersInterface.GetOrdersByCustomerID(new Guid(id));
        }

        // POST api/<CustomerOrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<CustomerOrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerOrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
