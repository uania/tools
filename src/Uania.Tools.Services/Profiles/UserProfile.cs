using AutoMapper;
using Uania.Tools.Repository.Entities;
using Uania.Tools.Models.SportsTesting;

namespace Uania.Tools.Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<SportsTestingUser, SportsTestingUsers>();
        }
    }
}