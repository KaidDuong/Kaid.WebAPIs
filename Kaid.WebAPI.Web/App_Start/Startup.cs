using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Kaid.WebAPI.Data;
using Kaid.WebAPI.Data.Infrastructure;
using Kaid.WebAPI.Data.Repositories;
using Kaid.WebAPI.Model.Models;
using Kaid.WebAPI.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using static Kaid.WebAPI.Web.App_Start.IdentityConfig;

[assembly: OwinStartup(typeof(Kaid.WebAPI.Web.App_Start.Startup))]

namespace Kaid.WebAPI.Web.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
            ConfigureAuth(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            // Register MVC controllers
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //register for your Web Api controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // builder.RegisterType<Type>().As<IType>();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<KaidDbContext>().AsSelf().InstancePerRequest();

            //Asp.net Identity
            builder.RegisterType<ApplicationUserStore>()
                .As<IUserStore<ApplicationUser>>()
                .InstancePerRequest();
           
            builder.RegisterType<ApplicationUserManager>()
                .AsSelf().InstancePerRequest();

            builder.RegisterType<ApplicationSignInManager>()
                .AsSelf().InstancePerRequest();

            builder.Register
                (k => HttpContext.Current.GetOwinContext()
                .Authentication).InstancePerRequest();

            builder.Register
                (k => app.GetDataProtectionProvider())
                .InstancePerRequest();

            //Repositories
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(k => k.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            //Services
            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly)
                .Where(k => k.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            // Set the MVC dependencyResolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //set the API DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}