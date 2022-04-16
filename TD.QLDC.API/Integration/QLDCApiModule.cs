using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using TD.Core.Api.Mvc;
using TD.Core.Api.Mvc.Integration;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Implementations;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.Services.Implementations;
using TD.QLDC.Library.Services.Interfaces;
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
            // Data
            container.RegisterFactory<QLDCDbContext>(c => new QLDCDbContext());

            // Repositories
            container.RegisterType<IAreaRepository, AreaRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IHoKhauRepository, HoKhauRepository>();
            container.RegisterType<INhanKhauRepository, NhanKhauRepository>();
            container.RegisterType<INhomDanhMucRepository, NhomDanhMucRepository>();
            container.RegisterType<IAccountRepository, AccountRepository>();

            // Services
            container.RegisterType<IDashboardService, DashboardService>();
            container.RegisterType<IUploadService, UploadService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IHoKhauService, HoKhauService>();
            container.RegisterType<INhanKhauService, NhanKhauService>();

            // Others
            container.RegisterFactory<ICoreServicesProvider>(c => new DefaultContextCoreServicesProvider());
            container.RegisterType<ICoreContextAccessor, AspNetCoreContextAccessor>();        
        }
    }
}
