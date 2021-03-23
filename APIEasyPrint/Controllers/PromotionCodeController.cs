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

    public class PromotionCodeController : ControllerBase
    {
        private readonly IOrdersInterface _ordersInterface;

        public PromotionCodeController(IOrdersInterface _ordersInterface)
        {
            this._ordersInterface = _ordersInterface;
        }
        // GET: api/<PromotionCodeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PromotionCodeController>/5
        [HttpGet("{id}")]
        public List<PrivatePromotionCodeApiModel.Response> Get(string id)
        {
            return _ordersInterface.GetPromotionCode(new Guid(id));
        }

        // POST api/<PromotionCodeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PromotionCodeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PromotionCodeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
