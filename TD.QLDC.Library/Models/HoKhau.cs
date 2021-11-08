using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.Core.Api.Mvc;

namespace TD.QLDC.Library.Models
{
    [FullTextIndexedTable]
    [TextSearchColumns(nameof(SoHoKhau), nameof(SoNha))]
    public class HoKhau : ModelBaseExt
    {
        public HoKhau()
        {
            Created = DateTime.Now;          
        }

        private string soHoKhau;
        private string phuongxa;
        private string tinh;
        private string soNha;
        private string dmLoaiHo;
        private string quanhuyen;
        private bool sudung;        
        private string ghiChu;
        private string thon;
        private string xom;
        private string nguoiNhap;


        [FullTextIndex]
        public string SoHoKhau { get { return soHoKhau; } set { soHoKhau = value; NotifyPropertyChanged(); } }
        [FullTextIndex]
        public string SoNha { get { return soNha; } set { soNha = value; NotifyPropertyChanged(); } }
        public string PhuongXa { get { return phuongxa; } set { phuongxa = value; NotifyPropertyChanged(); } }
        public string Tinh { get { return tinh; } set { tinh = value; NotifyPropertyChanged(); } }
        public string DMLoaiHo { get { return dmLoaiHo; } set { dmLoaiHo = value; NotifyPropertyChanged(); } }
       // public Category DMLoaiHo { get; set; }
        public string QuanHuyen { get { return quanhuyen; } set { quanhuyen = value; NotifyPropertyChanged(); } } 
        [DefaultValue(true)]
        public bool SuDung { get { return sudung; } set { sudung = value; NotifyPropertyChanged(); } }
        public string GhiChu { get { return ghiChu; } set { ghiChu = value; NotifyPropertyChanged(); } }
        public string Thon { get { return thon; } set { thon = value; NotifyPropertyChanged(); } }
        public string Xom { get { return xom; } set { xom = value; NotifyPropertyChanged(); } }
        public string NguoiNhap { get { return nguoiNhap; } set { nguoiNhap = value; NotifyPropertyChanged(); } }

        //public List<NhanKhau> NhanKhau { get; set; }

    }
}