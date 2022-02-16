using Syncfusion.XlsIO;
using System;
using System.IO;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.Services.Interfaces;

namespace TD.QLDC.Library.Services.Implementations
{
    public class UploadService : IUploadService
    {
        private readonly QLDCDbContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHoKhauRepository _hoKhauRepository;

        public UploadService(
            QLDCDbContext context,
            ICategoryRepository categoryRepository,
            IHoKhauRepository hoKhauRepository
        )
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _hoKhauRepository = hoKhauRepository;
        }

        public int UploadNhanKhau(
            byte[] buffer,
            int sheet,
            int rowStart,
            int rowEnd)
        {
            // Instantiate the spreadsheet creation engine.
            ExcelEngine excelEngine = new();

            // Instantiate the Excel application object.
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;


            Stream stream = new MemoryStream(buffer);
            IWorkbook book = application.Workbooks.Open(stream);
            stream.Close();

            // Access first worksheet.
            IWorksheet worksheet = book.Worksheets[sheet];

            // Access a range.
            IRange usedRange = worksheet.UsedRange;

            int lastRow = usedRange.LastRow;

            if (rowEnd == 0) rowEnd = lastRow;

            int count = 0;
            for (int row = rowStart; row <= rowEnd; row++)
            {
                try
                {
                    var loaiHoGiaDinhId = _categoryRepository.GetByNameAndCreateIfNotExist(NhomDanhMucId.LoaiHoGiaDinh, worksheet[row, 16].Value).ID;

                    var nhanKhau = new NhanKhau
                    {
                        HoKhauID = _hoKhauRepository.GetBySoHoKhauAndCreateIfNotExist(worksheet[row, 1].Value, loaiHoGiaDinhId).ID,
                        // STT
                        HoTen = worksheet[row, 3].Value,
                        DMQuanHeID = _categoryRepository.GetByNameAndCreateIfNotExist(NhomDanhMucId.QuanHeVoiChuHo, worksheet[row, 4].Value).ID,
                        GioiTinh = worksheet[row, 5].Value,
                        NgaySinh = worksheet[row, 6].Value,
                        DMDanTocID = _categoryRepository.GetByNameAndCreateIfNotExist(NhomDanhMucId.DanToc, worksheet[row, 7].Value).ID,
                        DMVanHoaID = _categoryRepository.GetByNameAndCreateIfNotExist(NhomDanhMucId.TrinhDoVanHoa, worksheet[row, 8].Value).ID,
                        DMChuyenMonID = _categoryRepository.GetByNameAndCreateIfNotExist(NhomDanhMucId.TrinhDoChuyenMon, worksheet[row, 9].Value).ID,
                        //NoiSinh = worksheet[row, 10].Value,
                        //NoiThuongTru = worksheet[row, 11].Value,
                        //NoiOHienTai = worksheet[row, 12].Value,
                        SoCCCD = worksheet[row, 13].Value,
                        SoDienThoai = worksheet[row, 14].Value,
                        NgheNghiep = worksheet[row, 15].Value,
                        // Loại hộ gia đình
                        DMDoiTuongID = _categoryRepository.GetByNameAndCreateIfNotExist(NhomDanhMucId.DoiTuong, worksheet[row, 17].Value).ID,
                        SoBHYT = worksheet[row, 18].Value,
                        HanSuDungBHYT = DateTime.TryParse(worksheet[row, 19].Value, out DateTime hanSuDungBHYT) ? hanSuDungBHYT : null,
                        LoaiNhaO = worksheet[row, 20].Value,
                        DatO = worksheet[row, 21].Value,
                        DatSXNN = worksheet[row, 22].Value,
                        DatChuyenDoi = worksheet[row, 23].Value,
                        HoKinhDoanh = worksheet[row, 24].Value,
                        GhiChu = worksheet[row, 25].Value
                    };

                    _context.NhanKhaus.Add(nhanKhau);
                    _context.SaveChanges();
                    count++;
                }
                catch { }
            }

            return count;
        }
    }
}
