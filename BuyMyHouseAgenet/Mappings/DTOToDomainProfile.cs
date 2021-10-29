using AutoMapper;
using BuyMyHouseAgenet.DTO;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouseAgenet.Mappings
{
   public class DTOToDomainProfile : Profile
    {
        public DTOToDomainProfile()
        {
            CreateMap<User, AuthenticateResponseDTO>();
            CreateMap<RegisterRequestDTO, User>();
        }
    }
}
