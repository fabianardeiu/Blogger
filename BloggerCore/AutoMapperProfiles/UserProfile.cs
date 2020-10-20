using AutoMapper;
using BloggerCore.Dtos;
using BloggerDomain;

namespace BloggerCore.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}
