using TD.Core.Api.Mvc;
using TD.Core.Api.Mvc.Integration;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Implementations;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.Services.Implementations;
using TD.QLDC.Library.Services.Interfaces;
using Unity;

namespace TD.QLDC.Service.Common
{
    public class Integration
    {
        public void ConfigureContainer(IUnityContainer container)
        {
            // Data
            container.RegisterFactory<QLDCDbContext>(c => new QLDCDbContext());

            // Repositories
            container.RegisterType<IAreaRepository, AreaRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IHoKhauRepository, HoKhauRepository>();
            container.RegisterType<INhanKhauRepository, NhanKhauRepository>();
            container.RegisterType<INhomDanhMucRepository, NhomDanhMucRepository>();

            // Services
            container.RegisterType<IDashboardService, DashboardService>();
            container.RegisterType<IUploadService, UploadService>();
            container.RegisterType<IUserService, UserService>();

            // Others
            container.RegisterFactory<ICoreServicesProvider>(c => new DefaultContextCoreServicesProvider());
            container.RegisterType<ICoreContextAccessor, AspNetCoreContextAccessor>();
        }

    }
}
