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

    public class PrintingShopController : ControllerBase
    {

        private readonly IPrintingShopsInterface _printingShops;
        public PrintingShopController(IPrintingShopsInterface _printingShops)
        {
            this._printingShops = _printingShops;
        }


        // GET: api/<PrintingShopController>
        [HttpGet]
        public async Task<List<PrintingShopApiMode.Response>> Get()
        {
             
            List < PrintingShopApiMode.Response > printingShops = await _printingShops.GtAllPrintingShops();
            return printingShops;
        }

        // GET api/<PrintingShopController>/5
        [HttpGet("{id}")]
        public PrintingShopApiMode.Response Get(string id)
        {
            PrintingShopApiMode.Response printingShop = _printingShops.GetPrintingShopDetailes(new Guid(id));
            return printingShop;
        } 

        // POST api/<PrintingShopController>
        [HttpPost]
        public async Task<ActionResult<ApiRespnse<PrintingShopApiMode.Response>>> PostAsync(PrintingShopApiMode.Request request)
        {
            var response = new ApiRespnse<PrintingShopApiMode.Response>();
            var NewPrinter = new PrintingShop()
            {
                prentingShopId = Guid.NewGuid(),
                prenterName = request.prenterName,
                ownerId = request.ownerId,
                isCourseMaterial = request.isCourseMaterial,
                isService = request.isService
            };
            var resulte = await _printingShops.PostPrintingShopDetailes(NewPrinter);
            response.Data = new PrintingShopApiMode.Response()
            {
                 prentingShopId = resulte.prentingShopId.ToString(),
                 prenterName = resulte.prenterName,
                 isCourseMaterial= resulte.isCourseMaterial,
                 isService= resulte.isService,
                 ownerId = resulte.ownerId
            };

            return Ok(response);
        }

        // PUT api/<PrintingShopController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrintingShopController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
