using AutoMapper;
using BloggerCore.Dtos;
using BloggerDomain;

namespace BloggerCore.AutoMapperProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<CreatePostDto, Post>();
        }
    }
}
