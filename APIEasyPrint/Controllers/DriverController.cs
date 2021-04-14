using APIEasyPrint.APIModels;
using APIEasyPrint.Interfaces;
using APIEasyPrint.Models;
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

    public class DriverController : ControllerBase
    {
        private readonly IAdminInterface _adminInterface;
        public DriverController(IAdminInterface _adminInterface)
        {
            this._adminInterface = _adminInterface;
        }
        // GET: api/<DriverController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DriverController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DriverController>
        [HttpPost]
        public ActionResult<ApiRespnse<DriverLoginApiModel.Response>> Post(DriverLoginApiModel.Request request)
        {
            var response = new ApiRespnse<DriverLoginApiModel.Response>();


            DeliveryDriver driver = new DeliveryDriver();


            driver = _adminInterface.FindDriverByEmail(request.Email);


            if (driver == null)
            {
                response.Data = new DriverLoginApiModel.Response();
                response.Data.ErrorMessage = " هذا الأيميل غير موجود الرجاء المحاولة مجدداً";
                return Ok(response);
            }

            if (driver.PasswordHash == request.PasswordHash)
            {
                response.Data = new DriverLoginApiModel.Response();
                response.Data.Email = driver.Email;
                response.Data.PhoneNumber = driver.PhoneNumber;
                response.Data.Id = driver.Id.ToString();
                response.Data.UserName = driver.UserName;
                response.Data.PrinterId = driver.IDPrinter.ToString();

                return Ok(response);
            }
            else
            {
                response.Data = new DriverLoginApiModel.Response();
                response.Data.ErrorMessage = " رقم سري خاطئ , الرجاء المحاولة مجدداً";
                return Ok(response);
            }

        }

        // PUT api/<DriverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DriverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
