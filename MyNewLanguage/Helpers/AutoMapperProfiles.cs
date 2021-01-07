using AutoMapper;
using MyNewLanguage.Dtos;
using MyNewLanguage.Models.Identity;

namespace MyNewLanguage.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserToChangePasswordDto>().ReverseMap();
            
        }
    }
}