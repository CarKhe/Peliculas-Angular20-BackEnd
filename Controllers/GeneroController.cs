using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
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
        private readonly IConfiguration _configuration;
        private const string _cacheTag = "generos";
        public GeneroController(
            IOutputCacheStore outputCacheStore,
            IConfiguration configuration)
        {
            
            _outputCacheStore = outputCacheStore;
            _configuration = configuration;
        }

        [HttpGet]
        [OutputCache(Tags = [_cacheTag])]
        public List<Genero>Get() 
        {
            return new List<Genero>() {
            new Genero { Id = 1, Nombre = "Acción" },
            new Genero { Id = 2, Nombre = "Comedia" },
            new Genero { Id = 3, Nombre = "Drama" }
            };
        }

        [HttpGet("{id:int}")]
        [OutputCache(Tags = [_cacheTag])]
        public async Task<ActionResult<Genero>> Get(int id) 
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Genero genero )
        {
            throw new NotImplementedException();
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
