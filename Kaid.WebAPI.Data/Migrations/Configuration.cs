namespace Kaid.WebAPI.Data.Migrations
{
    using Kaid.WebAPI.Model.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

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
            if (dbContext.PostCategories.Count() == 0)
           {
                List<ProductCategory> productCategories = new List<ProductCategory>()
            {
                new ProductCategory()
                {
                    Name="Category1",
                    Alias="Category1",
                    Status=true
                },
                 new ProductCategory()
                {
                    Name="Category2",
                    Alias="Category2",
                    Status=true
                },
                new ProductCategory()
                {
                    Name="Category3",
                    Alias="Category3",
                    Status=true
                },
                new ProductCategory()
                {
                    Name="Category4",
                    Alias="Category4",
                    Status=true
                }
            };
                dbContext.ProductCategories.AddRange(productCategories);
                dbContext.SaveChanges();
            }
        }
    }
}