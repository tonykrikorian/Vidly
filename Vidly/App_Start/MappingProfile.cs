using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(x=>x.Id,opt=>opt.Ignore());
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypeDTO>();
           

            Mapper.CreateMap<MovieDTO, Movie>().ForMember(x=>x.Id,opt=>opt.Ignore());
            Mapper.CreateMap<Movie, MovieDTO>();

        }

       
    }
}