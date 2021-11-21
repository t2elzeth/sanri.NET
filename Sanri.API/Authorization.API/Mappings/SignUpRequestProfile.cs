using AutoMapper;
using Sanri.API.Authorization.API.DTOs;
using Sanri.Application.Authorization.API.Handlers;

namespace Sanri.API.Authorization.API.Mappings
{
    public class SignUpRequestProfile: Profile
    {
        public SignUpRequestProfile()
        {
            CreateMap<SignUpRequest, SignUpCommand>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}