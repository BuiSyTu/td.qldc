using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD.QLDC.Library.Validations;

namespace TD.QLDC.Library.Models
{
    public class Area : ModelBaseExt
    {
        public string Type { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Note { get; set; }

        public bool? Active { get; set; }

        public int? ParentId { get; set; }

        public Area Parent { get; set; }
    }
}
