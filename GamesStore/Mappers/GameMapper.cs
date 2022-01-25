using AutoMapper;
using GamesStore.Entities;
using GamesStore.Models;

namespace GamesStore.Mappers
{
    public class GameMapper : Profile
    {
        public GameMapper()
        {
            CreateMap<AddGameInputModel, Games>();
            CreateMap<AddPromocaoInputModel, Promocao>();
            CreateMap<AddUsuarioInputModel, Usuario>()
                .ForMember(gm => gm.DataDeNascimento, option => option.MapFrom(p => p.dataDeNascimento.ToString()));
            CreateMap<AddReviewInputModel, Review>();
        }
    }
}
