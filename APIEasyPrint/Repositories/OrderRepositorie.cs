using APIEasyPrint.APIModels;
using APIEasyPrint.Data;
using APIEasyPrint.Interfaces;
using APIEasyPrint.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections;
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
        public async Task<string> UpdateCustomerOrderStatusAsync(Guid orderId, double Total)
        {
            Order _ordr = applicationDbContext.orders.Find(orderId);
            _ordr.orderStatusStatusId = new Guid("33E0B0A3-4652-4AB7-9553-1E39711E9077");
            _ordr.deliveryStatusStatusId = new Guid("33E0B0A3-4652-4AB7-9553-1E30011E9077");
            _ordr.total = Total;

            applicationDbContext.orders.Update(_ordr);
            await applicationDbContext.SaveChangesAsync();
            return "success";
        }
        public async Task<string> UpdatePrinterOrderStatus(Guid orderId)
        {
            Order _ordr = applicationDbContext.orders.Find(orderId);
            _ordr.orderStatusStatusId = new Guid("33E0B0A3-4652-4AB7-9553-1E39788E9077");
            _ordr.deliveryStatusStatusId = new Guid("33E0B0A3-4652-4AB7-9553-1E39788E9077");

            applicationDbContext.orders.Update(_ordr);
            await applicationDbContext.SaveChangesAsync();
            return "success";
        }
        public async Task<string> UpdateDriverOrderStatus(Guid orderId)
        {
            Order _ordr = applicationDbContext.orders.Find(orderId);
            _ordr.orderStatusStatusId = new Guid("33E0B0A3-4652-4AB7-9553-1E39711E9077");
            _ordr.deliveryStatusStatusId = new Guid("33E0B0A3-4652-4AB7-9553-1E39711E9011");

            applicationDbContext.orders.Update(_ordr);
            await applicationDbContext.SaveChangesAsync();
            return "success";
        }
        public List<OrderApiModel.Response> GetOrdersByPrintingShopID(Guid printerId)
        {

            List<Item> items = applicationDbContext.items.Where(I => I.printingShopId == printerId).ToList();
            List<Item> itemsTemp  = new List<Item>();
            foreach (Item u1 in items)
            {
                bool duplicatefound = false;
                foreach (Item u2 in itemsTemp)
                    if (u1.orderId == u2.orderId)
                        duplicatefound = true;

                if (!duplicatefound)
                    itemsTemp.Add(u1);
            }
            List<OrderApiModel.Response> responses = itemsTemp.Select(i => new OrderApiModel.Response
            {
                Id = i.orderId.ToString(),
                address = applicationDbContext.addresses.Find(applicationDbContext.orders.Find(i.orderId).CustomerId),
                CustomerPhome = applicationDbContext.customers.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).PhoneNumber,
                itemId = i.itemId.ToString(),
                items = items.Where(I => I.orderId == i.orderId).Select(X => new OrderApiModel.ItemInfo
                {
                    ItemID=X.itemId.ToString(),
                    docID= X.docId.ToString(),
                    title = applicationDbContext.courceMaterials.Find(X.courceMaterialId).courceMaterialTitle,
                    CourseID = X.courceMaterialId.ToString(),
                    isProduct= X.isCourceMaterial,
                    isService=X.isPrintingOrder,
                    ItemPrice = X.totalPriceOfTheItem,
                    Description= X.ThePrintingDetailes
                } ).ToList(),

                orderStatusId = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).orderStatusStatusId).StatusNo,
                orderStatus = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).orderStatusStatusId).statusName,
                deliveryStatus = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).deliveryStatusStatusId).statusName,
                deliveryStatusId = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).deliveryStatusStatusId).StatusNo,
                orderDate = applicationDbContext.orders.Find(i.orderId).orderCreationDate,
                customerId = applicationDbContext.orders.Find(i.orderId).CustomerId.ToString(),
                customerName = applicationDbContext.customers.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).UserName,
                total = applicationDbContext.orders.Find(i.orderId).total,
            }
              
                ).ToList();

            return responses;
        }
        //public List<OrderApiModel.Response> GetOrdersByPrintingShopID(Guid printerId)
        //{

        //    List<Item> items = applicationDbContext.items.Where(I => I.printingShopId == printerId).ToList();
          
        //    List<OrderApiModel.Response> responses = items.Select(i => new OrderApiModel.Response
        //    {
        //        Id = i.orderId.ToString(),
        //        itemId = i.itemId.ToString(),
        //        orderStatusId = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).orderStatusStatusId).StatusNo,
        //        orderStatus = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).orderStatusStatusId).statusName,
        //        deliveryStatus = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).deliveryStatusStatusId).statusName,
        //        deliveryStatusId = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).deliveryStatusStatusId).StatusNo,
        //        orderDate = applicationDbContext.orders.Find(i.orderId).orderCreationDate,
        //        customerId = applicationDbContext.orders.Find(i.orderId).CustomerId.ToString(),
        //        customerName = applicationDbContext.customers.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).UserName,
        //        total = applicationDbContext.orders.Find(i.orderId).total,
        //    }
        //        ).ToList();


        //    return responses;
        //}
        public List<OrderApiModel.Response> GetOrdersByCustomerID(Guid CustomerId)
        {
            List<Order> Orders = applicationDbContext.orders.Where(I => I.CustomerId == CustomerId).ToList();

            List<OrderApiModel.Response> responses = Orders.Select(i => new OrderApiModel.Response
            {
                Id = i.orderId.ToString(),
                orderStatusId = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).orderStatusStatusId).StatusNo,
                orderStatus = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).orderStatusStatusId).statusName,
                deliveryStatus = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).deliveryStatusStatusId).statusName,
                deliveryStatusId = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).deliveryStatusStatusId).StatusNo,
                orderDate = applicationDbContext.orders.Find(i.orderId).orderCreationDate,
                customerId = applicationDbContext.orders.Find(i.orderId).CustomerId.ToString(),
                customerName = applicationDbContext.customers.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).UserName,
                total = applicationDbContext.orders.Find(i.orderId).total,
            }
                ).ToList();
            return responses;
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
                courseName = applicationDbContext.courceMaterials.Find(i.courceMaterialId).courceMaterialTitle,
                isCourceMaterial = i.isCourceMaterial,
                isPrintingOrder = i.isPrintingOrder,
                servicName = "طلب طباعة "
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


        public DriverOrders.Response GetFirstOrder(Guid PrinterId)
        {
            // List<Item> items = applicationDbContext.items.Where(I => I.printingShopId == PrinterId).ToList();




            //List< DriverOrders.Response> responses = items.Select(i => new DriverOrders.Response
            // {
            //     orderId = i.orderId.ToString(),
            //     adressLine= applicationDbContext.addresses.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).adressLine,
            //     city= applicationDbContext.addresses.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).city,
            //     CustomerEmail= applicationDbContext.customers.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).UserName,
            //     CustomerPhome= applicationDbContext.customers.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).PhoneNumber,
            //     neighborhood= applicationDbContext.addresses.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).neighborhood,
            //     street= applicationDbContext.addresses.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).street,
            //     total = applicationDbContext.orders.Find(i.orderId).total,
            //     deleveryStatusNumber = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).deliveryStatusStatusId).StatusNo,
            //     deleveryStatus = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).deliveryStatusStatusId).statusName
            // }
            //    ).ToList();


            List<Item> items = applicationDbContext.items.Where(I => I.printingShopId == PrinterId).ToList();
            List<Item> itemsTemp = new List<Item>();
            foreach (Item u1 in items)
            {
                bool duplicatefound = false;
                foreach (Item u2 in itemsTemp)
                    if (u1.orderId == u2.orderId)
                        duplicatefound = true;

                if (!duplicatefound)
                    itemsTemp.Add(u1);
            }
            List<DriverOrders.Response> responses = itemsTemp.Select(i => new DriverOrders.Response
            {
                orderId = i.orderId.ToString(),
                city = applicationDbContext.addresses.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).city,
                neighborhood = applicationDbContext.addresses.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).neighborhood,
                street = applicationDbContext.addresses.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).street,
                adressLine = applicationDbContext.addresses.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).adressLine,
                CustomerPhome = applicationDbContext.customers.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).PhoneNumber,               
                deleveryStatus = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).deliveryStatusStatusId).statusName,
                deleveryStatusNumber = applicationDbContext.statuses.Find(applicationDbContext.orders.Find(i.orderId).deliveryStatusStatusId).StatusNo,
                CustomerEmail = applicationDbContext.customers.Find(applicationDbContext.orders.Find(i.orderId).CustomerId).UserName,
                total = applicationDbContext.orders.Find(i.orderId).total,
            }
                ).ToList();

            return responses.FirstOrDefault(i => i.deleveryStatusNumber == 4);

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
                    numberOfItems = OrderDetailes.numberOfItems,
                    deliveryStatusStatusId=new Guid("33E0B0A3-4652-4AB7-9553-1E39767E9077"),
                    orderStatusStatusId = new Guid("33E0B0A3-4652-4AB7-9553-1E39767E9077"),
                    orderCreationDate = DateTime.Now
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
            if (OrderDetailes.isCourceMaterial == true) {
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
                    itemPrice = newItem.totalPriceOfTheItem,
                    orderId = newItem.orderId.ToString(),
                    printingShopID = newItem.printingShopId.ToString(),
                    errorMassage = "",

                };
                return rsulte;
            }
            else
            {
                Item newItem = new Item
                {
                    itemId = new Guid(),
                    orderId = new Guid(OrderDetailes.orderId),
                    isPrintingOrder = OrderDetailes.isPrintingOrder,
                    isCourceMaterial = OrderDetailes.isCourceMaterial,
                    courceMaterialId = new Guid("23C55B9B-8835-43A3-C7A5-08D8FCB452F0"), //defult null cource Material
                    docId = new Guid("AAAAAAAA-0101-0101-0101-C00000000000"), //defult null document
                    totalPriceOfTheItem = OrderDetailes.totalPriceOfTheItem,
                    printingShopId = new Guid(OrderDetailes.printingShopId),
                    ThePrintingDetailes = OrderDetailes.description
                };

                await applicationDbContext.items.AddAsync(newItem);
                await applicationDbContext.SaveChangesAsync();


                AddItemApiModel.ResponseByOneItem rsulte = new AddItemApiModel.ResponseByOneItem
                {
                    itemId = newItem.itemId.ToString(),
                    itemPrice = newItem.totalPriceOfTheItem,
                    orderId = newItem.orderId.ToString(),
                    printingShopID = newItem.printingShopId.ToString(),
                    errorMassage = "",

                };
                return rsulte;
            }
            

            }

        public async Task DeleteItem(Guid itemId)
        {
            Item newItem = new Item
            {
                itemId = itemId
            };

             applicationDbContext.items.Remove(newItem);
            await applicationDbContext.SaveChangesAsync();

        }
        public async Task<AddressApiModel.Response> PostNewAdress(AddressApiModel.Request address)
        {
            Address newAddress = new Address
            {
                UserId = new Guid(address.userId),
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
                userId = newAddress.UserId.ToString(),
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
                UserId = new Guid(address.userId),
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
                userId = newAddress.UserId.ToString(),
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
                userId = address.UserId.ToString(),
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

        public async Task<string> PostPromotionCode(PrivatePromotionCodeApiModel.Request promo)
        {
            PrivatePromotionCode privatePromotionCode = new PrivatePromotionCode
            {
                privatePromotionCodeId = new Guid(),
                privatePromotionCodeString = promo.privatePromotionCodeString,
                startDate = DateTime.Now,
                CustomerId = new Guid(promo.CustomerId),
                printingShopId = new Guid(promo.printingShopId),
                isExpired = false,
                isUsed = false
            };

          await    applicationDbContext.privatePromotionCodes.AddAsync(privatePromotionCode);
          await applicationDbContext.SaveChangesAsync();

           return "success";
        }

        public List<Notification> GetNotificationByParentID(Guid parentId)
        {
            List<Notification> notification = applicationDbContext.notifications.Where(I => I.parentId == parentId).ToList();

            return notification;
        }

        public List<Notification> GetNotificationByTeatcherID(Guid teatcherId)
        {
            List<Notification> notification = applicationDbContext.notifications.Where(I => I.teatcherId == teatcherId).ToList();

            return notification;
        }

        public List<Notification> GetAllNotification()
        {
            List<Notification> notification = applicationDbContext.notifications.ToList();

            return notification;
        }

        public List<GlobalNotification> GetAllGlobalNotification()
        {
            List<GlobalNotification> notification = applicationDbContext.globalNotifications.ToList();

            return notification;
        }

    }

  }