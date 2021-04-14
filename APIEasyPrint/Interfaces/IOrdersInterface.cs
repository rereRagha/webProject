using APIEasyPrint.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Interfaces
{
    public interface IOrdersInterface
    {
        public List<AddItemApiModel.itemView> GetOrderDetailes(Guid orderId);
        public List<OrderApiModel.Response> GetOrdersByCustomerID(Guid CustomerId);
        public Task<AddItemApiModel.Response> PostOrderDetailes(AddItemApiModel.Request OrderDetailes);
        public Task<AddItemApiModel.ResponseByOneItem> PostItemsDetailes(AddItemApiModel.Request OrderDetailes);
        public void UpdateItemForignKey(Guid itemId, Guid orderId);
        public Task<string> UpdateCustomerOrderStatusAsync(Guid orderId, double Total);
        public  Task<string> UpdatePrinterOrderStatus(Guid orderId);
        public  Task<string> UpdateDriverOrderStatus( Guid orderId);

        public Task<AddressApiModel.Response> PostNewAdress(AddressApiModel.Request address);
        public  Task<AddressApiModel.Response> UpdateAdress(AddressApiModel.Request address);
        public AddressApiModel.Response GetAddress(Guid UserId);
        public Task DeleteItem(Guid itemId);
        public List<PrivatePromotionCodeApiModel.Response> GetPromotionCode(Guid UserId);
        public Task<string> PostPromotionCode(PrivatePromotionCodeApiModel.Request promo); 
        public List<OrderApiModel.Response> GetOrdersByPrintingShopID(Guid orderId);


    }
}
