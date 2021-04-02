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
        public Task<AddItemApiModel.Response> PostOrderDetailes(AddItemApiModel.Request OrderDetailes);
        public Task<AddItemApiModel.ResponseByOneItem> PostItemsDetailes(AddItemApiModel.Request OrderDetailes);
        public void UpdateItemForignKey(Guid itemId, Guid orderId);
        public  Task<AddressApiModel.Response> PostNewAdress(AddressApiModel.Request address);
        public  Task<AddressApiModel.Response> UpdateAdress(AddressApiModel.Request address);
        public AddressApiModel.Response GetAddress(Guid UserId);
        public Task DeleteItem(Guid itemId);
        public List<PrivatePromotionCodeApiModel.Response> GetPromotionCode(Guid UserId);
        public List<OrderApiModel.Response> GetOrdersByPrintingShopID(Guid orderId);


    }
}
