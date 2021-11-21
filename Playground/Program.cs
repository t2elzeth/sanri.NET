using System;
using AutoMapper;

namespace Playground
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserProfile>();
            });

            var mapper = configuration.CreateMapper();

            var userDTO = new UserDTO
            {
                FirstName = "Ulukman",
                LastName  = "Amangeldiev"
            };

            var user = mapper.Map<User>(userDTO);
        }
    }

    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class User
    {
        public string FullName { get; set; }
    }
    
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + src.LastName));
        }
    }
}