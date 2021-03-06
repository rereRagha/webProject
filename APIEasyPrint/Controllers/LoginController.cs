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
    public class LoginController : ControllerBase
    {

        private readonly IAdminInterface _adminInterface;
        public LoginController(IAdminInterface _adminInterface)
        {
            this._adminInterface = _adminInterface;
        }

        // GET: api/<LoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        public ActionResult<ApiRespnse<LoginApiModel.Response>> Post(LoginApiModel.Request request)
        {
            var response = new ApiRespnse<LoginApiModel.Response>();


            Customer customer = new Customer();


            customer =  _adminInterface.FindCustomerByEmail(request.Email);


            if (customer == null)
            {
                response.Data = new LoginApiModel.Response();
                response.Data.ErrorMessage = " هذا الأيميل غير موجود, هل تريد انشاء حساب جديد ؟";
                return Ok(response);
            }

            if (customer.PasswordHash == request.PasswordHash)
            {
                response.Data = new LoginApiModel.Response();
                response.Data.Email = customer.Email;
                response.Data.EmailConfiremd = customer.EmailConfirmed;
                response.Data.PhoneNumber = customer.PhoneNumber;
                response.Data.Id = customer.Id.ToString();
                response.Data.UserName = customer.UserName;

                return Ok(response);
            }
            else
            {
                response.Data = new LoginApiModel.Response();
                response.Data.ErrorMessage = " رقم سري خاطئ , الرجاء المحاولة مجدداً";
                return Ok(response);
            }

        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
