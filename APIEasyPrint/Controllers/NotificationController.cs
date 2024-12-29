using APIEasyPrint.APIModels;
using APIEasyPrint.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using APIEasyPrint.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIEasyPrint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]

    public class NotificationController : ControllerBase
    {
        private readonly IOrdersInterface _ordersInterface;

        public NotificationController(IOrdersInterface _ordersInterface)
        {
            this._ordersInterface = _ordersInterface;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public List<Notification> Get()
        {
            return _ordersInterface.GetAllNotification();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public List<Notification> Get(string id)
        {
            return _ordersInterface.GetNotificationByParentID(new Guid(id));
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<AddItemApiModel.Response> PostAsync(AddItemApiModel.Request request)
        {
            //do try catch 
            
            return  await _ordersInterface.PostOrderDetailes(request);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
