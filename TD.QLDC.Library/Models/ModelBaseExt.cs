using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TD.Core.Api;
using TD.Core.Api.Common;

namespace TD.QLDC.Library.Models
{
    public abstract class ModelBaseExt: PartialUpdatableEntity<int>, IModificationTrackableEntity
    {
        private string createdBy;
        public string CreatedBy { get { return createdBy; } set { createdBy = value; NotifyPropertyChanged(); } }

        private DateTime? created;
        public DateTime? Created { get { return created; } set { created = value; NotifyPropertyChanged(); } }

        private string modifiedBy;
        public string ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; NotifyPropertyChanged(); } }

        private DateTime? modified;
        public DateTime? Modified { get { return modified; } set { modified = value; NotifyPropertyChanged(); } }

        [NotMapped]
        [JsonExtensionData]
        public Dictionary<string, object> ExtensionData { get; } = new Dictionary<string, object>();
    }
}