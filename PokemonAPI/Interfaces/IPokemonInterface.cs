using PokemonAPI.Models;

namespace PokemonAPI.Interfaces
{
    public interface IPokemonInterface
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int pokemonId);
        decimal GetPokemonRating(int pokemonId);
        bool IsPokemonExist(int pokemonId);
        bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);
        bool Save();
    }
}
