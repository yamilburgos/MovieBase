using AutoMapper;
using MovieBase.Dtos;
using MovieBase.Models;

namespace MovieBase.App_Start {
    public class MappingProfile : Profile {

        public MappingProfile() {
            // Create a Mapping Configuration to swap values between 2 types.
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}