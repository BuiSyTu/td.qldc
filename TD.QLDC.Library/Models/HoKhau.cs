using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using TD.Core.Api.Mvc;

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

        #region Nơi ở, địa chỉ
        private string tinh;
        public string Tinh { get { return tinh; } set { tinh = value; NotifyPropertyChanged(); } }

        private string quanhuyen;
        public string QuanHuyen { get { return quanhuyen; } set { quanhuyen = value; NotifyPropertyChanged(); } }

        private string phuongxa;
        public string PhuongXa { get { return phuongxa; } set { phuongxa = value; NotifyPropertyChanged(); } }

        private string thon;
        public string Thon { get { return thon; } set { thon = value; NotifyPropertyChanged(); } }

        private string xom;
        public string Xom { get { return xom; } set { xom = value; NotifyPropertyChanged(); } }

        private string soNha;
        public string SoNha { get { return soNha; } set { soNha = value; NotifyPropertyChanged(); } }
        #endregion
    }
}