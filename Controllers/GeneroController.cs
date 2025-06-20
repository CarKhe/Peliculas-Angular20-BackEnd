using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTO_s;
using PeliculasAPI.Entidades;
using PeliculasAPI.Utilidades;
using System.Data;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PeliculasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController: ControllerBase
    {
        
        private readonly IOutputCacheStore _outputCacheStore;
        private readonly ApplicationDbContext _context; //Clase Abstracta
        private readonly IMapper _mapper;
        private const string _cacheTag = "generos";


        public GeneroController(IOutputCacheStore outputCacheStore,ApplicationDbContext context, IMapper mapper)
        {
            
            _outputCacheStore = outputCacheStore;
            _context = context;
            //AutoMapper
            _mapper = mapper;
        }

        [HttpGet]
        [OutputCache(Tags = [_cacheTag])]
        public async Task<List<GeneroDTO>> Get([FromQuery] PaginacionDTO paginacionDTO) 
        {
            //var generos = await _context.Generos.ToListAsync();

            //var generosDTO = _mapper.Map<List<GeneroDTO>>(generos); 

            //return generosDTO;
            var queryable = _context.Generos;
            await HttpContext.InsertParametrosPaginacionEnCabecera(queryable);

            //Mas eficiente al realizar consultas que no necesita
            return await queryable
                .OrderBy(g => g.Nombre)
                .Paginar(paginacionDTO)
                .ProjectTo<GeneroDTO>(_mapper.ConfigurationProvider).ToListAsync();

        }

        [HttpGet("{id:int}",Name = "ObtenerGeneroId")]
        [OutputCache(Tags = [_cacheTag])]
        public async Task<ActionResult<GeneroDTO>> Get(int id) 
        {
            var genero = await _context.Generos
                .ProjectTo<GeneroDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(g => g.Id == id);
            if (genero is null) return NotFound();
            return genero;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO )
        {
            //var genero = new Genero { Nombre = generoCreacionDTO.Nombre };
            //AutoMapper
            var genero = _mapper.Map<Genero>(generoCreacionDTO);
            _context.Add(genero);//Guardar el genero en memoria
            await _context.SaveChangesAsync(); //Inserat como registro en la tabla de generos
            await _outputCacheStore.EvictByTagAsync(_cacheTag, default);
            return CreatedAtRoute("ObtenerGeneroId",new {id = genero.Id},genero); //mostrar con que ID fue registrado
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] GeneroCreacionDTO generoCreacionDTO)
        {
            var existe = await _context.Generos.AnyAsync(g => g.Id == id);
            if (!existe) return NotFound();
            var genero = _mapper.Map<Genero>(generoCreacionDTO);
            genero.Id = id;
            _context.Update(genero);
            await _context.SaveChangesAsync();
            await _outputCacheStore.EvictByTagAsync(_cacheTag,default);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var registrosBorrados = await _context.Generos.Where(g => g.Id == id).ExecuteDeleteAsync();
            if (registrosBorrados == 0) return NotFound();
            await _outputCacheStore.EvictByTagAsync(_cacheTag, default);
            return NoContent();
        }

    }
}
