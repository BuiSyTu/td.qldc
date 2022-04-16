﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Services.Interfaces
{
    public interface INhanKhauService
    {
        NhanKhau GetByCccd(string cccd, string includes);

        Area GetCurrentTree(string areaCode = null);
    }
}
