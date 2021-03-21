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
    public class ItemsController : ControllerBase
    {
        private readonly IOrdersInterface _ordersInterface;

        public ItemsController(IOrdersInterface _ordersInterface)
        {
            this._ordersInterface = _ordersInterface;
        }




        // GET: api/<ItemsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public List<AddItemApiModel.itemView> Get(string id)
        {
            return _ordersInterface.GetOrderDetailes(new Guid(id));
        }

        // POST api/<ItemsController>
        [HttpPost]
        public async Task<AddItemApiModel.ResponseByOneItem> PostAsync(AddItemApiModel.Request request)
        {
            //try
            //{
                return await _ordersInterface.PostItemsDetailes(request);

            //}
            //catch
            //{
            //    return null;
            //}
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await  _ordersInterface.DeleteItem(new Guid(id));
        }
    }
}
