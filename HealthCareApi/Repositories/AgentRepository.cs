using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HealthCareApi.Dtos;
using HealthCareApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthCareApi.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly ModelContext _context;
        private readonly IMapper _mapper;
        readonly ILogger<AgentRepository> _logger;

        public AgentRepository(ModelContext context, IMapper mapper, ILogger<AgentRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Agent> Create(Agent agent)
        {
            HeaAgents heaAgents = _mapper.Map<HeaAgents>(agent);
            _context.HeaAgents.Add(heaAgents);
            await _context.SaveChangesAsync();
            _mapper.Map(heaAgents, agent);
            return agent;
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Agent> Edit(int id, Agent agent)
        {
            var heaAgents = await _context.HeaAgents.FindAsync(id);
            _mapper.Map(agent, heaAgents);
            _context.Entry(heaAgents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!HeaAgentsExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
                throw;
            }
            _mapper.Map(heaAgents, agent);
            return agent;
        }

        public bool Exists(Agent agent)
        {
            return _context.HeaAgents.Any(e => e.AgentCode == agent.AgentCode && e.AgentName == agent.AgentName);
        }

        public async Task<IList<Agent>> GetAll()
        {
            return _mapper.Map<IList<HeaAgents>, IList<Agent>>(_context.HeaAgents.ToList());
        }

        public async Task<Agent> GetById(int id)
        {
            var heaAgents = await _context.HeaAgents.FindAsync(id);
            return _mapper.Map<Agent>(heaAgents);
        }

        public async Task<Agent> GetOne(string agentCode)
        {
            throw new NotImplementedException();
        }
    }
}
