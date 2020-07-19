using HealthCareApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareApi.Repositories
{
    public interface IAgentRepository
    {
        Task<IList<Agent>> GetAll();
        Task<Agent> GetById(int id);
        Task<Agent> GetOne(string agentCode);
        Task<Agent> Create(Agent agent);
        Task<Agent> Edit(int id, Agent agent);
        Task Delete(int id);
        bool Exists(Agent agent); 
    }
}
