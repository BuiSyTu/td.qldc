using Newtonsoft.Json;
using System;

namespace TD.QLDC.Library.Models
{
    public class NhanKhau : ModelBaseExt
    {
        #region Khóa ngoài
        private int? dmHonNhanID;
        public int? DMHonNhanID { get { return dmHonNhanID; } set { dmHonNhanID = value; NotifyPropertyChanged(); } }
        public Category DMHonNhan { get; set; }

        private int? dmQuanHeID;
        public int? DMQuanHeID { get { return dmQuanHeID; } set { dmQuanHeID = value; NotifyPropertyChanged(); } }
        public Category DMQuanHe { get; set; }

        private int? dmDanTocID;
        public int? DMDanTocID { get { return dmDanTocID; } set { dmDanTocID = value; NotifyPropertyChanged(); } }
        public Category DMDanToc { get; set; }

        private int? dmQuocTichID;
        public int? DMQuocTichID { get { return dmQuocTichID; } set { dmQuocTichID = value; NotifyPropertyChanged(); } }
        public Category DMQuocTich { get; set; }

        private int? dmTonGiaoID;
        public int? DMTonGiaoID { get { return dmTonGiaoID; } set { dmTonGiaoID = value; NotifyPropertyChanged(); } }
        public Category DMTonGiao { get; set; }

        private int? dmTinhTrangCuTruID;
        public int? DMTinhTrangCuTruID { get { return dmTinhTrangCuTruID; } set { dmTinhTrangCuTruID = value; NotifyPropertyChanged(); } }
        public Category DMTinhTrangCuTru { get; set; }

        private int? dmVanHoaID;
        public int? DMVanHoaID { get { return dmVanHoaID; } set { dmVanHoaID = value; NotifyPropertyChanged(); } }
        public Category DMVanHoa { get; set; }

        private int? dmChuyenMonID;
        public int? DMChuyenMonID { get { return dmChuyenMonID; } set { dmChuyenMonID = value; NotifyPropertyChanged(); } }
        public Category DMChuyenMon { get; set; }

        private int? dmDoiTuongID;
        public int? DMDoiTuongID { get { return dmDoiTuongID; } set { dmDoiTuongID = value; NotifyPropertyChanged(); } }
        public Category DMDoiTuong { get; set; }

        private int? hoKhauID;
        public int? HoKhauID { get { return hoKhauID; } set { hoKhauID = value; NotifyPropertyChanged(); } }
        public HoKhau HoKhau { get; set; }
        #endregion

        #region Thông tin cơ bản
        private string fullTextSearch;
        [JsonIgnore]
        public string FullTextSearch { get { return fullTextSearch; } set { fullTextSearch = value; NotifyPropertyChanged(); } }

        private string hoTen;
        public string HoTen { get { return hoTen; } set { hoTen = value; NotifyPropertyChanged(); } }

        private string tenGoiKhac;
        public string TenGoiKhac { get { return tenGoiKhac; } set { tenGoiKhac = value; NotifyPropertyChanged(); } }

        private DateTime? ngaySinh;
        public DateTime? NgaySinh { get { return ngaySinh; } set { ngaySinh = value; NotifyPropertyChanged(); } }

        private string gioiTinh;
        public string GioiTinh { get { return gioiTinh; } set { gioiTinh = value; NotifyPropertyChanged(); } }

        private string soDienThoai;
        public string SoDienThoai { get { return soDienThoai; } set { soDienThoai = value; NotifyPropertyChanged(); } }

        private string email;
        public string Email { get { return email; } set { email = value; NotifyPropertyChanged(); } }

        private string anhDaiDien;
        public string AnhDaiDien { get { return anhDaiDien; } set { anhDaiDien = value; NotifyPropertyChanged(); } }

        private string ghiChu;
        public string GhiChu { get { return ghiChu; } set { ghiChu = value; NotifyPropertyChanged(); } }

        private string loaiDoiTuongChinhSach;
        public string LoaiDoiTuongChinhSach { get { return loaiDoiTuongChinhSach; } set { loaiDoiTuongChinhSach = value; NotifyPropertyChanged(); } }

        private bool? daMat;
        public bool? DaMat { get { return daMat; } set { daMat = value; NotifyPropertyChanged(); } }
        #endregion

        #region Thông tin bố, mẹ
        private string hoTenBo;
        public string HoTenBo { get { return hoTenBo; } set { hoTenBo = value; NotifyPropertyChanged(); } }

        private string hoTenMe;
        public string HoTenMe { get { return hoTenMe; } set { hoTenMe = value; NotifyPropertyChanged(); } }
        #endregion

        #region Học vấn, nghề nghiệp
        private string trinhDoVanHoa;
        public string TrinhDoVanHoa { get { return trinhDoVanHoa; } set { trinhDoVanHoa = value; NotifyPropertyChanged(); } }

