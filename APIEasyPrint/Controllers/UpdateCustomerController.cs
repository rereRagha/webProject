using APIEasyPrint.APIModels;
using APIEasyPrint.Interfaces;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors]

    public class UpdateCustomerController : ControllerBase
    {
        private readonly IAdminInterface _adminInterface;
        public UpdateCustomerController(IAdminInterface _adminInterface)
        {
            this._adminInterface = _adminInterface;
        }

        // GET: api/<UpdateCustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UpdateCustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UpdateCustomerController>
        [HttpPost]
        public void Post(UpdateCustomerInfoApiModel.Request updatedCustomer)
        {

            _adminInterface.UpdateCustomerDetailes(updatedCustomer);
               
        }

        // PUT api/<UpdateCustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UpdateCustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
