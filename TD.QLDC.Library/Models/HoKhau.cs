using System.ComponentModel;

namespace TD.QLDC.Library.Models
{
    public class HoKhau : ModelBaseExt
    {
        private int? dmLoaiHoID;
        public int? DMLoaiHoID { get { return dmLoaiHoID; } set { dmLoaiHoID = value; NotifyPropertyChanged(); } }
        public Category DMLoaiHo { get; set; }

        private string soHoKhau;
        public string SoHoKhau { get { return soHoKhau; } set { soHoKhau = value; NotifyPropertyChanged(); } }

        private bool sudung;
        [DefaultValue(true)]
        public bool SuDung { get { return sudung; } set { sudung = value; NotifyPropertyChanged(); } }

        private string ghiChu;
        public string GhiChu { get { return ghiChu; } set { ghiChu = value; NotifyPropertyChanged(); } }

        private string tenChuHo;
        public string TenChuHo { get { return tenChuHo; } set { tenChuHo = value; NotifyPropertyChanged(); } }

        private string cCCDChuHo;
        public string CCCDCHuHo { get { return cCCDChuHo; } set { cCCDChuHo = value; NotifyPropertyChanged(); } }

        #region Nơi ở, địa chỉ
        private string maTinhThanh;
        public string MaTinhThanh { get { return maTinhThanh; } set { maTinhThanh = value; NotifyPropertyChanged(); } }

        private string tenTinhThanh;
        public string TenTinhThanh { get { return tenTinhThanh; } set { tenTinhThanh = value; NotifyPropertyChanged(); } }

        private string maQuanHuyen;
        public string MaQuanHuyen { get { return maQuanHuyen; } set { maQuanHuyen = value; NotifyPropertyChanged(); } }

        private string tenQuanHuyen;
        public string TenQuanHuyen { get { return tenQuanHuyen; } set { tenQuanHuyen = value; NotifyPropertyChanged(); } }

        private string maXaPhuong;
        public string MaXaPhuong { get { return maXaPhuong; } set { maXaPhuong = value; NotifyPropertyChanged(); } }

        private string tenXaPhuong;
        public string TenXaPhuong { get { return tenXaPhuong; } set { tenXaPhuong = value; NotifyPropertyChanged(); } }

        private string maThon;
        public string MaThon { get { return maThon; } set { maThon = value; NotifyPropertyChanged(); } }

        private string tenThon;
        public string TenThon { get { return tenThon; } set { tenThon = value; NotifyPropertyChanged(); } }

        private string maXom;
        public string MaXom { get { return maXom; } set { maXom = value; NotifyPropertyChanged(); } }

        private string tenXom;
        public string TenXom { get { return tenXom; } set { tenXom = value; NotifyPropertyChanged(); } }

        private string soNha;
        public string SoNha { get { return soNha; } set { soNha = value; NotifyPropertyChanged(); } }
        #endregion
    }
}