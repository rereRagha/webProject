using APIEasyPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Interfaces
{
    public interface IAdminInterface
    {
        public Admin GetAdminDetailes(Guid PrinterId);
        public Task<Admin> PostAdminDetailes(Admin NewAdminDetailes);
        public Task<Customer> PostCustomerDetailes(Customer NewCustomer);
    }
}
