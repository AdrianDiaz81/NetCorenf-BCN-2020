namespace NetCoreConf.BCN.API.Model
{
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Avenger")]
    public class Avenger : Base
    {
        public string Name { get; set; }
        public string UrlPhoto { get; set; }
        public string Description { get; set; }
    }
}
