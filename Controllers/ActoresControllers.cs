using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using PeliculasAPI.DTO_s;
using PeliculasAPI.Entidades;
using PeliculasAPI.Servicios;

namespace PeliculasAPI.Controllers
{
    [Route("api/actores")]
    [ApiController]
    public class ActoresControllers: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IOutputCacheStore _cache;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private const string _cachetag = "Actores";
        private readonly string _carpeta = "actores";

        public ActoresControllers(ApplicationDbContext context, IMapper mapper, IOutputCacheStore cache,
            IAlmacenadorArchivos almacenadorArchivos)
        {
            this._context = context;
            this._mapper = mapper;
            this._cache = cache;
            this._almacenadorArchivos = almacenadorArchivos;
        }

        [HttpGet("{id:int}", Name = "ObtenerActorPorId")]
        public void Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ActorCreacionDTO actorCreacionDTO)
        {
            var actor = _mapper.Map<Actor>(actorCreacionDTO);

            if (actorCreacionDTO.Foto is not null)
            {
                var url = await _almacenadorArchivos.Almacenar(_carpeta,actorCreacionDTO.Foto);
            }

            _context.Add(actor);
            await _context.SaveChangesAsync();
            await _cache.EvictByTagAsync(_cachetag, default);

            return CreatedAtRoute("ObtenerActorPorId: ",new {id = actor.Id}, actor);
        }
    }
}
