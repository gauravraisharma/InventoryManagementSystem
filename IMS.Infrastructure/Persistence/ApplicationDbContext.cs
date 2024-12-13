using System.Reflection.Emit;
using IMS.Core.Entities;
using IMS.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
                                                IdentityUserClaim<string>, ApplicationUserRole,
                                                IdentityUserLogin<string>, IdentityRoleClaim<string>,
                                                IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }
      
        public DbSet<Product> Products { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<DepartmentProductMapping> DepartmentProductMappings { get; set; }
        public DbSet<CategoryProductMapping> CategoryProductMappings { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Identity Tables Configuration
            builder.Entity<ApplicationUser>().ToTable("AspNetUser").Property(p => p.Id).HasColumnName("Id");
            builder.Entity<ApplicationUserRole>().ToTable("AspNetUserRole");
            builder.Entity<ApplicationRole>().ToTable("AspNetRole");

            builder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });
                entity.HasOne(e => e.User)
                      .WithMany(u => u.UserRoles)
                      .HasForeignKey(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Role)
                      .WithMany()
                      .HasForeignKey(e => e.RoleId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // CategoryProductMapping Configuration (Many-to-Many)
            builder.Entity<CategoryProductMapping>()
                .HasKey(cpm => new { cpm.CategoryId, cpm.ProductId });

            builder.Entity<CategoryProductMapping>()
                .HasOne(cpm => cpm.Category)
                .WithMany(c => c.CategoryProductMappings)
                .HasForeignKey(cpm => cpm.CategoryId);

            builder.Entity<CategoryProductMapping>()
                .HasOne(cpm => cpm.Product)
                .WithMany()
                .HasForeignKey(cpm => cpm.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // DepartmentProductMapping Configuration (Many-to-Many)
            builder.Entity<DepartmentProductMapping>()
                .HasKey(dpm => new { dpm.DepartmentId, dpm.ProductId });

            builder.Entity<DepartmentProductMapping>()
                .HasOne(dpm => dpm.Department)
                .WithMany(d => d.DepartmentProductMapping)
                .HasForeignKey(dpm => dpm.DepartmentId);

            builder.Entity<DepartmentProductMapping>()
                .HasOne(dpm => dpm.Product)
                .WithMany()
                .HasForeignKey(dpm => dpm.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProductImages Relationships
            builder.Entity<ProductImages>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pi => pi.ProductId);

            // ProductSize Relationships
            builder.Entity<ProductSize>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(ps => ps.ProductId);

            // Orders Relationships
            builder.Entity<Orders>()
                .HasOne(o => o.Product)
                .WithMany()
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Orders>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Decimal Precision Configuration
            builder.Entity<Orders>()
                .Property(o => o.Amount)
                .HasPrecision(18, 2);

            builder.Entity<Product>()
                .Property(p => p.UnitPrice)
                .HasPrecision(18, 2);

            // Seed Roles
            SeedRoles(builder);

            builder.Entity<Cart>()
         .HasIndex(c => new { c.UserId, c.ProductId, c.ProductSizeId })
         .IsUnique(); 

            builder.Entity<Cart>()
                .HasOne(c => c.ProductSize)
                .WithMany()
                .HasForeignKey(c => c.ProductSizeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            var adminRole = new ApplicationRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var userRole = new ApplicationRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "user",
                NormalizedName = "USER"
            };

            builder.Entity<ApplicationRole>().HasData(adminRole, userRole);
        }
    }
}
