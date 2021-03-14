﻿using APIEasyPrint.APIModels;
using APIEasyPrint.Data;
using APIEasyPrint.Interfaces;
using APIEasyPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Repositories
{
    public class UsesRepositorie :IAdminInterface
    {
        private readonly ApplicationDbContext applicationDbContext;

        public UsesRepositorie (ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;

        }
        public  Admin GetAdminDetailes(Guid AdminId)
        {

            Admin admin =  applicationDbContext.admins.Find(AdminId);


            return admin;
        }
        public DeliveryDriver GetDriverDetailes(Guid DriverId)
        {

            DeliveryDriver driver = applicationDbContext.deliveryDrivers.Find(DriverId);


            return driver;
        }
        public Customer FindCustomerByEmail(string customerEmail)
        {
            var customer = applicationDbContext.customers.FirstOrDefault(x => x.Email == customerEmail);
           
            return customer;
        }
        public DeliveryDriver FindDriverByEmail(string  driverEmail)
        {
            DeliveryDriver driver = applicationDbContext.deliveryDrivers.FirstOrDefault(x => x.Email == driverEmail);

            return driver;
        }
        public async Task< Admin> PostAdminDetailes(Admin NewAdminDetailes)
        {

            Admin admin = new Admin()
            {

            };

            await applicationDbContext.admins.AddAsync(admin);
            await applicationDbContext.SaveChangesAsync();

            return admin;
        }
        public async Task<Customer> PostCustomerDetailes(Customer NewCustomer)
        {

            

            await applicationDbContext.customers.AddAsync(NewCustomer);
            await applicationDbContext.SaveChangesAsync();

            return NewCustomer;
        }

        public async Task UpdateCustomerDetailes(UpdateCustomerInfoApiModel.Request updatedCustomer)
        {
            Customer customer = new Customer
            {
                Id =new Guid(updatedCustomer.Id),
                EmailConfirmed = updatedCustomer.EmailConfiremd,
                Email= updatedCustomer.Email,
                PhoneNumber=updatedCustomer.PhoneNumber,
                UserName= updatedCustomer.UserName
              };
            applicationDbContext.customers.Update(customer);
            await applicationDbContext.SaveChangesAsync();

        }



    }
}
