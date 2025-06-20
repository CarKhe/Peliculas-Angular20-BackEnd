using PeliculasAPI.DTO_s;

namespace PeliculasAPI.Utilidades
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable,PaginacionDTO paginacionDTO)
        {
            return queryable
                .Skip((paginacionDTO.pagina - 1) * paginacionDTO.RecordsPerPage)
                .Take(paginacionDTO.RecordsPerPage);
        }
    }
}
