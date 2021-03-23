using APIEasyPrint.Interfaces;
using APIEasyPrint.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace APIEasyPrint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]

    public class AdminController : ControllerBase
    {
        private readonly IAdminInterface _adminInterface;
      

        public AdminController(
            IAdminInterface _adminInterface)
        {
            this._adminInterface = _adminInterface;
        }

        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public Admin Get(string id)
        {
           Admin AdminInfo = _adminInterface.GetAdminDetailes(new Guid(id));

            return AdminInfo;
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
