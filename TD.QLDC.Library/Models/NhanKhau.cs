using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Core.Api.Mvc;

namespace TD.QLDC.Library.Models
{
    [FullTextIndexedTable]
    [TextSearchColumns(nameof(SoHoKhau), nameof(HoTen), nameof(SoCMT), nameof(SoCCCD), nameof(SoDienThoai))]
    public class NhanKhau : ModelBaseExt
    {
        public NhanKhau()
        {
            Created = DateTime.Now;
        }

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
        #endregion

        #region Thông tin cơ bản
        private string hoTen;
        /// <summary>
        /// Họ và tên
        /// </summary>
        [FullTextIndex]
        public string HoTen { get { return hoTen; } set { hoTen = value; NotifyPropertyChanged(); } }


        private string tenGoiKhac;
        public string TenGoiKhac { get { return tenGoiKhac; } set { tenGoiKhac = value; NotifyPropertyChanged(); } }

        private string ngaySinh;
        /// <summary>
        /// Ngày sinh, năm sinh
        /// </summary>
        public string NgaySinh { get { return ngaySinh; } set { ngaySinh = value; NotifyPropertyChanged(); } }

        private string gioiTinh;
        public string GioiTinh { get { return gioiTinh; } set { gioiTinh = value; NotifyPropertyChanged(); } }

        private string noiSinh;
        public string NoiSinh { get { return noiSinh; } set { noiSinh = value; NotifyPropertyChanged(); } }

        private string soDienThoai;
        [FullTextIndex]
        public string SoDienThoai { get { return soDienThoai; } set { soDienThoai = value; NotifyPropertyChanged(); } }

        private string email;
        public string Email { get { return email; } set { email = value; NotifyPropertyChanged(); } }

        private string maXacThuc;
        public string MaXacThuc { get { return maXacThuc; } set { maXacThuc = value; NotifyPropertyChanged(); } }

        private DateTime? hanXacThuc;
        public DateTime? HanXacThuc { get { return hanXacThuc; } set { hanXacThuc = value; NotifyPropertyChanged(); } }

        private string anhDaiDien;
        public string AnhDaiDien { get { return anhDaiDien; } set { anhDaiDien = value; NotifyPropertyChanged(); } }

        private string ghiChu;
        public string GhiChu { get { return ghiChu; } set { ghiChu = value; NotifyPropertyChanged(); } }
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

        #region Giấy tờ
        private string soHoKhau;
        [FullTextIndex]
        public string SoHoKhau { get { return soHoKhau; } set { soHoKhau = value; NotifyPropertyChanged(); } }

        private string soCMT;
        public string SoCMT { get { return soCMT; } set { soCMT = value; NotifyPropertyChanged(); } }

        private DateTime? ngaycapCMT;
        public DateTime? NgayCapCMT { get { return ngaycapCMT; } set { ngaycapCMT = value; NotifyPropertyChanged(); } }

        private string noicapCMT;
        public string NoiCapCMT { get { return noicapCMT; } set { noicapCMT = value; NotifyPropertyChanged(); } }

        private string soCCCD;
        [FullTextIndex]
        public string SoCCCD { get { return soCCCD; } set { soCCCD = value; NotifyPropertyChanged(); } }

        private DateTime? ngaycapCCCD;
        public DateTime? NgayCapCCCD { get { return ngaycapCCCD; } set { ngaycapCCCD = value; NotifyPropertyChanged(); } }

        private string noicapCCCD;
        public string NoiCapCCCD { get { return noicapCCCD; } set { noicapCCCD = value; NotifyPropertyChanged(); } }

        private string soHC;
        public string SoHC { get { return soHC; } set { soHC = value; NotifyPropertyChanged(); } }

        private DateTime? ngaycapHC;
        public DateTime? NgayCapHC { get { return ngaycapHC; } set { ngaycapHC = value; NotifyPropertyChanged(); } }

        private string noicapHC;
        public string NoiCapHC { get { return noicapHC; } set { noicapHC = value; NotifyPropertyChanged(); } }

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
        #endregion

        #region Cha, mẹ, thân nhân
        private string tenCha;
        public string TenCha { get { return tenCha; } set { tenCha = value; NotifyPropertyChanged(); } }

        private string tenMe;
        public string TenMe { get { return tenMe; } set { tenMe = value; NotifyPropertyChanged(); } }

        private string thanNhan;
        public string ThanNhan { get { return thanNhan; } set { thanNhan = value; NotifyPropertyChanged(); } }
        #endregion

        #region Địa chỉ, nơi cư trú
        private string tinh;
        public string Tinh { get { return tinh; } set { tinh = value; NotifyPropertyChanged(); } }

        private string huyen;
        public string Huyen { get { return huyen; } set { huyen = value; NotifyPropertyChanged(); } }

        private string xa;
        public string Xa { get { return xa; } set { xa = value; NotifyPropertyChanged(); } }

        private string xom;
        /// <summary>
        /// Thôn, xóm
        /// </summary>
        public string Xom { get { return xom; } set { xom = value; NotifyPropertyChanged(); } }

        private string khu;
        public string Khu { get { return khu; } set { khu = value; NotifyPropertyChanged(); } }

        private string ngo;
        public string Ngo { get { return ngo; } set { ngo = value; NotifyPropertyChanged(); } }

        private string noiOHienTai;
        /// <summary>
        /// Nơi ở hiện tại, chỗ ở hiện nay
        /// </summary>
        public string NoiOHienTai { get { return noiOHienTai; } set { noiOHienTai = value; NotifyPropertyChanged(); } }

        private string loaiNhaO;
        public string LoaiNhaO { get { return loaiNhaO; } set { loaiNhaO = value; NotifyPropertyChanged(); } }

        private string queQuan;
        public string QueQuan { get { return queQuan; } set { queQuan = value; NotifyPropertyChanged(); } }

        private string noiThuongTru;
        public string NoiThuongTru { get { return noiThuongTru; } set { noiThuongTru = value; NotifyPropertyChanged(); } }

        private string noiTTTruoc;
        public string NoiTTTruoc { get { return noiTTTruoc; } set { noiTTTruoc = value; NotifyPropertyChanged(); } }

        private string lydoChuyen;
        public string LyDoChuyen { get { return lydoChuyen; } set { lydoChuyen = value; NotifyPropertyChanged(); } }

        private DateTime? chuyenDenNgay;
        public DateTime? ChuyenDenNgay { get { return chuyenDenNgay; } set { chuyenDenNgay = value; NotifyPropertyChanged(); } }
        #endregion
    }
}
