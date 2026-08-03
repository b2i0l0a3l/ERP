
using ERP.Core.Entities;
using ERP.Infrastructure.presistence.configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.presistence
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<ReturnItem> ReturnItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerPhoneNumber> CustomerPhoneNumbers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<StockAdjustmentLog> StockAdjustmentLogs { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // RefreshToken configuration
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(rt => rt.Id);
                entity.Property(rt => rt.Token).IsRequired().HasMaxLength(500);
                entity.Property(rt => rt.UserId).IsRequired().HasMaxLength(450);
                entity.Property(rt => rt.ExpiresAt).IsRequired();
                entity.Property(rt => rt.CreatedAt).IsRequired();
                entity.HasOne(rt => rt.User)
                      .WithMany()
                      .HasForeignKey(rt => rt.UserId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(rt => rt.Token).IsUnique();
                entity.HasIndex(rt => rt.UserId);
            });

            modelBuilder.ApplyConfiguration(new BrandConfig());
            modelBuilder.ApplyConfiguration(new ReturnConfig());
            modelBuilder.ApplyConfiguration(new ReturnItemConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new CustomerAddressConfig());
            modelBuilder.ApplyConfiguration(new CustomerPhoneNumberConfig());
            modelBuilder.ApplyConfiguration(new InventoryConfig());
            modelBuilder.ApplyConfiguration(new PaymentConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductImageConfig());
            modelBuilder.ApplyConfiguration(new PurchaseOrderConfig());
            modelBuilder.ApplyConfiguration(new PurchaseOrderItemConfig());
            modelBuilder.ApplyConfiguration(new SaleOrderConfig());
            modelBuilder.ApplyConfiguration(new SaleOrderItemConfig());
            modelBuilder.ApplyConfiguration(new SettingConfig());
            modelBuilder.ApplyConfiguration(new WarehouseConfig());
            modelBuilder.ApplyConfiguration(new StockAdjustmentLogConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfig());
            modelBuilder.ApplyConfiguration(new InvoiceItemConfig());
            modelBuilder.ApplyConfiguration(new NotificationConfig());
        }
    }   
}