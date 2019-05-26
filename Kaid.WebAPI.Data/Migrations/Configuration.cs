namespace Kaid.WebAPI.Data.Migrations
{
    using Kaid.WebAPI.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Kaid.WebAPI.Data.KaidDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Kaid.WebAPI.Data.KaidDbContext context)
        {
            CreateProductCategorySample(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //var manager = new UserManager<ApplicationUser>
            //    (new UserStore<ApplicationUser>(new KaidDbContext()));

            //var roleManger = new RoleManager<IdentityRole>
            //    (new RoleStore<IdentityRole>(new KaidDbContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "Kaid",
            //    Email = "cooleen.cl@gmail.com",
            //    EmailConfirmed = true,
            //    Birthday = DateTime.Now,
            //    FullName = "Kaid Duong"
            //};

            //manager.Create(user, "123456$");

            //if (!roleManger.Roles.Any())
            //{
            //    roleManger.Create(new IdentityRole { Name = "Admin" });
            //    roleManger.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("cooleen.cl@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(Kaid.WebAPI.Data.KaidDbContext dbContext)
        {
            List<ProductCategory> productCategories = new List<ProductCategory>()
            {
                new ProductCategory()
                {CreateDate=DateTime.Now,
                    Name="Category5",
                    Alias="Category5",
                    Status=true
                },
                 new ProductCategory()
                {CreateDate=DateTime.Now,
                    Name="Category6",
                    Alias="Category6",
                    Status=true
                },
                new ProductCategory()
                {CreateDate=DateTime.Now,
                    Name="Category7",
                    Alias="Category7",
                    Status=false
                },
                new ProductCategory()
                {CreateDate=DateTime.Now,
                    Name="Category8",
                    Alias="Category8",
                    Status=true
                } ,
                    new ProductCategory()
                {CreateDate=DateTime.Now,
                    Name="Category9",
                    Alias="Category9",
                    Status=false
                },
                new ProductCategory()
                {
                    CreateDate=DateTime.Now,
                    Name="Category10",
                    Alias="Category10",
                    Status=true
                }
            };
            dbContext.ProductCategories.AddRange(productCategories);
            dbContext.SaveChanges();
        }
    }
}
}