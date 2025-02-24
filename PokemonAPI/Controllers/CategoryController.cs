using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Repositories;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(CategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<Category>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid || categories == null) { return BadRequest(); }
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        public IActionResult GetCategory(int categoryId)
        {

            if (!_categoryRepository.IsCategoryExist(categoryId)) return NotFound();
            var category = _mapper.Map<Category>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid) return BadRequest();
            return Ok(category);
        } 
        
        [HttpGet("{categoryId}/pokemons")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategoryId(int categoryId)
        {

            if (!_categoryRepository.IsCategoryExist(categoryId)) return NotFound();
            var pokemons = _mapper.Map<Pokemon>(_categoryRepository.GetPokemonByCategory(categoryId));
            if (!ModelState.IsValid) return BadRequest();
            return Ok(pokemons);
        }

        [HttpGet("{categoryId}/isValid")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult GetIfPokemonExists(int categoryId)
        {

            return Ok(_categoryRepository.IsCategoryExist(categoryId)));
            
        }

    }
}
