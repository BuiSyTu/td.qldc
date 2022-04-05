﻿using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TD.QLDC.Library.Models
{
    public class Category : ModelBaseExt
    {
        private int? nhomID;
        public virtual int? NhomID { get { return nhomID; } set { nhomID = value; NotifyPropertyChanged(); } }
        public virtual NhomDanhMuc Nhom { get; set; }

        private string fullTextSearch;
        [JsonIgnore]
        public string FullTextSearch { get { return fullTextSearch; } set { fullTextSearch = value; NotifyPropertyChanged(); } }

        private string tags;
        public string Tags { get { return tags; } set { tags = value; NotifyPropertyChanged(); } }

        private string name;
        [MaxLength(256)]
        public string Name { get { return name; } set { name = value; NotifyPropertyChanged(); } }

        private string description;
        public virtual string Description { get { return description; } set { description = value; NotifyPropertyChanged(); } }

        private bool active;
        [DefaultValue(true)]
        public bool Active { get { return active; } set { active = value; NotifyPropertyChanged(); } }

        private int order;
        public int Order { get { return order; } set { order = value; NotifyPropertyChanged(); } }
    }
}
