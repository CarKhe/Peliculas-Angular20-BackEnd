using PeliculasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTO_s
{
    public class GeneroDTO
    {
        [Required]
        public int Id { get; set; }
        public required string Nombre { get; set; }
    }
}
