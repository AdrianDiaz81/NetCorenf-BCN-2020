namespace NetCoreConf.BCN.API.Model
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Film")]
    public class Film : Base
    {
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
    }
}
