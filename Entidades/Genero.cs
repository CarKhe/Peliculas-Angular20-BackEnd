using PeliculasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Entidades
{
    public class Genero
    {
        [Required]
        public  int Id { get; set; }
        
        [Required(ErrorMessage ="El Campo {0} es Requerido")] //Validacion de ASP NET CORE
        //{0} pone la primera variable que encuentre
        [StringLength(10,ErrorMessage ="El {0} no debe ser mayor a {1}")]//{1} atributo del String Length
        [CapitalAttribute]
        public required string Nombre { get; set; }

        //[Required(ErrorMessage ="Cámpo {0} Requerido")]
        //[Range(18,120,ErrorMessage ="Debe ser mayor de edad o No estar muerto")]
        //public int Edad {  get; set; }

        //[CreditCard]
        //public string? TarjetaCredito { get; set; }

        //[Url]
        //public string? Url { get; set; }
    }
}
