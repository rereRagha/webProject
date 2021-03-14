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

            //List<Item> AllOrderItems = applicationDbContext.items.Where(I => I.orderId == new Guid(OrderDetailes.orderId)).ToList();
            //AddItemApiModel.Response rsulte = new AddItemApiModel.Response
            //{
            //    orderId = OrderDetailes.orderId.ToString(),
            //    Items = AllOrderItems.Select(i => new AddItemApiModel.itemView
            //    {
            //        itemId = i.itemId.ToString(),
            //        itemPrice = i.totalPriceOfTheItem,
            //        printingShopID = i.printingShopId.ToString()
            //    }
            //).ToList(),
            //};

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
        }




  }