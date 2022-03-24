namespace TD.QLDC.Library.Models
{
    public class Area : ModelBaseExt
    {
        public string Tags { get; set; }

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
