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
            Mapper.CreateMap<Customer, CustomerDTO>().ForMember(x=>x.Id,opt=>opt.Ignore());
            Mapper.CreateMap<CustomerDTO, Customer>();

            Mapper.CreateMap<Movie, MovieDTO>().ForMember(x=>x.Id,opt=>opt.Ignore());
            Mapper.CreateMap<MovieDTO, Movie>();
        }

       
    }
}