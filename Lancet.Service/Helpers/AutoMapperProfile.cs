using Lancet.Models.Domain.Dtos;
using Lancet.Models.Domain.Model;
using AutoMapper;

namespace Lancet.Service.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
