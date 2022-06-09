using AutoMapper;
using SimpleWebApi.DTOs;
using SimpleWebApi.Models;

namespace SimpleWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
        }
    }
}
