using AutoMapper;
using BetScore.Application.DTOs;
using BetScore.Domain.Entities;

namespace BetScore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserDTO>();
        }

    }

}
