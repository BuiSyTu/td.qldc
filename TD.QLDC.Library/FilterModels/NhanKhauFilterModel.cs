using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD.QLDC.Library.FilterModels
{
    public class NhanKhauFilterModel : BaseFilterModel
    {
        public string SoHoKhau { get; set; } = string.Empty;

        public int? DMHonNhanID { get; set; } = null;

        public int? DMQuanHeID { get; set; } = null;

        public int? DMDanTocID { get; set; } = null;

        public int? DMQuocTichID { get; set; } = null;

        public int? DMTonGiaoID { get; set; } = null;

        public int? DMTinhTrangCuTruID { get; set; } = null;

        public int? DMVanHoaID { get; set; } = null;

        public int? DMChuyenMonID { get; set; } = null;

        public int? DMDoiTuongID { get; set; } = null;

        public int? HoKhauID { get; set; } = null;

        public string GioiTinh { get; set; } = string.Empty;

        public bool? DongBHYT { get; set; } = null;

        public bool? TrongDoTuoiNhapNgu { get; set; } = null;

        // 1 - Sắp đến hạn
        // 2 - Quá hạn
        // 3 - Được miễn
        public int? BHYTStatus { get; set; } = null;

        public int? TuTuoi { get; set; } = null;

        public int? DenTuoi { get; set; } = null;

        public string AreaCode { get; set; } = null;

        public bool? LaDoiTuongChinhSach { get; set; } = null;
    }
}
