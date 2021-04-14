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
    public class UpdateStatusPrinterController : ControllerBase
    {
        private readonly IOrdersInterface _ordersInterface;

        public UpdateStatusPrinterController(IOrdersInterface _ordersInterface)
        {
            this._ordersInterface = _ordersInterface;
        }
        // GET: api/<UpdateStatusPrinter>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UpdateStatusPrinter>/5
        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            return await _ordersInterface.UpdatePrinterOrderStatus(new Guid(id));
        }

        // POST api/<UpdateStatusPrinter>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UpdateStatusPrinter>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UpdateStatusPrinter>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
