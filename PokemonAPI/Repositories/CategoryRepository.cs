using AutoMapper;
using PokemonAPI.Data;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Repositories
{
    public class CategoryRepository : ICategoryInterface
    {

        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
         }

        public ICollection<Category> GetCategories()
        {
            return _dataContext.Categories.ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _dataContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            var pokemonsByCategory = _dataContext.PokemonCategories.Where(c => c.CategoryId == categoryId)
                .Select(s => s.Pokemon).ToList();

            return pokemonsByCategory;
        }

        public bool IsCategoryExist(int categoryId)
        {
            return _dataContext.Categories.Any(c => c.Id == categoryId);
        }
    }
}
