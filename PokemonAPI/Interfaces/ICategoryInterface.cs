using PokemonAPI.Models;

namespace PokemonAPI.Interfaces
{
    public interface ICategoryInterface
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int categoryId);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool IsCategoryExist(int categoryId);
    }
}
