namespace NetCoreConf.BCN.API.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Avenger")]
    public class Avenger : Base
    {
        public string Name { get; set; }
        public string UrlPhoto { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AvengerFilm> AvengerFilm { get; set; }

    }
}
