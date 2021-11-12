using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Models
{
    [FullTextIndexedTable]
    [TextSearchColumns(nameof(Name), nameof(Description))]
    public abstract class CategoryBase : ModelBaseExt
    {
        public CategoryBase()
        {
            Active = true;
            Created = DateTime.Now;
        }

        private string name;
        private string description;
        private int order;
        private bool active;
        private int? nhomID;

        [FullTextIndex]
        [MaxLength(256)]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }
        public virtual int? NhomID
        {
            get
            {
                return nhomID;
            }
            set
            {
                nhomID = value;
                NotifyPropertyChanged();
            }
        }
        [FullTextIndex]
        public virtual string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                NotifyPropertyChanged();
            }
        }

        [DefaultValue(true)]
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
                NotifyPropertyChanged();
            }
        }

        public int Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
                NotifyPropertyChanged();
            }
        }

        public virtual NhomDanhMuc Nhom
        {
            get; set;
        }
    }
}