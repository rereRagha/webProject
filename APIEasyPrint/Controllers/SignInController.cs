using APIEasyPrint.APIModels;
using APIEasyPrint.Interfaces;
using APIEasyPrint.Models;
using Microsoft.AspNetCore.Identity;
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
    public class SignInController : ControllerBase
    {

        private readonly IAdminInterface _adminInterface;
        public SignInController(IAdminInterface _adminInterface)
        {
            this._adminInterface = _adminInterface;
        }

        // GET: api/<SignInController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SignInController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SignInController>
        [HttpPost]
        public async Task<ActionResult<ApiRespnse<SignInApiModel.Response>>> PostAsync(SignInApiModel.Request request)
        {

            var response = new ApiRespnse<SignInApiModel.Response>();

            if (await checkEmail(request.Email))
            {
                return response;
            }

            var appUser = new Customer()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.Email,
                PasswordHash = request.PasswordHash,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _adminInterface.PostCustomerDetailes(appUser);


            response.Data = new SignInApiModel.Response()
            {
                PhoneNumber = appUser.PhoneNumber,
                UserName=appUser.UserName,
                Email=appUser.Email,
                EmailConfiremd=appUser.EmailConfirmed,
                Id=appUser.Id.ToString()
            };

            return Ok(response);

        }

        // PUT api/<SignInController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SignInController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private async Task<bool> checkEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
