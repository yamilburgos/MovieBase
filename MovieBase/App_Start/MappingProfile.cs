using AutoMapper;
using MovieBase.Dtos;
using MovieBase.Models;

namespace MovieBase.App_Start {
    public class MappingProfile : Profile {

        public MappingProfile() {
            // Create a Mapping Configuration to swap values between 2 types.
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();

            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}