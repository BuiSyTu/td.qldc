using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.Core.Api.Mvc.Integration;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories;
using Unity;

namespace TD.QLDC.API.Integration
{
    public sealed class QLDCApiModule : IApiModule
    {
        public string GetPrefix()
        {
            return "QLDCapi";
        }

        public ICollection<Assembly> GetAssemblies()
        {
            return new Assembly[] { typeof(QLDCApiModule).Assembly };
        }

        public void RegisterApiConfig(HttpRouteCollection routes)
        {
            //routes.MapHttpRoute(
            //    name: "QLDCApi",
            //    routeTemplate: "QLDCapi/{controller}/{action}/{id}",
            //    defaults: new { controller="Home", action="Index", id = RouteParameter.Optional }
            //);
        }

        public void RegisterDIConfig(UnityContainer container)
        {
            // repositories
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IHoKhauRepository, HoKhauRepository>();
            container.RegisterType<INhanKhauRepository, NhanKhauRepository>();
            container.RegisterType<INhomDanhMucRepository, NhomDanhMucRepository>();
            container.RegisterFactory<QLDCDbContext>(c => new QLDCDbContext());
            // services
            container.RegisterFactory<ICoreServicesProvider>(c => new DefaultContextCoreServicesProvider());
            container.RegisterType<ICoreContextAccessor, AspNetCoreContextAccessor>();
            
        }
    }
}
