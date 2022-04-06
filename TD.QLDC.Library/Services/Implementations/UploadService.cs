using Syncfusion.XlsIO;
using System;
using System.IO;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories;
using TD.QLDC.Library.Common;
using TD.QLDC.Library.Repositories.Interfaces;
using TD.QLDC.Library.Services.Interfaces;

namespace TD.QLDC.Library.Services.Implementations
{
    public class UploadService : IUploadService
    {
        private readonly QLDCDbContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHoKhauRepository _hoKhauRepository;
        private readonly INhanKhauRepository _nhanKhauRepository;

        public UploadService(
            QLDCDbContext context,
            ICategoryRepository categoryRepository,
            IHoKhauRepository hoKhauRepository,
            INhanKhauRepository nhanKhauRepository
        )
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _hoKhauRepository = hoKhauRepository;
            _nhanKhauRepository = nhanKhauRepository;
        }

        public int UploadBieu4(
            byte[] buffer, int sheet, int rowStart, int rowEnd,
            string maTinh, string tenTinh,
            string maHuyen, string tenHuyen,
            string maXa, string tenXa,
            string maThon, string tenThon,
            string maXom, string tenXom)
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
            int hoKhauId = 0;

            for (int row = rowStart; row <= rowEnd; row++)
            {
                try
                {
                    // Chủ hộ
                    if (worksheet[row, 8].Value.Trim() == "CH")
                    {
                        HoKhau hoKhau = new()
                        {
                            SoHoKhau = Guid.NewGuid().ToString(),
                            MaTinhThanh = maTinh,
                            TenTinhThanh = tenTinh,
                            MaQuanHuyen = maHuyen,
                            TenQuanHuyen = tenHuyen,
                            MaXaPhuong = maXa,
                            TenXaPhuong = tenXa,
                            MaThon = maThon,
                            TenThon = tenThon,
                            MaXom = maXom,
                            TenXom = tenXom,
                            TenChuHo = worksheet[row, 2].Value,
                            CCCDCHuHo = worksheet[row, 4].Value
                        };

                        var hoKhauEntity = _hoKhauRepository.Add(hoKhau);
                        hoKhauId = hoKhauEntity.ID > 0
                            ? hoKhauEntity.ID
                            : throw new Exception("ID must greater than 0!");
                    }

                    var dmQuanHeID = CommonService.GhiChuBieu4ToDMQuanHeID(worksheet[row, 8].Value.Trim());
                    if (dmQuanHeID == 0) dmQuanHeID = 84; // Khác

                    NhanKhau nhanKhau = new()
                    {
                        HoKhauID = hoKhauId,
                        HoTen = worksheet[row, 2].Value,
                        //NgaySinh = worksheet[row, 3].Value,
                        SoCCCD = worksheet[row, 4].Value,
                        HoTenBo = worksheet[row, 5].Value,
                        HoTenMe = worksheet[row, 6].Value,
                        GhiChu = worksheet[row, 7].Value,
                        DMQuanHeID = dmQuanHeID,
                    };

                    _nhanKhauRepository.Add(nhanKhau);
                    count++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return count;
        }

        public int UploadBieuDemo(byte[] buffer, int sheet, int rowStart, int rowEnd,
            string maTinh, string tenTinh, string maHuyen, string tenHuyen, string maXa, string tenXa,
            string maThon, string tenThon, string maXom, string tenXom)
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
            int hoKhauId = 0;

            for (int row = rowStart; row <= rowEnd; row++)
            {
                // Chủ hộ
                if (worksheet[row, 4].Value.Trim() == "Chủ hộ")
                {
                    var isHoNgheo = !string.IsNullOrEmpty(worksheet[row, 18].Value);
                    var isHoCanNgheo = !string.IsNullOrEmpty(worksheet[row, 19].Value);
                    var isHoKha = !string.IsNullOrEmpty(worksheet[row, 20].Value);
                    var isHoGiau = !string.IsNullOrEmpty(worksheet[row, 21].Value);

                    // FIXME: hard code
                    var dmLoaiHoID = isHoNgheo ? 77
                        : isHoCanNgheo ? 79
                        : isHoKha ? 80
                        : isHoGiau ? 85
                        : 89;

                    HoKhau hoKhau = new()
                    {
                        DMLoaiHoID = dmLoaiHoID,
                        SoHoKhau = Guid.NewGuid().ToString(),
                        MaTinhThanh = maTinh,
                        TenTinhThanh = tenTinh,
                        MaQuanHuyen = maHuyen,
                        TenQuanHuyen = tenHuyen,
                        MaXaPhuong = maXa,
                        TenXaPhuong = tenXa,
                        MaThon = maThon,
                        TenThon = tenThon,
                        MaXom = maXom,
                        TenXom = tenXom,
                        TenChuHo = worksheet[row, 3].Value,
                        CCCDCHuHo = worksheet[row, 15].Value,
                        LoaiNhaO = worksheet[row, 27].Value,
                        DatO = worksheet[row, 28].Value,
                        DatSXNN = worksheet[row, 29].Value,
                        DatChuyenDoi = worksheet[row, 30].Value,
                        HoKinhDoanh = worksheet[row, 31].Value
                    };

                    var hoKhauEntity = _hoKhauRepository.Add(hoKhau);
                    hoKhauId = hoKhauEntity.ID > 0
                        ? hoKhauEntity.ID
                        : throw new Exception("ID must greater than 0!");
                }

                var dmQuanHeID = CommonService.ToDMQuanHeID(worksheet[row, 4].Value.Trim());
                // FIXME: hardcode
                if (dmQuanHeID == 0) dmQuanHeID = 84; // Khác

                var dmDanTocID = CommonService.ToDMDanTocID(worksheet[row, 7].Value.Trim());
                // FIXME: hardcode
                if (dmDanTocID == 0) dmDanTocID = 86; // Khác

                var dmVanHoaID = _categoryRepository.GetByNameAndCreateIfNotExist(NhomDanhMucId.TrinhDoVanHoa, worksheet[row, 8].Value).ID;

                var dmChuyenMonID = _categoryRepository.GetByTagsAndCreateIfNotExist(NhomDanhMucId.TrinhDoChuyenMon, worksheet[row, 9].Value).ID;

                var doiTuong = worksheet[row, 22].Value + worksheet[row, 23].Value + worksheet[row, 24].Value;
                var dmDoiTuongID = _categoryRepository.GetByNameAndCreateIfNotExist(NhomDanhMucId.DoiTuong, doiTuong).ID;

                NhanKhau nhanKhau = new()
                {
                    HoKhauID = hoKhauId,
                    DMQuocTichID = 4, // Việt Nam
                    HoTen = worksheet[row, 3].Value,
                    GioiTinh = worksheet[row, 5].Value,
                    DMQuanHeID = dmQuanHeID,
                    DMDanTocID = dmDanTocID,
                    DMVanHoaID = dmVanHoaID,
                    DMChuyenMonID = dmChuyenMonID,
                    DMDoiTuongID = dmDoiTuongID,
                    //NgaySinh = worksheet[row, 6].Value,
                    DiaChiTamTru = worksheet[row, 14].Value,
                    SoCCCD = worksheet[row, 15].Value,
                    SoDienThoai = worksheet[row, 16].Value,
                    NgheNghiep = worksheet[row, 17].Value,
                    SoBHYT = worksheet[row, 25].Value,
                    HanSuDungBHYT = DateTime.TryParse(worksheet[row, 26].Value, out DateTime hanSuDungBHYT)
                        ? hanSuDungBHYT : null,
                    GhiChu = worksheet[row, 32].Value,
                };

                _nhanKhauRepository.Add(nhanKhau);
                count++;
            }

            return count;
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
                        //NgaySinh = worksheet[row, 6].Value,
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
                        //LoaiNhaO = worksheet[row, 20].Value,
                        //DatO = worksheet[row, 21].Value,
                        //DatSXNN = worksheet[row, 22].Value,
                        //DatChuyenDoi = worksheet[row, 23].Value,
                        //HoKinhDoanh = worksheet[row, 24].Value,
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
