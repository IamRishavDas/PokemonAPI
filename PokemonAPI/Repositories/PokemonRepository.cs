﻿using PokemonAPI.Interfaces;
using PokemonAPI.Models;
using PokemonAPI.Data;

namespace PokemonAPI.Repositories
{
    public class PokemonRepository: IPokemonInterface

    {
        private readonly DataContext _dataContext; 
        public PokemonRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Pokemon GetPokemon(int pokemonId)
        {
            return _dataContext.Pokemons.Where(o => o.Id == pokemonId).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokemonId)
        {
            var reviews = _dataContext.Reviews.Where(c => c.Id == pokemonId);
            if (reviews.Count() < 0) return 0;
            return (decimal)reviews.Sum(s => s.Rating)/(decimal)reviews.Count();
        }

        public bool IsPokemonExist(int pokemonId)
        {
            var isPokemonExist = _dataContext.Pokemons.Any(p => p.Id == pokemonId);
            return isPokemonExist;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _dataContext.Pokemons.OrderBy(o => o.Id).ToList();
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _dataContext.Owners.Where(a => a.Id == ownerId).FirstOrDefault();
            var category = _dataContext.Categories.Where(a => a.Id == categoryId).FirstOrDefault();

            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon
            };

            _dataContext.Add(pokemonOwner);

            var pokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon
            };

            _dataContext.Add(pokemonCategory);

            _dataContext.Add(pokemon);
            return Save();
        }

        public bool Save()
        {
            var save = _dataContext.SaveChanges();
            return save > 0;
        }
    }
}
