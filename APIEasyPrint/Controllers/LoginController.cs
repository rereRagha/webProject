using APIEasyPrint.APIModels;
using APIEasyPrint.Interfaces;
using APIEasyPrint.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIEasyPrint.Controllers
{
    //this is the customer login cpntroller
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]

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


            Parent parent = new Parent();


            parent =  _adminInterface.FindParentByEmail(request.Email);


            if (parent == null)
            {

                Teatcher teacher = new Teatcher();
                teacher = _adminInterface.FindTeatcherByEmail(request.Email);

                if (teacher == null)
                {
                    response.Data = new LoginApiModel.Response();
                    response.Data.ErrorMessage = " هذا الأيميل غير موجود, هل تريد انشاء حساب جديد ؟";
                    return Ok(response);
                }
                else
                {
                    if (teacher.PasswordHash == request.PasswordHash)
                    {
                        response.Data = new LoginApiModel.Response();
                        response.Data.Email = teacher.Email;
                        response.Data.EmailConfiremd = teacher.EmailConfirmed;
                        response.Data.PhoneNumber = teacher.PhoneNumber;
                        response.Data.Id = teacher.Id.ToString();
                        response.Data.UserName = teacher.UserName;

                        return Ok(response);
                    }
                    else
                    {
                        response.Data = new LoginApiModel.Response();
                        response.Data.ErrorMessage = " رقم سري خاطئ , الرجاء المحاولة مجدداً";
                        return Ok(response);
                    }

                }
               
            }

            if (parent.PasswordHash == request.PasswordHash)
            {
                response.Data = new LoginApiModel.Response();
                response.Data.Email = parent.Email;
                response.Data.EmailConfiremd = parent.EmailConfirmed;
                response.Data.PhoneNumber = parent.PhoneNumber;
                response.Data.Id = parent.Id.ToString();
                response.Data.UserName = parent.UserName;

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
