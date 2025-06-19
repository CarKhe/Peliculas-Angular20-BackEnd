using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using PeliculasAPI.DTO_s;
using PeliculasAPI.Entidades;
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
        public async Task<List<GeneroDTO>>Get() 
        {
            //var generos = await _context.Generos.ToListAsync();

            //var generosDTO = _mapper.Map<List<GeneroDTO>>(generos); 

            //return generosDTO;
            return await _context.Generos.ProjectTo<GeneroDTO>(_mapper.ConfigurationProvider).ToListAsync();

        }

        [HttpGet("{id:int}",Name = "ObtenerGeneroId")]
        [OutputCache(Tags = [_cacheTag])]
        public async Task<ActionResult<GeneroDTO>> Get(int id) 
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GeneroCreacionDTO generoCreacionDTO )
        {
            //var genero = new Genero { Nombre = generoCreacionDTO.Nombre };
            //AutoMapper
            var genero = _mapper.Map<Genero>(generoCreacionDTO);
            _context.Add(genero);//Guardar el genero en memoria
            await _context.SaveChangesAsync(); //Inserat como registro en la tabla de generos
            return CreatedAtRoute("ObtenerGeneroId",new {id = genero.Id},genero); //mostrar con que ID fue registrado
        }

        [HttpPut]
        public void Put()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public void Delete()
        {
            throw new NotImplementedException();
        }

    }
}
