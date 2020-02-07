using System.ComponentModel.DataAnnotations;

namespace NetCoreConf.BCN.API.Model
{
    public class AvengerFilm:Base
    {
        [Required]
        public int AvengerId { get; set; } 
        [Required]
        public int FilmId { get; set; } 
    }
}
