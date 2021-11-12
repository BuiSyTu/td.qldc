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