using Microsoft.SharePoint;
using Microsoft.SharePoint.IdentityModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using TD.Core.UserProfiles.Controllers;
using TD.Core.UserProfiles.Models;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WCFService : IWCFService
    {
        public QLDCDbContext _dbContext;

        /// <summary>
        /// Lay token dang nhap của công dân
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public APIResult GetTokenKey(string user, string pass, string tokenDevice)
        {
            APIResult result = new APIResult();
            API_DataLogin _user = new API_DataLogin();
            try
            {
                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass))
                {
                    string urlRoot = SPContext.Current.Site.Url;
                    bool login = SPClaimsUtility.AuthenticateFormsUser(new Uri(urlRoot), user, pass);
                    if (login)
                    {
                        _dbContext = new QLDCDbContext();
                        var query = from hs in _dbContext.NhanKhaus.AsQueryable()
                                    where hs.SoCMT.Equals(user) || hs.SoCCCD.Equals(user)
                                    select hs;
                        if (query != null && query.Count() > 0)
                        {
                            NhanKhau obj = query.First();
                            _user.fullName = obj.HoTen;
                            _user.identifier = user;
                            _user.birthday = obj.NgaySinh;
                            _user.sex = obj.GioiTinh;
                            _user.phoneNumber = obj.SoDienThoai;
                            _user.email = obj.Email;
                            _user.avartar = obj.AnhDaiDien;
                            _user.address = obj.NoiOHienTai;
                            _user.soHoKhau = obj.SoHoKhau;
                        }
                        else
                        {
                            SPSecurity.RunWithElevatedPrivileges(delegate ()
                            {
                                using (SPSite oSite = new SPSite(urlRoot))
                                {
                                    using (SPWeb oWeb = oSite.RootWeb)
                                    {
                                        SPList lstUserProfile = oWeb.Lists["UserProfiles"];
                                        SPListItem itemUser = GetByUser(lstUserProfile, user);
                                        if (itemUser != null)
                                        {
                                            _user.fullName = itemUser["FullName"] + "";
                                            _user.identifier = user;
                                            _user.birthday = itemUser["Birthday"] != null ? Convert.ToDateTime(itemUser["Birthday"] + "").ToString("dd/MM/yyyy") : null;
                                            _user.sex = itemUser["Sex"] + "";
                                            _user.phoneNumber = itemUser["Phone"] + "";
                                            _user.email = itemUser["Email"] + "";
                                            _user.avartar = itemUser["Account"] + "";
                                            _user.address = itemUser["Address"] + "";
                                        }
                                    }
                                }
                            });
                        }
                        PayloadJWT token = new PayloadJWT()
                        {
                            iat = (int)DateTimeOffset.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                            exp = (int)DateTimeOffset.UtcNow.AddYears(3).Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                            sub = user,
                            hashpwd = APICommon.doEncryptAES(pass),
                            context = new UserContext()
                            {
                                user = new UserAPI()
                                {
                                    displayName = _user.fullName,
                                    userName = user
                                }
                            }
                        };
                        _user.token = APICommon.CreateJWT(token);
                        result.data = _user;

                        //Add user token
                        AddUserToken(user, tokenDevice);
                    }
                    else
                    {
                        result.error = new ErrorResult()
                        {
                            code = 401,
                            userMessage = "Không xác thực thành công!"
                        };
                    }
                }
                else
                {
                    result.error = new ErrorResult()
                    {
                        code = 405,
                        userMessage = "Tài khoản hoặc mật khẩu không được để trống!"
                    };
                }
            }
            catch (Exception ex)
            {
                result.error = new ErrorResult()
                {
                    code = 500,
                    userMessage = "Có lỗi xảy ra!",
                    internalMessage = ex.ToString()
                };
            }

            return result;
        }

        /// <summary>
        /// Lay token dang nhap của cán bộ
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public APIResult GetUserTokenKey(string user, string pass, string tokenDevice)
        {
            APIResult result = new APIResult();
            API_DataLogin _user = new API_DataLogin();
            try
            {
                if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass))
                {
                    string urlRoot = SPContext.Current.Site.Url;
                    bool login = SPClaimsUtility.AuthenticateFormsUser(new Uri(urlRoot), user, pass);
                    if (login)
                    {
                        SPSecurity.RunWithElevatedPrivileges(delegate ()
                        {
                            using (SPSite oSite = new SPSite(urlRoot))
                            {
                                var webApp = oSite.WebApplication;
                                //var zone = oSite.Zone;

                                SPWeb rootWeb = oSite.RootWeb;
                                SPList lstUser = rootWeb.Lists["UserProfiles"];
                                SPListItem obj = GetByUser(lstUser, user);
                                if (obj != null)
                                {
                                    _user.fullName = obj["FullName"] + "";
                                    _user.birthday = obj["Birthday"] != null ? Convert.ToDateTime(obj["Birthday"]).ToString("dd /MM/yyyy") : "";
                                    _user.sex = obj["Sex"] + "";
                                    _user.phoneNumber = obj["Phone"] + "";
                                    _user.email = obj["Email"] + "";
                                    _user.avartar = obj["Avatar"] + "";
                                    _user.address = obj["Address"] + "";
                                }
                                else
                                {
                                    _user.fullName = user;
                                }
                            }
                        });

                        PayloadJWT token = new PayloadJWT()
                        {
                            iat = (int)DateTimeOffset.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                            exp = (int)DateTimeOffset.UtcNow.AddYears(3).Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                            sub = user,
                            hashpwd = APICommon.doEncryptAES(pass),
                            context = new UserContext()
                            {
                                user = new UserAPI()
                                {
                                    displayName = _user.fullName,
                                    userName = user
                                }
                            }
                        };
                        _user.token = APICommon.CreateJWT(token);
                        result.data = _user;

                        //Add user token
                        AddUserToken(user, tokenDevice);
                    }
                    else
                    {
                        result.error = new ErrorResult()
                        {
                            code = 401,
                            userMessage = "Không xác thực thành công!"
                        };
                    }
                }
                else
                {
                    result.error = new ErrorResult()
                    {
                        code = 405,
                        userMessage = "Tài khoản hoặc mật khẩu không được để trống!"
                    };
                }
            }
            catch (Exception ex)
            {
                result.error = new ErrorResult()
                {
                    code = 500,
                    userMessage = "Có lỗi xảy ra!",
                    internalMessage = ex.ToString()
                };
            }
            return result;
        }

        /// <summary>
        /// Xác thực user trước khi đăng ký
        /// </summary>
        /// <param name="user">Mã định danh (Số CMT | Số CCCD)</param>
        /// <returns></returns>
        public APIResult CheckUserRegister(string user)
        {
            APIResult result = new APIResult();
            if (string.IsNullOrEmpty(user))
            {
                result.error = new ErrorResult()
                {
                    code = 405,
                    internalMessage = "Tài khoản không được bỏ trống!"
                };
                return result;
            }

            //string user = acc.user;
            _dbContext = new QLDCDbContext();
            if (!string.IsNullOrEmpty(user))
            {
                var query = from hs in _dbContext.NhanKhaus.AsQueryable()
                            where hs.SoCMT.Equals(user) || hs.SoCCCD.Equals(user)
                            select hs;
                if (query.Any())
                {
                    //Check tai khoan da duoc tao hay chua
                    string urlRoot = SPContext.Current.Site.Url;
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        using (SPSite oSite = new SPSite(urlRoot))
                        {
                            using (SPWeb oWeb = oSite.RootWeb)
                            {
                                SPList lstUserProfile = oWeb.Lists["UserProfiles"];
                                SPListItem itemUser = GetByUser(lstUserProfile, user);
                                if (itemUser != null)
                                {
                                    result.data = -2;
                                    result.error = new ErrorResult()
                                    {
                                        code = 404,
                                        userMessage = "Đã tồn tài tài khoản trong hệ thống!"
                                    };
                                }
                                else
                                {
                                    NhanKhau obj = query.First();
                                    DateTime now = DateTime.Now;
                                    obj.HanXacThuc = DateTime.Now.AddMinutes(2);
                                    obj.MaXacThuc = APICommon.GenerateRandomNo().ToString();
                                    _dbContext.SaveChanges();

                                    //Thực hiện gửi mã qua SMS
                                    TimeSpan time = (obj.HanXacThuc.Value - now);
                                    result.data = int.Parse(time.TotalSeconds.ToString());
                                }
                            }
                        }
                    });
                }
                else
                {
                    result.data = -1;
                    result.error = new ErrorResult()
                    {
                        code = 404,
                        userMessage = "Không tìm thấy tài khoản hoặc do tài khoản chưa được cập nhật thông tin định danh!"
                    };
                }
            }
            else
            {
                result.error = new ErrorResult()
                {
                    code = 404,
                    userMessage = "Tài khoản không được bỏ trống!"
                };
            }
            //return APICommon.ObjectToJson(result);
            return result;
        }

        public APIResult CreateNewUser(string account, string passWord, string address, string avatar, string birthday, string email, string fullName, string phone, string sex, string areaCode)
        {
            APIResult result = new APIResult();
            if (account == null || passWord == null)
            {
                result.error = new ErrorResult()
                {
                    code = 405,
                    internalMessage = "Tài khoản, mật khẩu không được bỏ trống!"
                };
                return result;
            }

            _dbContext = new QLDCDbContext();

            API_DataLogin _user = new API_DataLogin();
            string urlRoot = SPContext.Current.Site.Url;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(urlRoot))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        var webApp = oSite.WebApplication;
                        var zone = oSite.Zone;
                        UserProfile userProfile = new UserProfile();
                        UserProfileController userProfileCtrlr = new UserProfileController(webApp, zone);
                        userProfile.Account = account;
                        userProfile.Address = address;
                        userProfile.FullName = fullName;
                        if (string.IsNullOrEmpty(birthday))
                        {
                            userProfile.Birthday = DateTime.ParseExact(birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        }

                        userProfile.Sex = sex;
                        userProfile.Phone = phone;
                        userProfile.Email = email;
                        userProfileCtrlr.Add(userProfile);//Create user
                        userProfileCtrlr.ResetPassword(userProfile.Account, passWord, false);

                        //Cap nhat cho cac phan mem khac
                        UpdateUserProfile(oWeb, account, address, fullName, birthday, sex, phone, email);
                    }
                }
            });

            _user.fullName = fullName;
            _user.identifier = account;
            _user.birthday = birthday;
            _user.sex = sex;
            _user.phoneNumber = phone;
            _user.email = email;
            _user.avartar = avatar;
            _user.address = address;
            _user.soHoKhau = null;//Chưa có sổ hộ khẩu

            PayloadJWT token = new PayloadJWT()
            {
                iat = (int)DateTimeOffset.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                exp = (int)DateTimeOffset.UtcNow.AddYears(3).Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                sub = account,
                hashpwd = APICommon.doEncryptAES(passWord),
                context = new UserContext()
                {
                    user = new UserAPI()
                    {
                        displayName = _user.fullName,
                        userName = account
                    }
                }
            };
            _user.token = APICommon.CreateJWT(token);

            result.data = _user;

            return result;
        }
        public APIResult CreateNhanKhau(string hoten, string hktt, string birthday, string phone, string sex, string mqh, string nghenghiep, string dantoc)
        {
            APIResult result = new APIResult();
            if (hoten == null || hktt == null)
            {
                result.error = new ErrorResult()
                {
                    code = 405,
                    internalMessage = "Họ tên là bắt buộc!"
                };
                return result;
            }

            _dbContext = new QLDCDbContext();
            API_DataLogin _user = new API_DataLogin();
            string urlRoot = SPContext.Current.Site.Url;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(urlRoot))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        NhanKhau NhanKhau = new NhanKhau();

                        NhanKhau.HoTen = hoten;

                        if (string.IsNullOrEmpty(birthday))
                        {
                            NhanKhau.NgaySinh = birthday;
                        }

                        NhanKhau.GioiTinh = sex;
                        NhanKhau.SoDienThoai = phone;
                        NhanKhau.NgheNghiep = nghenghiep;

                        _dbContext.NhanKhaus.Add(NhanKhau);
                        _dbContext.SaveChanges();
                    }
                }
            });
            result.data = _user;

            return result;
        }

        /// <summary>
        /// Kiểm tra mã xác thực
        /// </summary>
        /// <param name="user"></param>
        /// <param name="code"></param>
        /// <returns>1: Thành công, 2: Không thành công</returns>
        public APIResult CheckVerificationCode(string user, string code)
        {
            _dbContext = new QLDCDbContext();
            APIResult result = new APIResult();

            //Không check code
            result.data = 1;
            return result;

            var query = from hs in _dbContext.NhanKhaus.AsQueryable()
                        where hs.MaXacThuc.Equals(code) && (hs.SoCMT.Equals(user) || hs.SoCCCD.Equals(user))
                        select hs;
            if (query != null && query.Count() > 0)
            {
                NhanKhau obj = query.First();
                if (obj.HanXacThuc.Value >= DateTime.Now)
                {
                    result.data = 1;
                }
                else
                {
                    result.data = 0;
                    result.error = new ErrorResult()
                    {
                        code = 408,
                        userMessage = "Hết thời gian thực hiện!"
                    };
                }
            }
            else
            {
                result.data = 0;
                result.error = new ErrorResult()
                {
                    code = 404,
                    userMessage = "Không tồn tại tài khoản này trong hệ thống!"
                };
            }

            //return APICommon.ObjectToJson(result);
            return result;
        }

        public APIResult CreateUserRegister(string user, string pass)
        {
            APIResult result = new APIResult();

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                result.error = new ErrorResult()
                {
                    code = 405,
                    internalMessage = "Tài khoản, mật khẩu không được bỏ trống!"
                };
                return result;
            }

            _dbContext = new QLDCDbContext();

            API_DataLogin _user = new API_DataLogin();
            UserProfile userProfile = new UserProfile();
            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pass))
            {
                var query = from hs in _dbContext.NhanKhaus.AsQueryable()
                            where hs.SoCMT.Equals(user) || hs.SoCCCD.Equals(user)
                            select hs;
                if (query != null && query.Count() > 0)
                {
                    NhanKhau obj = query.First();
                    string urlRoot = SPContext.Current.Site.Url;
                    SPSecurity.RunWithElevatedPrivileges(delegate ()
                    {
                        using (SPSite oSite = new SPSite(urlRoot))
                        {
                            using (SPWeb oWeb = oSite.RootWeb)
                            {
                                var webApp = oSite.WebApplication;
                                var zone = oSite.Zone;
                                UserProfileController userProfileCtrlr = new UserProfileController(webApp, zone);
                                userProfile.Account = user;
                                userProfile.Address = obj.NoiOHienTai;
                                userProfile.FullName = obj.HoTen;
                                //userProfile.Birthday = obj.NgaySinh;
                                if (!string.IsNullOrEmpty(obj.NgaySinh))
                                {
                                    try
                                    {
                                        userProfile.Birthday = DateTime.ParseExact(obj.NgaySinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    }
                                    catch (Exception)
                                    {
                                        try
                                        {
                                            userProfile.Birthday = Convert.ToDateTime(obj.NgaySinh);
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                    
                                }
                                userProfile.Sex = obj.GioiTinh;
                                userProfile.Phone = obj.SoDienThoai;
                                userProfile.Email = obj.Email;
                                userProfile = userProfileCtrlr.Add(userProfile);//Create user
                                userProfileCtrlr.ResetPassword(user, pass, false);
                                //Cap nhat cho cac phan mem khac
                                UpdateUserProfile(oWeb, userProfile.Account, userProfile.Address, userProfile.FullName, userProfile.Email, userProfile.Sex, userProfile.Phone, userProfile.Email);
                            }
                        }
                    });

                    _user.fullName = obj.HoTen;
                    _user.identifier = user;
                    _user.birthday = obj.NgaySinh;
                    //.HasValue ? obj.NgaySinh.Value.ToString("dd/MM/yyyy") : "";
                    _user.sex = obj.GioiTinh;
                    _user.phoneNumber = obj.SoDienThoai;
                    _user.email = obj.Email;
                    _user.avartar = obj.AnhDaiDien;
                    _user.address = obj.NoiOHienTai;
                    _user.soHoKhau = obj.SoHoKhau;

                    PayloadJWT token = new PayloadJWT()
                    {
                        iat = (int)DateTimeOffset.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                        exp = (int)DateTimeOffset.UtcNow.AddYears(3).Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
                        sub = user,
                        hashpwd = APICommon.doEncryptAES(pass),
                        context = new UserContext()
                        {
                            user = new UserAPI()
                            {
                                displayName = _user.fullName,
                                userName = user
                            }
                        }
                    };
                    _user.token = APICommon.CreateJWT(token);

                    result.data = _user;
                }
                else
                {
                    result.error = new ErrorResult()
                    {
                        code = 404,
                        userMessage = "Không tìm thấy thông tin tài khoản!"
                    };
                }
            }
            else
            {
                result.error = new ErrorResult()
                {
                    code = 500,
                    userMessage = "Có lỗi trong quá trình tạo tài khoản!"
                };
            }
            //return APICommon.ObjectToJson(result);
            return result;
        }

        public APIResult LayNhanKhauTheoMaDinhDanh(string code)
        {
            _dbContext = new QLDCDbContext();
            APIResult result = new APIResult();
            var query = from nk in _dbContext.NhanKhaus.AsQueryable()
                        where nk.SoCMT.Equals(code) || nk.SoCCCD.Equals(code)
                        select new
                        {
                            identifier = code,
                            fullName = nk.HoTen,
                            birthday = nk.NgaySinh,
                            sex = nk.GioiTinh,
                            phoneNumber = nk.SoDienThoai,
                            email = nk.Email,
                            avartar = nk.AnhDaiDien,
                            address = nk.NoiOHienTai,
                            soHoKhau = nk.SoHoKhau,
                        };
            if (query != null && query.Count() > 0)
            {
                result.data = (from qr in query.ToList()
                               select new API_DataLogin
                               {
                                   identifier = qr.identifier,
                                   fullName = qr.fullName,
                                   birthday = qr.birthday,
                                   sex = qr.sex,
                                   phoneNumber = qr.phoneNumber,
                                   email = qr.email,
                                   avartar = qr.avartar,
                                   address = qr.address,
                                   soHoKhau = qr.soHoKhau,
                               }
                               ).First();
            }
            else
            {
                result.data = null;
                result.error = new ErrorResult()
                {
                    code = 404,
                    userMessage = "Không tồn tại nhân khẩu này trong hệ thống!"
                };
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public APIResult GetTokenDevices(string token)
        {
            string tokenDecryp = APICommon.DecryptString(token);
            string user = tokenDecryp.Split(':')[0];
            APIResult result = new APIResult();
            result.data = GetAllUserToken(user);
            return result;
        }

        /// <summary>
        /// Đăng xuất tài khoản, xóa tokenDevice của user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="tokenDevice"></param>
        /// <returns></returns>
        public APIResult LogoutUser(string token, string tokenDevice)
        {
            APIResult result = new APIResult();
            try
            {
                string validate = APICommon.ValidateJWT(token);
                try
                {
                    PayloadJWT payloadJWT = JsonConvert.DeserializeObject<PayloadJWT>(validate);
                    string pass = APICommon.doDecryptAES(payloadJWT.hashpwd);
                    string user = payloadJWT.context.user.userName;
                    result.data = RemoveUserToken(user, tokenDevice);
                }
                catch (Exception)
                {
                    result.error = new ErrorResult()
                    {
                        code = 500,
                        internalMessage = validate,
                        userMessage = validate
                    };
                }

            }
            catch (Exception ex)
            {
            }

            return result;
        }

        #region Private function
        private void UpdateUserProfile(SPWeb oWeb, string account, string address, string fullName, string birthday, string sex, string phone, string email)
        {
            try
            {
                SPList lstCauHinh = oWeb.Lists["CauHinhLienThong"];
                foreach (SPListItem item in lstCauHinh.Items)
                {
                    try
                    {
                        string serviceUrl = item["DuongDanDichVu"] + "";
                        string serviceName = item["TenDichVu"] + "";
                        Uri postUrl = new Uri(serviceUrl + "/" + serviceName);
                        var userJson = "{\"Account\": \"" + account + "\",\"Address\": \"" + address + "\",\"FullName\": \"" + fullName + "\",\"Birthday\": \"" + birthday + "\",\"Sex\": \"" + sex + "\",\"Phone\": \"" + phone + "\",\"Email\": \"" + email + "\"}";
                        HttpContent c = new StringContent(userJson, Encoding.UTF8, "application/json");
                        var t = Task.Run(() => PostURI(postUrl, c));
                        t.Wait();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private async Task<string> PostURI(Uri urlAPI, HttpContent inputAPI)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.PostAsync(urlAPI, inputAPI);
                if (result.IsSuccessStatusCode)
                {
                    response = result.StatusCode.ToString();
                }
            }
            return response;
        }

        public SPListItem GetByUser(SPList lstUserProfile, string account)
        {
            try
            {
                var query = new SPQuery()
                {
                    Query = "<Where><Eq><FieldRef Name='Account'/><Value Type='Text'>" + account + "</Value></Eq></Where>",
                    RowLimit = 1
                };
                var spItems = lstUserProfile.GetItems(query);
                if (spItems != null && spItems.Count > 0)
                {
                    return spItems[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void AddUserToken(string user, string tokenDevice)
        {
            if (string.IsNullOrEmpty(user))
                return;
            string urlRoot = SPContext.Current.Site.Url;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(urlRoot))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        oWeb.AllowUnsafeUpdates = true;
                        SPList lstUserToken = oWeb.Lists["UserToken"];
                        SPQuery query = new SPQuery();
                        query.Query = "<Where><Eq><FieldRef Name='UserLogin'/><Value Type='Text'>" + user + "</Value></Eq></Where>";
                        query.RowLimit = 1;
                        SPListItemCollection items = lstUserToken.GetItems(query);
                        SPListItem item;
                        if (items.Count > 0)
                        {
                            item = items[0];
                            item["UserLogin"] = user;
                            if (item["TokenDevice"] == null)
                            {
                                item["TokenDevice"] = ";" + tokenDevice + ";";
                            }
                            else if (!item["TokenDevice"].ToString().Contains(tokenDevice))
                            {
                                item["TokenDevice"] = item["TokenDevice"].ToString() + tokenDevice + ";";
                            }
                        }
                        else
                        {
                            item = lstUserToken.AddItem();
                            item["UserLogin"] = user;
                            item["TokenDevice"] = ";" + tokenDevice + ";";
                        }
                        item.Update();
                    }
                }
            });
        }
        private string RemoveUserToken(string user, string tokenDevice)
        {
            string result = "0";
            if (string.IsNullOrEmpty(user))
                return result;
            string urlRoot = SPContext.Current.Site.Url;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(urlRoot))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        oWeb.AllowUnsafeUpdates = true;
                        SPList lstUserToken = oWeb.Lists["UserToken"];
                        SPQuery query = new SPQuery();
                        query.Query = "<Where><Eq><FieldRef Name='UserLogin'/><Value Type='Text'>" + user + "</Value></Eq></Where>";
                        query.RowLimit = 1;
                        SPListItemCollection items = lstUserToken.GetItems(query);
                        if (items.Count > 0)
                        {
                            SPListItem item = items[0];
                            if (item["TokenDevice"].ToString().Contains(tokenDevice))
                            {
                                item["TokenDevice"] = item["TokenDevice"].ToString().Replace(";" + tokenDevice + ";", ";");
                            }
                            item.Update();
                            result = "1";
                        }
                    }
                }
            });
            return result;
        }
        private List<string> GetAllUserToken(string user)
        {
            List<string> result = new List<string>();
            if (string.IsNullOrEmpty(user))
                return result;
            string urlRoot = SPContext.Current.Site.Url;
            SPSecurity.RunWithElevatedPrivileges(delegate ()
            {
                using (SPSite oSite = new SPSite(urlRoot))
                {
                    using (SPWeb oWeb = oSite.RootWeb)
                    {
                        oWeb.AllowUnsafeUpdates = true;
                        SPList lstUserToken = oWeb.Lists["UserToken"];
                        SPQuery query = new SPQuery();
                        query.Query = "<Where><Eq><FieldRef Name='UserLogin'/><Value Type='Text'>" + user + "</Value></Eq></Where>";
                        query.RowLimit = 1;
                        query.ViewFields = "<FieldRef Name='TokenDevice'/>";
                        query.ViewFieldsOnly = true;
                        SPListItemCollection items = lstUserToken.GetItems(query);
                        if (items.Count > 0)
                        {
                            SPListItem item = items[0];
                            if (item["TokenDevice"] != null)
                            {
                                string[] tokens = item["TokenDevice"].ToString().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var token in tokens)
                                {
                                    result.Add(token);
                                }
                            }
                        }
                    }
                }
            });
            return result;
        }
        #endregion
    }

    [DataContract]
    [KnownType(typeof(NhanKhau))]
    [KnownType(typeof(List<string>))]
    [KnownType(typeof(API_DataLogin))]
    [Serializable]
    public class APIResult
    {
        [DataMember]
        public object data { get; set; }
        [DataMember]
        public ErrorResult error { get; set; }

        public APIResult()
        {
            data = null;
            error = new ErrorResult();
        }
    }

    [DataContract]
    public class ErrorResult
    {
        [DataMember]
        public string userMessage { get; set; }
        [DataMember]
        public string internalMessage { get; set; }
        [DataMember]
        public int code { get; set; }
        public ErrorResult()
        {
            this.userMessage = string.Empty;
            this.internalMessage = string.Empty;
            this.code = 200;
        }
    }

    public class API_DataLogin
    {
        public string token { get; set; }
        public string identifier { get; set; }
        public string soHoKhau { get; set; }
        public string avartar { get; set; }
        public string fullName { get; set; }
        public string birthday { get; set; }
        public string address { get; set; }
        public string sex { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string maXa { get; set; }
        public API_DataLogin()
        {
            this.token = string.Empty;
            this.soHoKhau = string.Empty;
            this.avartar = string.Empty;
            this.fullName = string.Empty;
            this.birthday = string.Empty;
            this.address = string.Empty;
            this.sex = string.Empty;
            this.phoneNumber = string.Empty;
            this.email = string.Empty;
            this.maXa = string.Empty;
        }
    }
}
