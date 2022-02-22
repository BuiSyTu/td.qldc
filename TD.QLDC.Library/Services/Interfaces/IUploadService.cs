using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.Services.Interfaces
{
    public interface IUploadService
    {
        int UploadBieu4(
            byte[] buffer, int sheet, int rowStart, int rowEnd,
            string maTinh, string tenTinh,
            string maHuyen, string tenHuyen,
            string maXa, string tenXa,
            string maThon, string tenThon,
            string maXom, string tenXom);

        int UploadNhanKhau(byte[] buffer, int sheet, int rowStart, int rowEnd);
    }
}
