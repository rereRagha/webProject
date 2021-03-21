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
    public class PrintingShopRigesterController : ControllerBase
    {

        private readonly IPrintingShopsInterface _printerInterface;
        public PrintingShopRigesterController(IPrintingShopsInterface _printerInterface)
        {
            this._printerInterface = _printerInterface;
        }

        // GET: api/<PrintingShopRigesterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PrintingShopRigesterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SignInController>
        [HttpPost]
        public async Task<ActionResult<ApiRespnse<PrintingShopRegisterApiModel.Response>>> PostAsync(PrintingShopRegisterApiModel.Request request)
        {

            var response = new ApiRespnse<PrintingShopRegisterApiModel.Response>();

            if (await checkEmail(request.Email))
            {
                return response;
            }

            var appUser = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = request.Email,
                UserName = request.FullName,
                PasswordHash = request.PasswordHash,
                PhoneNumber = request.PhoneNumber
            };

            await _printerInterface.PostOwnerDetailes(appUser);


            response.Data = new PrintingShopRegisterApiModel.Response()
            {
                PhoneNumber = appUser.PhoneNumber,
                FullName = appUser.UserName,
                Email = appUser.Email,
                EmailConfiremd = appUser.EmailConfirmed,
                Id = appUser.Id.ToString()
            };

            return Ok(response);

        }


        // PUT api/<PrintingShopRigesterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrintingShopRigesterController>/5
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
