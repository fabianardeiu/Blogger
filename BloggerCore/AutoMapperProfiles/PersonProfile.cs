using AutoMapper;
using BloggerCore.Dtos;
using BloggerDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerCore.AutoMapperProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>();
        }
    }
}
