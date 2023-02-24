using Microsoft.AspNetCore.Mvc;
using HttpClientCardService;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        // GET: api/pokemon
        [HttpGet]
        [Consumes("application/json")]
        public async Task<IActionResult> GetPokemonList()
        {
            var getList = new PokemonService();
            return new ObjectResult(await getList.GetPokemon());
        }

        // GET api/pokemon/name
        [HttpGet("{pokemoneName}")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetPokemonData(string pokemoneName)
        {
            var getList = new PokemonService();
            return new ObjectResult(await getList.GetPokemonDetail(pokemoneName));
        }
    }
}
