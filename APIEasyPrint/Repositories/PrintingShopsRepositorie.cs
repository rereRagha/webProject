using APIEasyPrint.APIModels;
using APIEasyPrint.Data;
using APIEasyPrint.Interfaces;
using APIEasyPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIEasyPrint.Repositories
{
    public class PrintingShopsRepositorie : IPrintingShopsInterface
    {
        private readonly ApplicationDbContext applicationDbContext;
        public PrintingShopsRepositorie(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;

        }
        public PrintingShopApiMode.Response GetPrintingShopDetailes(Guid PrinterId)
        {
           
                PrintingShop printingShop = applicationDbContext.printingShops.Find(PrinterId);
                PrintingShopApiMode.Response rsulte = new PrintingShopApiMode.Response
                {
                    prenterName = printingShop.prenterName,
                    ownerId = printingShop.ownerId, 
                    isService= printingShop.isService,
                    isCourseMaterial= printingShop.isCourseMaterial,
                    prentingShopId = printingShop.prentingShopId.ToString()

                };

                return rsulte;
        }

        public CourceMaterialApiModel.Response GetCourceMaterialDetailes(Guid CourceId)
        {

            CourceMaterial courceMaterial = applicationDbContext.courceMaterials.Find(CourceId);

            CourceMaterialApiModel.Response rsulte = new CourceMaterialApiModel.Response
            {
                courceMaterialId = courceMaterial.courceMaterialId,
                printingShopId = courceMaterial.printingShopId,
                isAvailable = courceMaterial.isAvailable,
                SubjectId = courceMaterial.SubjectId,
                courceMaterialDescreption = courceMaterial.courceMaterialDescreption,
                 courceMaterialPrice = courceMaterial.courceMaterialPrice

            };

            return rsulte;
        }
        public async Task<PrintingShop> PostPrintingShopDetailes(PrintingShop NewPrintirDetailes)
        {
            
                await applicationDbContext.printingShops.AddAsync(NewPrintirDetailes);
                await applicationDbContext.SaveChangesAsync();
                return NewPrintirDetailes;


        }
        public async Task<List<PrintingShopApiMode.Response>> GtAllPrintingShops()
        {
      
            

                 List<PrintingShop> printingShops = applicationDbContext.printingShops.ToList();
                 List<PrintingShopApiMode.Response> result = printingShops.Select(q => new PrintingShopApiMode.Response
                 {
                         prentingShopId = q.prentingShopId.ToString(),
                         prenterName = q.prenterName,
                         ownerId = q.ownerId,
                         isCourseMaterial= q.isCourseMaterial,
                         isService=q.isService
                 }).ToList();

                   return result;
           


        }

        public async Task<List<CourceMaterial>> GetMaterialsByID(Guid printerId)
        {
            try
            {

                List<CourceMaterial> courceMaterial = applicationDbContext.courceMaterials.Where(x => x.printingShopId == printerId).ToList();
                return courceMaterial;
            }
            catch (Exception e)
            {
                return null;
            }


        }

    }
}