        private string trinhDoHocVan;
        public string TrinhDoHocVan { get { return trinhDoHocVan; } set { trinhDoHocVan = value; NotifyPropertyChanged(); } }

        private string trinhDoChuyenMon;
        public string TrinhDoChuyenMon { get { return trinhDoChuyenMon; } set { trinhDoChuyenMon = value; NotifyPropertyChanged(); } }

        private string ngheNghiep;
        public string NgheNghiep { get { return ngheNghiep; } set { ngheNghiep = value; NotifyPropertyChanged(); } }

        private string noiLamViec;
        public string NoiLamViec { get { return noiLamViec; } set { noiLamViec = value; NotifyPropertyChanged(); } }
        #endregion

        #region CCCD/ CMND
        private string soCCCD;
        public string SoCCCD { get { return soCCCD; } set { soCCCD = value; NotifyPropertyChanged(); } }

        private DateTime? ngaycapCCCD;
        public DateTime? NgayCapCCCD { get { return ngaycapCCCD; } set { ngaycapCCCD = value; NotifyPropertyChanged(); } }

        private string noicapCCCD;
        public string NoiCapCCCD { get { return noicapCCCD; } set { noicapCCCD = value; NotifyPropertyChanged(); } }

        private DateTime? hanSuDungCCCD;
        public DateTime? HanSuDungCCCD { get { return hanSuDungCCCD; } set { hanSuDungCCCD = value; NotifyPropertyChanged(); } }
        #endregion

        #region Hộ chiếu
        private string soHC;
        public string SoHC { get { return soHC; } set { soHC = value; NotifyPropertyChanged(); } }

        private DateTime? ngaycapHC;
        public DateTime? NgayCapHC { get { return ngaycapHC; } set { ngaycapHC = value; NotifyPropertyChanged(); } }

        private string noicapHC;
        public string NoiCapHC { get { return noicapHC; } set { noicapHC = value; NotifyPropertyChanged(); } }

        private DateTime? hanSuDungHC;
        public DateTime? HanSuDungHC { get { return hanSuDungHC; } set { hanSuDungHC = value; NotifyPropertyChanged(); } }
        #endregion

        #region BHYT
        private string soBHYT;
        public string SoBHYT { get { return soBHYT; } set { soBHYT = value; NotifyPropertyChanged(); } }

        private DateTime? ngaycapBHYT;
        public DateTime? NgayCapBHYT { get { return ngaycapBHYT; } set { ngaycapBHYT = value; NotifyPropertyChanged(); } }

        private string noicapBHYT;
        public string NoiCapBHYT { get { return noicapBHYT; } set { noicapBHYT = value; NotifyPropertyChanged(); } }

        private DateTime? hanSuDungBHYT;
        public DateTime? HanSuDungBHYT { get { return hanSuDungBHYT; } set { hanSuDungBHYT = value; NotifyPropertyChanged(); } }

        private string maSoThue;
        public string MaSoThue { get { return maSoThue; } set { maSoThue = value; NotifyPropertyChanged(); } }

        private bool? duocMienBHYT;
        public bool? DuocMienBHYT { get { return duocMienBHYT; } set { duocMienBHYT = value; NotifyPropertyChanged(); } }
        #endregion

        #region Địa chỉ, nơi cư trú
        private string maTinhThanhTamTru;
        public string MaTinhThanhTamTru { get { return maTinhThanhTamTru; } set { maTinhThanhTamTru = value; NotifyPropertyChanged(); } }

        private string tenTinhThanhTamTru;
        public string TenTinhThanhTamTru { get { return tenTinhThanhTamTru; } set { tenTinhThanhTamTru = value; NotifyPropertyChanged(); } }

        private string maQuanHuyenTamTru;
        public string MaQuanHuyenTamTru { get { return maQuanHuyenTamTru; } set { maQuanHuyenTamTru = value; NotifyPropertyChanged(); } }

        private string tenQuanHuyenTamTru;
        public string TenQuanHuyenTamTru { get { return tenQuanHuyenTamTru; } set { tenQuanHuyenTamTru = value; NotifyPropertyChanged(); } }

        private string maXaPhuongTamTru;
        public string MaXaPhuongTamTru { get { return maXaPhuongTamTru; } set { maXaPhuongTamTru = value; NotifyPropertyChanged(); } }

        private string tenXaPhuongTamTru;
        public string TenXaPhuongTamTru { get { return tenXaPhuongTamTru; } set { tenXaPhuongTamTru = value; NotifyPropertyChanged(); } }

        private string diaChiTamTru;
        public string DiaChiTamTru { get { return diaChiTamTru; } set { diaChiTamTru = value; NotifyPropertyChanged(); } }
        #endregion
    }
}
