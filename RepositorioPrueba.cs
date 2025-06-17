using PeliculasAPI.Entidades;

namespace PeliculasAPI
{
    public class RepositorioPrueba : IRepositorio //Asignacion de la Interfaz dentro de la clase
    {
        private List<Genero> _generos;

        public RepositorioPrueba() 
        {
            _generos = new List<Genero>
            {
                new Genero { Id = 1, Nombre = "Comedia" },
                new Genero { Id = 2, Nombre = "Accion" },
                new Genero { Id = 3, Nombre = "Drama" }
            };
        }

        public void CrearGenero(Genero genero) 
        {
            _generos.Add(genero);
        }

        public List<Genero> GetAllGeneros()
        {
            return _generos;
        }

        public async Task<Genero?> GetOne(int id)  //Programacion Asyncrono
        {
            await Task.Delay(TimeSpan.FromSeconds(3));  //Espera asincrona
            return _generos.FirstOrDefault(o => o.Id == id);
        }

        public bool IsExist(string nombre)
        {
            return _generos.Any(g => g.Nombre == nombre);
        }
    }
}
