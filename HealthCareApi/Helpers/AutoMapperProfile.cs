using AutoMapper;
using HealthCareApi.Dtos;
using HealthCareApi.Models;

namespace HealthCareApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Agent, HeaAgents>();
            CreateMap<HeaAgents, Agent>();
        }
    }
}
