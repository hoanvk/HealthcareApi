using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthCareApi.Dtos;
using AutoMapper;
using Microsoft.Extensions.Logging;
using HealthCareApi.Repositories;

namespace HealthCareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IMapper _mapper;
        readonly ILogger<AgentController> _logger;
        private IAgentRepository _repository;
        public AgentController(IMapper mapper, ILogger<AgentController> logger, IAgentRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
        }
        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET: api/Agent
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>        
        [HttpGet]
        public async Task<IEnumerable<Agent>> GetHeaAgents()
        {
            return await _repository.GetAll();
        }

        // GET: api/Agent/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeaAgents([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agent = await _repository.GetById(id);

            if (agent == null)
            {
                return NotFound();
            }

            return Ok(agent);
        }

        // PUT: api/Agent/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeaAgents([FromRoute] int id, [FromBody] Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var agentOut = await _repository.Edit(id, agent);

            return NoContent();
        }

        // POST: api/Agent
        [HttpPost]
        public async Task<IActionResult> PostHeaAgents([FromBody] Agent agent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var agentOut = await _repository.Create(agent);
            //_logger.LogInformation("Created Agent success!");
            return CreatedAtAction("GetHeaAgents", new { id = agentOut.Id }, agentOut);
        }

        // DELETE: api/Agent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeaAgents([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _repository.Delete(id);
            return Ok("Deleted");
        }
    }
}