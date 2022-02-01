using AutoMapper;
using GamesStore.Entities;
using GamesStore.Models;

namespace GamesStore.Mappers
{
    public class GameMapper : Profile
    {
        public GameMapper()
        {
            CreateMap<AddGameInputModel, Games>()
                .ForMember(gm => gm.ReleaseDate, option => option.MapFrom(p => p.releaseDate.ToString()));
            CreateMap<AddUserInputModel, User>()
                .ForMember(gm => gm.DateOfBirth, option => option.MapFrom(p => p.dayOfByrth.ToString()));
            //CreateMap<AddReviewInputModel, Review>();
        }
    }
}
