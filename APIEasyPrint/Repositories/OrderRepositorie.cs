using APIEasyPrint.APIModels;
using APIEasyPrint.Data;
using APIEasyPrint.Interfaces;
using APIEasyPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Repositories
{
    public class OrderRepositorie : IOrdersInterface
    {
        private readonly ApplicationDbContext applicationDbContext;
        public OrderRepositorie(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;

        }

        public List<AddItemApiModel.itemView> GetOrderDetailes(Guid orderId)
        {

            //get the oder info 
            Order currentOrder = applicationDbContext.orders.Find(orderId);
            //get the Items related to the order
            List<Item> AllOrderItems  = applicationDbContext.items.Where(I => I.orderId == orderId).ToList();

            // fixes 
            List<AddItemApiModel.itemView> OrderItems = AllOrderItems.Select(i => new AddItemApiModel.itemView
            {
                itemId = i.itemId.ToString(),
                itemPrice = i.totalPriceOfTheItem,
                printingShopID = i.printingShopId.ToString(),
                courseID = i.courceMaterialId.ToString(),
                courseName = applicationDbContext.courceMaterials.Find(i.courceMaterialId).courceMaterialTitle
            }
                ).ToList();

            return OrderItems;
        }


        public async void UpdateItemForignKey(Guid itemId, Guid orderId)
        {
            Item newItem = new Item
            {
                itemId = itemId,
                orderId = orderId,

            };
            applicationDbContext.items.Update(newItem);
            await applicationDbContext.SaveChangesAsync();

        }


        public async Task<AddItemApiModel.Response> PostOrderDetailes(AddItemApiModel.Request OrderDetailes)
        {
            if(OrderDetailes.orderId == null || OrderDetailes.orderId == "")
            {
                Order order = new Order
                {
                    orderId = new Guid(),
                    total = OrderDetailes.totalPriceOfTheItem,
                    CustomerId = new Guid(OrderDetailes.customerId),
                    numberOfItems = OrderDetailes.numberOfItems
                };
                
                await applicationDbContext.orders.AddAsync(order);
                await applicationDbContext.SaveChangesAsync();


                List<Item> AllOrderItems = applicationDbContext.items.Where(I => I.orderId == order.orderId).ToList();
                AddItemApiModel.Response rsulte = new AddItemApiModel.Response
                {
                    orderId = order.orderId.ToString(),
                    Items = AllOrderItems.Select(i => new AddItemApiModel.itemView
                    {
                        itemId = i.itemId.ToString(),
                        itemPrice = i.totalPriceOfTheItem,
                        printingShopID = i.printingShopId.ToString()
                    }
                ).ToList(),
                };
                return rsulte;
            }
            else
            {
                Order order = new Order
                {
                    orderId = new Guid(OrderDetailes.orderId),
                    CustomerId = new Guid(OrderDetailes.customerId),
                    total = OrderDetailes.totalPriceOfTheItem
                };

                 applicationDbContext.orders.Update(order);
                 await applicationDbContext.SaveChangesAsync();

                List<Item> AllOrderItems = applicationDbContext.items.Where(I => I.orderId == order.orderId).ToList();
                AddItemApiModel.Response rsulte = new AddItemApiModel.Response
                {
                    orderId = order.orderId.ToString(),
                    Items = AllOrderItems.Select(i => new AddItemApiModel.itemView
                    {
                        itemId = i.itemId.ToString(),
                        itemPrice = i.totalPriceOfTheItem,
                        printingShopID = i.printingShopId.ToString()
                    }
                ).ToList(),
                };
                return rsulte;

            }
        }

        public async Task<AddItemApiModel.ResponseByOneItem> PostItemsDetailes(AddItemApiModel.Request OrderDetailes)
        {
                Item newItem = new Item
                {
                    itemId = new Guid(),
                    orderId = new Guid(OrderDetailes.orderId),
                    isPrintingOrder = OrderDetailes.isPrintingOrder,
                    isCourceMaterial = OrderDetailes.isCourceMaterial,
                    courceMaterialId = new Guid(OrderDetailes.courseId),
                    docId = new Guid(OrderDetailes.docId),
                    totalPriceOfTheItem = OrderDetailes.totalPriceOfTheItem,
                    printingShopId = new Guid(OrderDetailes.printingShopId)
                };
                
                await applicationDbContext.items.AddAsync(newItem);
                await applicationDbContext.SaveChangesAsync();


            AddItemApiModel.ResponseByOneItem rsulte = new AddItemApiModel.ResponseByOneItem
            {
                itemId = newItem.itemId.ToString(),
                itemPrice=newItem.totalPriceOfTheItem,
                orderId=newItem.orderId.ToString(),
                printingShopID=newItem.printingShopId.ToString(),
                errorMassage="",
                
            };
                return rsulte;

            }


        public async Task<AddressApiModel.Response> PostNewAdress(AddressApiModel.Request address)
        {
            Address newAddress = new Address
            {
                invoiceId = new Guid(address.userId),
                country = address.country,
                city = address.city,
                postcode = address.postcode,
                adressLine = address.adressLine,
                neighborhood = address.neighborhood,
                street =address.street
            };

            await applicationDbContext.addresses.AddAsync(newAddress);
            await applicationDbContext.SaveChangesAsync();


            AddressApiModel.Response rsulte = new   AddressApiModel.Response
            {
                userId = newAddress.invoiceId.ToString(),
                country = address.country,
                city = address.city,
                postcode = address.postcode,
                adressLine = address.adressLine,
                neighborhood = address.neighborhood,
                street = address.street

            };
            return rsulte;

        }
        public async Task<AddressApiModel.Response> UpdateAdress(AddressApiModel.Request address)
        {
            Address newAddress = new Address
            {
                invoiceId = new Guid(address.userId),
                country = address.country,
                city = address.city,
                postcode = address.postcode,
                adressLine = address.adressLine,
                neighborhood = address.neighborhood,
                street = address.street
            };

            applicationDbContext.addresses.Update(newAddress);
            await applicationDbContext.SaveChangesAsync();

            AddressApiModel.Response rsulte = new AddressApiModel.Response
            {
                userId = newAddress.invoiceId.ToString(),
                country = address.country,
                city = address.city,
                postcode = address.postcode,
                adressLine = address.adressLine,
                neighborhood = address.neighborhood,
                street = address.street

            };
            return rsulte;

        }
        public AddressApiModel.Response GetAddress(Guid UserId)
        {

            //get the oder info 
            Address address = applicationDbContext.addresses.Find(UserId);


            AddressApiModel.Response rsulte = new AddressApiModel.Response
            {
                userId = address.invoiceId.ToString(),
                country = address.country,
                city = address.city,
                postcode = address.postcode,
                adressLine = address.adressLine,
                neighborhood = address.neighborhood,
                street = address.street

            };
            return rsulte;
        }

        public List<PrivatePromotionCodeApiModel.Response> GetPromotionCode(Guid UserId)
        {

            //get the oder info 
            List<PrivatePromotionCode> AllCodes = applicationDbContext.privatePromotionCodes.Where(I => I.CustomerId == UserId).ToList();

            List<PrivatePromotionCodeApiModel.Response> resulte = AllCodes.Select(i => new PrivatePromotionCodeApiModel.Response
            {
                privatePromotionCodeId = i.privatePromotionCodeId.ToString(),
                privatePromotionCodeString = i.privatePromotionCodeString,
                startDate = i.startDate,
                expireDate = i.expireDate,
                isExpired = i.isExpired,
                isUsed = i.isUsed,
                CustomerId = i.CustomerId.ToString(),
                printingShopId = i.printingShopId.ToString()
            }
                ).ToList();
            return resulte;
        }




    }




  }