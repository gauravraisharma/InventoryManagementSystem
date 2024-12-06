using IMS.Core.Entities;
using IMS.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace IMS.Infrastructure.Persistence
{
    public class ApplicationDbContext:IdentityDbContext< 
        ApplicationUser , ApplicationRole, string, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("AspNetUser").Property(p => p.Id).HasColumnName("Id");
            builder.Entity<ApplicationUserRole>().ToTable("AspNetUserRole");
            builder.Entity<ApplicationUserLogin>().ToTable("AspNetUserLogin");
            builder.Entity<ApplicationUserClaim>().ToTable("AspNetUserClaim");
            builder.Entity<ApplicationRole>().ToTable("AspNetRole");
            builder.Entity<ApplicationRoleClaim>().ToTable("AspNetRoleClaim");
            builder.Entity<ApplicationUserToken>().ToTable("AspNetUserToken");

            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
                    builder.Entity<ApplicationRoleClaim>()
                    .HasOne<ApplicationRole>()
                    .WithMany()
                    .HasForeignKey(rc => rc.RoleId)
                    .OnDelete(DeleteBehavior.Restrict); 

                    builder.Entity<ApplicationUserClaim>()
                    .HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(uc => uc.UserId)
                    .OnDelete(DeleteBehavior.Restrict); 

                    builder.Entity<ApplicationUserLogin>()
                    .HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(login => login.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                    builder.Entity<ApplicationUserRole>()
                   .HasOne<ApplicationRole>()
                   .WithMany()
                   .HasForeignKey(userRole => userRole.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

                    builder.Entity<ApplicationUserRole>()
                   .HasOne<ApplicationUser>()
                   .WithMany()
                   .HasForeignKey(userRole => userRole.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

                    builder.Entity<ApplicationUserToken>()
                    .HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(userToken => userToken.UserId)
                    .OnDelete(DeleteBehavior.Restrict);


            // Product to CategoryProductMapping (Many-to-Many)
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




            // ProductImages entity configuration
            builder.Entity<ProductImages>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pi => pi.ProductId);

            // ProductSize entity configuration
            builder.Entity<ProductSize>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(ps => ps.ProductId);

            // Orders entity configuration
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
            base.OnModelCreating(builder);
        }

    }
}










