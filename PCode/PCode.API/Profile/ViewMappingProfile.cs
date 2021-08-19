using AutoMapper;

using PCode.DataAccess.Models;
using PCode.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCode.API
{
    public class ViewMappingProfile : Profile
    {
        public ViewMappingProfile()
        {
            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<AuthenticationDTO, Authentication>();
            CreateMap<Authentication, AuthenticationDTO>();
        }
    }
}
