using System;
using TD.Core.Api;
using TD.Core.Api.Common;

namespace TD.QLDC.Library.Models
{
    public abstract class ModelBaseExt: PartialUpdatableEntity<int>, IModificationTrackableEntity
    {
        public ModelBaseExt()
        {
            Created = DateTime.Now;
        }

        private string createdBy;
        private DateTime? created;
        private string modifiedBy;
        private DateTime? modified;

        /// <summary>
        /// Được tạo bởi
        /// </summary>
        public string CreatedBy
        {
            get
            {
                return createdBy;
            }
            set
            {
                createdBy = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Được tạo tại thời điểm
        /// </summary>
        public DateTime? Created
        {
            get
            {
                return created;
            }
            set
            {
                created = value;
                NotifyPropertyChanged();
            }
        }
        /// <summary>
        /// Được chỉnh sửa bởi
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return modifiedBy;
            }
            set
            {
                modifiedBy = value;
                NotifyPropertyChanged();
            }
        }
        /// <summary>
        /// Được chỉnh sửa tại thời điểm
        /// </summary>
        public DateTime? Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
                NotifyPropertyChanged();
            }
        }
    }
}