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
    public class PrintingShopLoginController : ControllerBase
    {

        private readonly IPrintingShopsInterface _printerInterface;
        public PrintingShopLoginController(IPrintingShopsInterface _printerInterface)
        {
            this._printerInterface = _printerInterface;
        }

        // GET: api/<PrintingShopLoginController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PrintingShopLoginController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrintingShopLoginController>


        // POST api/<LoginController>
        [HttpPost]
        public ActionResult<ApiRespnse<PrintingShopLoginApiModel.Response>> Post(PrintingShopLoginApiModel.Request request)
        {
            var response = new ApiRespnse<PrintingShopLoginApiModel.Response>();


            ApplicationUser User = new  ApplicationUser();


            User = _printerInterface.FindApplicationUserByEmail(request.Email);


            if (User == null)
            {
                response.Data = new PrintingShopLoginApiModel.Response();
                response.Data.ErrorMessage = " هذا الأيميل غير موجود, هل تريد انشاء حساب جديد ؟";
                return Ok(response);
            }

            if (User.PasswordHash == request.PasswordHash)
            {
                response.Data = new PrintingShopLoginApiModel.Response();
                response.Data.Email = User.Email;
                response.Data.EmailConfiremd = User.EmailConfirmed;
                response.Data.PhoneNumber = User.PhoneNumber;
                response.Data.Id = User.Id.ToString();
                response.Data.FullName = User.UserName;

                return Ok(response);
            }
            else
            {
                response.Data = new PrintingShopLoginApiModel.Response();
                response.Data.ErrorMessage = " رقم سري خاطئ , الرجاء المحاولة مجدداً";
                return Ok(response);
            }

        }

        // PUT api/<PrintingShopLoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrintingShopLoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
