using PeliculasAPI.Entidades;

namespace PeliculasAPI
{
    public interface IRepositorio
    {
        void CrearGenero(Genero genero);
        List<Genero> GetAllGeneros();
        Task<Genero?> GetOne(int id);

        bool IsExist(string nombre);
    }
}
