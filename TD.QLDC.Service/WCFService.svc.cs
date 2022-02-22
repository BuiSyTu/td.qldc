﻿using System.IO;
using System.ServiceModel.Activation;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Service.Common;
using TD.QLDC.Service.ViewModels;
using Unity;

namespace TD.QLDC.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class WCFService : WCFController, IWCFService
    {
        private readonly IUnityContainer _unityContainer;
        private readonly INhanKhauRepository _nhanKhauRepository;

        public WCFService()
        {
            _unityContainer = new UnityContainer().EnableDiagnostic();
            var integration = new Integration();
            integration.ConfigureContainer(_unityContainer);

            _nhanKhauRepository = _unityContainer.Resolve<INhanKhauRepository>();
        }

        public Stream CheckValidNhanKhau(CheckValidNhanKhauInput input)
        {
            var isValid = _nhanKhauRepository.CheckExist(
                hoTen: input.HoTen,
                cCCD: input.CCCD,
                ngaySinh: input.NgaySinh
            );
            return ApiOk(isValid);
        }

        public Stream HelloWorld()
        {
            return ApiOk("Hello world");
        }
    }
}
