using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomersDTO>();
            Mapper.CreateMap<CustomersDTO, Customer>();
        }

        protected override void Configure()
        {
            throw new NotImplementedException();
        }
    }
}