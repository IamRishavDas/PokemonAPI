

using Microsoft.AspNetCore.Mvc;

using PokemonAPI.Repositories;
using PokemonAPI.Models;
using AutoMapper;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly PokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;
        public PokemonController(PokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _mapper.Map<List<Pokemon>>(_pokemonRepository.GetPokemons());
            if (!ModelState.IsValid || pokemons == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }

        [HttpGet("{pokemonId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokemonId)
        {

            if (!_pokemonRepository.IsPokemonExist(pokemonId)) return NotFound();
            var pokemon = _mapper.Map<Pokemon>(_pokemonRepository.GetPokemon(pokemonId));
            return Ok(pokemon);

        }
        
        [HttpGet("{pokemonId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokemonId)
        {

            if (!_pokemonRepository.IsPokemonExist(pokemonId)) return NotFound();
            var pokemon = _pokemonRepository.GetPokemonRating(pokemonId);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(pokemon);

        }
    }
}
