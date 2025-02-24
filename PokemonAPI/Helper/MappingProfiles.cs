using AutoMapper;

using PokemonAPI.Models;
using PokemonAPI.Dto;

namespace PokemonAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // creating a mapping field for Pokemon --> PokemonDto
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
