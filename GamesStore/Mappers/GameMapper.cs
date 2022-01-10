using AutoMapper;
using GamesStore.Entities;
using GamesStore.Models;

namespace GamesStore.Mappers
{
    public class GameMapper : Profile
    {
        public GameMapper()
        {
            CreateMap<AddGameInputModel, Game>();
            CreateMap<AddPromocaoInputModel, Promocao>();
        }
    }
}
