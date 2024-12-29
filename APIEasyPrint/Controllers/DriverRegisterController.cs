using APIEasyPrint.APIModels;
using APIEasyPrint.Interfaces;
using APIEasyPrint.Models;
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
    public class DriverRegisterController : ControllerBase
    {

        private readonly IAdminInterface _adminInterface;
        public DriverRegisterController(IAdminInterface _adminInterface)
        {
            this._adminInterface = _adminInterface;
        }
        // GET: api/<DriverRegisterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DriverRegisterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DriverRegisterController>
        [HttpPost]
        public async Task<Teatcher> Post(DriverRegister.Request request)
        {
            var teatcher = new Teatcher()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.Email,
                PasswordHash = request.PasswordHash,
                PhoneNumber = request.PhoneNumber,
            };

            return await _adminInterface.PostTeatcherDetailes(teatcher);
             
        }

        // PUT api/<DriverRegisterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DriverRegisterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
