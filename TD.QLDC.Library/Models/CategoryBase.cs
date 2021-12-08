using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TD.Core.Api.Mvc;
using TD.QLDC.Library.Models;

namespace TD.QLDC.Library.Models
{
    public abstract class CategoryBase : ModelBaseExt
    {
        private string name;
        private string description;
        private int order;
        private bool active;
        private int? nhomID;

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