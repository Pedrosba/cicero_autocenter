using AutoMapper;
using cicero_autocenterAPI.DTOs;
using cicero_autocenterAPI.Models;

namespace cicero_autocenterAPI.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<ClienteDTO_Cadastro, Cliente>();
            CreateMap<Cliente, ClienteDTO_Alterar>().ReverseMap();
        }
    }
}
