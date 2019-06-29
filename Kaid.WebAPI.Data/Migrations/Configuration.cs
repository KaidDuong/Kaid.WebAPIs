namespace Kaid.WebAPI.Data.Migrations
{
    using Kaid.WebAPI.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
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

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            CreateProductCategorySample(context);
            CreateSlide(context);
        }

        private void CreateUser(KaidDbContext dbContext)
        {
            var manager = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(new KaidDbContext()));

            var roleManger = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(new KaidDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "Kaid",
                Email = "cooleen.cl@gmail.com",
                EmailConfirmed = true,
                Birthday = DateTime.Now,
                FullName = "Kaid Duong"
            };

            manager.Create(user, "123456$");

            if (!roleManger.Roles.Any())
            {
                roleManger.Create(new IdentityRole { Name = "Admin" });
                roleManger.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("cooleen.cl@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
        private void CreateProductCategorySample(Kaid.WebAPI.Data.KaidDbContext dbContext)
        {
            if (dbContext.ProductCategories.Count() == 0)
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
        private void CreateSlide(KaidDbContext dbContext)
        {
            if (dbContext.Slides.Count() == 0) {
                List<Slide> slides = new List<Slide>(){
                new Slide {
                    Name= "slide 1",
                    Alias="slide-1",
                    Status=true,
                    DisplayOrder=1,
                    Image="/Assets/client/images/bag.jpg",
                    Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=""on-get"">GET NOW</span>"
                },
                new Slide {
                    Name= "slide 2",
                    Alias="slide-2",
                    Status=true,
                    DisplayOrder=2,
                    Image="/Assets/client/images/bag1.jpg",
                    Content=@"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=""on-get"">GET NOW</span>"
                }
            };
                dbContext.Slides.AddRange(slides);
                dbContext.SaveChanges();
            } 
        }
    }
}
