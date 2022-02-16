using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.Services.Interfaces
{
    public interface IUploadService
    {
        int UploadNhanKhau(
            byte[] buffer,
            int sheet,
            int rowStart,
            int rowEnd);
    }
}
