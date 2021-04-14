﻿using APIEasyPrint.Interfaces;
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
    public class UpdateSatusDriverController : ControllerBase
    {
        private readonly IOrdersInterface _ordersInterface;

        public UpdateSatusDriverController(IOrdersInterface _ordersInterface)
        {
            this._ordersInterface = _ordersInterface;
        }
        // GET: api/<UpdateSatusDriver>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UpdateSatusDriver>/5
        [HttpGet("{id}")]
        public async Task<string> Get(string id)
        {
            return await _ordersInterface.UpdateDriverOrderStatus(new Guid(id));
        }

        // POST api/<UpdateSatusDriver>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UpdateSatusDriver>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UpdateSatusDriver>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
