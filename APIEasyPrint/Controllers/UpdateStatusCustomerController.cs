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
    public class UpdateStatusCustomerController : ControllerBase
    {
        private readonly IOrdersInterface _ordersInterface;

        public UpdateStatusCustomerController(IOrdersInterface _ordersInterface)
        {
            this._ordersInterface = _ordersInterface;
        }
        // GET: api/<UpdateStatusCustomer>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UpdateStatusCustomer>/5
        [HttpGet("{id}/{total}")]
        public async Task<string> Get(string id, double total)
        {
            return await _ordersInterface.UpdateCustomerOrderStatusAsync(new Guid(id), total);
        }

        // POST api/<UpdateStatusCustomer>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UpdateStatusCustomer>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UpdateStatusCustomer>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
