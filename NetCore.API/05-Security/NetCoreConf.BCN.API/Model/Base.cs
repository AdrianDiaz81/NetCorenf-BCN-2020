namespace NetCoreConf.BCN.API.Model
{
    using System.ComponentModel.DataAnnotations;
    public class Base
    {
        [Key]
        public string Id { get; set; }
    }
}
