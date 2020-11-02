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
            CreateMap<Post, PostDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>()
                .ForMember(x => x.PersonName, y => y.MapFrom(z => z.Person.FirstName + " " + z.Person.LastName))
                .ForMember(x => x.PersonImage, y => y.MapFrom(z => z.Person.Image));
            CreateMap<LikeDto, Like>();
        }
    }
}
