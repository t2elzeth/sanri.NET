using AutoMapper;
using Sanri.API.Authorization.API.DTOs;
using Sanri.Application.Authorization.API.Handlers;

namespace Sanri.API.Authorization.API.Mappings
{
    public class SignInRequestProfile: Profile
    {
        public SignInRequestProfile()
        {
            CreateMap<SignInRequest,SignInCommand>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
        }
    }
}