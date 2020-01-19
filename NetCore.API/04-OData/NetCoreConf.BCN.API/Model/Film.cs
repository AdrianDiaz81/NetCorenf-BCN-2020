namespace NetCoreConf.BCN.API.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Film")]
    public class Film : Base
    {
        public string Name { get; set; }
        public string Created { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
     
        public virtual ICollection<AvengerFilm> AvengerFilm { get; set; }
         }
}
