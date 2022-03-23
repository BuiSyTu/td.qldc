using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using TD.Core.Api.Mvc;
using TD.Core.UserProfiles.Controllers;
using TD.Core.UserProfiles.Models;
using TD.QLDC.Library.Models;
using TD.QLDC.Library.Repositories.Interfaces;

namespace TD.QLDC.Library.Repositories.Implementations
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        private QLDCDbContext _dbContext;

        public AreaRepository(
            QLDCDbContext dbContext,
            ICoreContextAccessor contextAccessor
        ) : base(dbContext, contextAccessor)
        {
            _dbContext = dbContext;
        }

        public int Count(string q = null, string areaCode = null, int? type = null, string parentCode = null)
        {
            return _dbContext.Areas
                .Filter(
                    !string.IsNullOrEmpty(q),
                    x => x.Name.Contains(q)|| x.Code.Contains(q)
                )
                .Filter(
                    !string.IsNullOrEmpty(areaCode),
                    x => x.Code == areaCode
                        || x.Parent.Code == areaCode
                        || x.Parent.Parent.Code == areaCode
                        || x.Parent.Parent.Parent.Code == areaCode
                        || x.Parent.Parent.Parent.Parent.Code == areaCode
                )
                .Filter(
                    type != null,
                    x => x.Type == type.ToString()
                )
                .FilterParentCode(parentCode)
                .Count();
        }

        public ICollection<Area> Get(
            int skip = 0,
            int top = 20,
            string q = null,
            string includes = null,
            string orderBy = null,
            string areaCode = null,
            int? type = null,
            string parentCode = null
        )
        {
            return _dbContext.Areas
                .IncludeMany(includes)
                .Filter(
                    !string.IsNullOrEmpty(q),
                    x => x.Name.Contains(q) || x.Code.Contains(q)
                )
                .Filter(
                    !string.IsNullOrEmpty(areaCode),
                    x => x.Code == areaCode
                        || x.Parent.Code == areaCode
                        || x.Parent.Parent.Code == areaCode
                        || x.Parent.Parent.Parent.Code == areaCode
                        || x.Parent.Parent.Parent.Parent.Code == areaCode
                )
                .Filter(
                    type != null,
                    x => x.Type == type.ToString()
                )
                .FilterParentCode(parentCode)
                .OrderByMany(orderBy)
                .Skip(skip)
                .Take(top)
                .ToList();
        }

        public ICollection<Area> GetByCodes(string codes, string includes = null)
        {
            var codeList = codes.Split(',').ToList();
            return _dbContext.Areas
                .IncludeMany(includes)
                .Filter(codeList.Count > 0, x => codeList.Contains(x.Code))
                .ToList();
        }

        public Dictionary<string, string> GetCurrentArea()
        {
            Dictionary<string, string> dictionary = new();
            string areaCode = string.Empty;
            string provinceCode = ConfigurationManager.AppSettings["ProvinceCode"] ?? "";
            string provinceName = ConfigurationManager.AppSettings["ProvinceName"] ?? "";
            string districtCode = ConfigurationManager.AppSettings["DistrictCode"] ?? "";
            string districtName = ConfigurationManager.AppSettings["DistrictName"] ?? "";
            string wardCode = ConfigurationManager.AppSettings["WardCode"] ?? "";
            string wardName = ConfigurationManager.AppSettings["WardName"] ?? "";

            string urlRoot = SPContext.Current.Site.RootWeb.Url;
            using (SPSite oSite = new(urlRoot))
            {
                var webApp = oSite.WebApplication;
                var zone = oSite.Zone;

                UserProfileController userProfileCtrlr = new(webApp, zone);
                UserProfile userProfile = userProfileCtrlr.GetByCurrentUser();
                areaCode = userProfile.AreaCode;
            }

            dictionary.Add("ProvinceCode", provinceCode);
            dictionary.Add("ProvinceName", provinceName);
            dictionary.Add("DistrictCode", districtCode);
            dictionary.Add("DistrictName", districtName);
            dictionary.Add("WardCode", wardCode);
            dictionary.Add("WardName", ConfigurationManager.AppSettings["WardName"]);

            switch (areaCode.Length)
            {
                case 2:
                    dictionary.Add("AreaCode", provinceCode);
                    dictionary.Add("AreaName", provinceName);
                    break;
                case 3:
                case 4:
                    dictionary.Add("AreaCode", districtCode);
                    dictionary.Add("AreaName", districtName);
                    break;
                case 5:
                    dictionary.Add("AreaCode", wardCode);
                    dictionary.Add("AreaName", wardName);
                    break;
                case 7:
                    Area village7 = GetByCode(areaCode);
                    dictionary.Add("VillageCode", areaCode);
                    dictionary.Add("VillageName", village7.Name);
                    dictionary.Add("AreaCode", areaCode);
                    dictionary.Add("ProvinceName", village7.Name);
                    break;
                case 9:
                    var hamlet = GetByCode(areaCode);
                    var villageId = hamlet.ParentId.Value;
                    Area village9 = GetById(villageId);

                    dictionary.Add("VillageCode", village9.Code);
                    dictionary.Add("VillageName", village9.Name);
                    dictionary.Add("HamletCode", hamlet.Code);
                    dictionary.Add("HamletName", hamlet.Name);
                    dictionary.Add("AreaCode", hamlet.Code);
                    dictionary.Add("AreaName", hamlet.Name);
                    break;
            }
            return dictionary;
        }

        private Area GetByCode(string code)
        {
            return _dbContext.Areas.FirstOrDefault(x => x.Code == code);
        }

        public ICollection<Area> GetMultipleByName(string name, string includes = null)
        {
            return _dbContext.Areas
                .IncludeMany(includes)
                .Where(x => x.Name == name)
                .ToList();
        }

        public Area GetSingleByCode(string code, string includes = null)
        {
            return _dbContext.Areas
                .IncludeMany(includes)
                .FirstOrDefault(x => x.Code == code);
        }

        public Area GetSingleByName(string name)
        {
            return _dbContext.Areas.FirstOrDefault(x => x.Name == name);
        }

        public Area GetSingleByTags(string tags)
        {
            return _dbContext.Areas.FirstOrDefault(x => x.Tags == tags);
        }
    }

    public static class QueryableAreaExtension
    {
        public static IQueryable<Area> FilterParentCode(this IQueryable<Area> query, string parentCode = null)
        {
            if (string.IsNullOrEmpty(parentCode)) return query;

            var newQuery = query.Where(x => x.Parent.Code == parentCode);
            return newQuery;
        }
    }
}
