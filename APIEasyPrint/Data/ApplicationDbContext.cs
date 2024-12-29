
using APIEasyPrint.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<CheckoutDetailes> checkoutDetailes { get; set; }
        public DbSet<CourceMaterial> courceMaterials { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<DeliverOptions> deliverOptions { get; set; }
        public DbSet<DeliveryDriver> deliveryDrivers { get; set; }
        public DbSet<Document> documents { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<PrintingShop> printingShops { get; set; }
        public DbSet<PrivatePromotionCode> privatePromotionCodes { get; set; }
        public DbSet<ProblemReports> problemReports { get; set; }
        public DbSet<PublicPromotionCode> publicPromotionCodes { get; set; }
        public DbSet<SellUnit> sellUnits { get; set; }
        public DbSet<Service> services { get; set; }

        public DbSet<ServiceDetails> serviceDetails { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Suggestion> suggestions { get; set; }
        public DbSet<Images> images { get; set; }

        public DbSet<Notification> notifications { get; set; }
        public DbSet<GlobalNotification> globalNotifications { get; set; }
        public DbSet<Parent> parents { get; set; }
        public DbSet<Teatcher> teatchers{ get; set; }


    }

}

