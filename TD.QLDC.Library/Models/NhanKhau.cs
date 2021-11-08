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
        private string soHoKhau;
        [FullTextIndex]
        public string SoHoKhau { get { return soHoKhau; } set { soHoKhau = value; NotifyPropertyChanged(); } }
        //public HoKhau HoKhau { get; set; }

        private string dmHonNhanText;
        private string dmQuanHeText;
        private string dmDanTocText;
        private string dmQuocTichText;
        private string dmTonGiaoText;      
        private string dmTinhTrangCuTruText;            
        private string dmVanHoaText;
        private string dmChuyenMonText;
        private string dmDoiTuongText;

        private int? dmHonNhanID;
        private int? dmQuanHeID;
        private int? dmDanTocID;
        private int? dmQuocTichID;
        private int? dmTonGiaoID;     
        private int? dmTinhTrangCuTruID;        
        private int? dmVanHoaID;
        private int? dmChuyenMonID;
        private int? dmDoiTuongID;

        private string hoTen;
        private string tenGoiKhac;
        private string ngaySinh;
        private string gioiTinh;
        private string noiSinh;
        private string queQuan;
        private string soCMT;
        private DateTime? ngaycapCMT;
        private string noicapCMT;
        private string soCCCD;
        private DateTime? ngaycapCCCD;
        private string noicapCCCD;
        private string trinhDoVanHoa;
        private string trinhDoChuyenMon;
        private string ngheNghiep;
        private string noiLamViec;
        private string noiThuongTru;
        private string noiOHienTai;
        private string soHC;
        private DateTime? ngaycapHC;
        private string noicapHC;
        private string soBHYT;
        private DateTime? ngaycapBHYT;
        private string noicapBHYT;
        private string maSoThue;
       
        private string tenCha;
        private string tenMe;
        private string thanNhan;
        private DateTime? chuyenDenNgay;
        private string noiTTTruoc;
        private string lydoChuyen;
        
        //Xac thuc
        private string soDienThoai;
        private string email;
        private string maXacThuc;
        private DateTime? hanXacThuc;
        private string anhDaiDien;
        private string ghiChu;

        private string tinh;
        private string huyen;
        private string xa;
        private string xom;

        public string Tinh { get { return tinh; } set { tinh = value; NotifyPropertyChanged(); } }
        public string Huyen { get { return huyen; } set { huyen = value; NotifyPropertyChanged(); } }
        public string Xa { get { return xa; } set { xa = value; NotifyPropertyChanged(); } }
        public string Xom { get { return xom; } set { xom = value; NotifyPropertyChanged(); } }

        public string DMDanTocText { get { return dmDanTocText; } set { dmDanTocText = value; NotifyPropertyChanged(); } }
        public int? DMDanTocID { get { return dmDanTocID; } set { dmDanTocID = value; NotifyPropertyChanged(); } }
        public Category DMDanToc { get; set; }
        public string DMQuocTichText { get { return dmQuocTichText; } set { dmQuocTichText = value; NotifyPropertyChanged(); } }
        public int? DMQuocTichID { get { return dmQuocTichID; } set { dmQuocTichID = value; NotifyPropertyChanged(); } }
        public Category DMQuocTich { get; set; }

        public string DMVanHoaText { get { return dmVanHoaText; } set { dmVanHoaText = value; NotifyPropertyChanged(); } }
        public int? DMVanHoaID { get { return dmVanHoaID; } set { dmVanHoaID = value; NotifyPropertyChanged(); } }
        public Category DMVanHoa { get; set; }
        public string DMChuyenMonText { get { return dmChuyenMonText; } set { dmChuyenMonText = value; NotifyPropertyChanged(); } }
        public int? DMChuyenMonID { get { return dmChuyenMonID; } set { dmChuyenMonID = value; NotifyPropertyChanged(); } }
        public Category DMChuyenMon { get; set; }
        public string DMTonGiaoText { get { return dmTonGiaoText; } set { dmTonGiaoText = value; NotifyPropertyChanged(); } }
        public int? DMTonGiaoID { get { return dmTonGiaoID; } set { dmTonGiaoID = value; NotifyPropertyChanged(); } }
        public Category DMTonGiao { get; set; }
        public string DMHonNhanText { get { return dmHonNhanText; } set { dmHonNhanText = value; NotifyPropertyChanged(); } }
        public int? DMHonNhanID { get { return dmHonNhanID; } set { dmHonNhanID = value; NotifyPropertyChanged(); } }
        public Category DMHonNhan { get; set; }
        public string DMQuanHeText { get { return dmQuanHeText; } set { dmQuanHeText = value; NotifyPropertyChanged(); } }
        public int? DMQuanHeID { get { return dmQuanHeID; } set { dmQuanHeID = value; NotifyPropertyChanged(); } }
        public Category DMQuanHe { get; set; }
        public string DMTinhTrangCuTruText { get { return dmTinhTrangCuTruText; } set { dmTinhTrangCuTruText = value; NotifyPropertyChanged(); } }
        public int? DMTinhTrangCuTruID { get { return dmTinhTrangCuTruID; } set { dmTinhTrangCuTruID = value; NotifyPropertyChanged(); } }
        public Category DMTinhTrangCuTru { get; set; }
        public string DMDoiTuongText { get { return dmDoiTuongText; } set { dmDoiTuongText = value; NotifyPropertyChanged(); } }
        public int? DMDoiTuongID { get { return dmDoiTuongID; } set { dmDoiTuongID = value; NotifyPropertyChanged(); } }
        public Category DMDoiTuong { get; set; }

        [FullTextIndex]
        public string HoTen { get { return hoTen; } set { hoTen = value; NotifyPropertyChanged(); } }
        public string TenGoiKhac { get { return tenGoiKhac; } set { tenGoiKhac = value; NotifyPropertyChanged(); } }
        public string NoiSinh { get { return noiSinh; } set { noiSinh = value; NotifyPropertyChanged(); } }
        public string QueQuan { get { return queQuan; } set { queQuan = value; NotifyPropertyChanged(); } }
        [FullTextIndex]
        public string SoCMT { get { return soCMT; } set { soCMT = value; NotifyPropertyChanged(); } }
        public string NoiCapCMT { get { return noicapCMT; } set { noicapCMT = value; NotifyPropertyChanged(); } }
        [FullTextIndex]
        public string SoCCCD { get { return soCCCD; } set { soCCCD = value; NotifyPropertyChanged(); } }
        public string NoiCapCCCD { get { return noicapCCCD; } set { noicapCCCD = value; NotifyPropertyChanged(); } }
        public string TrinhDoVanHoa { get { return trinhDoVanHoa; } set { trinhDoVanHoa = value; NotifyPropertyChanged(); } }
        public string TrinhDoChuyenMon { get { return trinhDoChuyenMon; } set { trinhDoChuyenMon = value; NotifyPropertyChanged(); } }
        public string NgheNghiep { get { return ngheNghiep; } set { ngheNghiep = value; NotifyPropertyChanged(); } }
        public string NoiLamViec { get { return noiLamViec; } set { noiLamViec = value; NotifyPropertyChanged(); } }
        public string NoiThuongTru { get { return noiThuongTru; } set { noiThuongTru = value; NotifyPropertyChanged(); } }
        public string NoiOHienTai { get { return noiOHienTai; } set { noiOHienTai = value; NotifyPropertyChanged(); } }
        public string SoHC { get { return soHC; } set { soHC = value; NotifyPropertyChanged(); } }
        public string NoiCapHC { get { return noicapHC; } set { noicapHC = value; NotifyPropertyChanged(); } }
        public string SoBHYT { get { return soBHYT; } set { soBHYT = value; NotifyPropertyChanged(); } }
        public string NoiCapBHYT { get { return noicapBHYT; } set { noicapBHYT = value; NotifyPropertyChanged(); } }
        public string MaSoThue { get { return maSoThue; } set { maSoThue = value; NotifyPropertyChanged(); } }
        public string TenCha { get { return tenCha; } set { tenCha = value; NotifyPropertyChanged(); } }
        public string TenMe { get { return tenMe; } set { tenMe = value; NotifyPropertyChanged(); } }
        public string ThanNhan { get { return thanNhan; } set { thanNhan = value; NotifyPropertyChanged(); } }
        public string NoiTTTruoc { get { return noiTTTruoc; } set { noiTTTruoc = value; NotifyPropertyChanged(); } }
        public string GhiChu { get { return ghiChu; } set { ghiChu = value; NotifyPropertyChanged(); } }
        public string LyDoChuyuen { get { return lydoChuyen; } set { lydoChuyen = value; NotifyPropertyChanged(); } }
        public string GioiTinh { get { return gioiTinh; } set { gioiTinh = value; NotifyPropertyChanged(); } }
        [FullTextIndex]
        public string SoDienThoai { get { return soDienThoai; } set { soDienThoai = value; NotifyPropertyChanged(); } }
        public string Email { get { return email; } set { email = value; NotifyPropertyChanged(); } }
        public string AnhDaiDien { get { return anhDaiDien; } set { anhDaiDien = value; NotifyPropertyChanged(); } }
        public string NgaySinh { get { return ngaySinh; } set { ngaySinh = value; NotifyPropertyChanged(); } }
        public DateTime? NgayCapCMT { get { return ngaycapCMT; } set { ngaycapCMT = value; NotifyPropertyChanged(); } }
        public DateTime? NgayCapCCCD { get { return ngaycapCCCD; } set { ngaycapCCCD = value; NotifyPropertyChanged(); } }
        public DateTime? NgayCapHC { get { return ngaycapHC; } set { ngaycapHC = value; NotifyPropertyChanged(); } }
        public DateTime? NgayCapBHYT { get { return ngaycapBHYT; } set { ngaycapBHYT = value; NotifyPropertyChanged(); } }
        public DateTime? ChuyenDenNgay { get { return chuyenDenNgay; } set { chuyenDenNgay = value; NotifyPropertyChanged(); } }
        public string MaXacThuc { get { return maXacThuc; } set { maXacThuc = value; NotifyPropertyChanged(); } }
        public DateTime? HanXacThuc { get { return hanXacThuc; } set { hanXacThuc = value; NotifyPropertyChanged(); } }
    }
}
