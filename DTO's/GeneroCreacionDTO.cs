using PeliculasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTO_s
{
    public class GeneroCreacionDTO
    {
        [Required(ErrorMessage = "El Campo {0} es Requerido")] 
        [StringLength(50, ErrorMessage = "El {0} no debe ser mayor a {1}")]
        [CapitalAttribute]
        public required string Nombre { get; set; }
    }
}
