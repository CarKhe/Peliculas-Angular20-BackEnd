using AutoMapper;
using PeliculasAPI.DTO_s;
using PeliculasAPI.Entidades;

namespace PeliculasAPI.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            ConfigurarMapeoGeneros();
            ConfigurarMapeoActores();
        }

        private void ConfigurarMapeoActores()
        {
            CreateMap<ActorCreacionDTO, Actor>()
                .ForMember(x => x.Foto,op => op.Ignore());
        }

        private void ConfigurarMapeoGeneros()
        {
            CreateMap<GeneroCreacionDTO, Genero>();
            CreateMap<Genero,GeneroDTO>();
        }
    }
}
