using AutoMapper;
using HealthCareApi.Dtos;
using HealthCareApi.Models;
using HealthCareApi.Repositories;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HealthCareApi.Validators.AgentValidator
{
    public class Duplicate : ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, System.ComponentModel.DataAnnotations.ValidationContext validationContext)
        {
            var _repository = (IAgentRepository)validationContext.GetService(typeof(IAgentRepository));
            var agent = (Agent)validationContext.ObjectInstance;
            
            if (agent.AgentCode == null || agent.AgentName == null)
                return new ValidationResult("Agent code and name are required.");
            
            return (_repository.Exists(agent))
                ? ValidationResult.Success
                : new ValidationResult("Duplicate agent.");
            
        }
    }
}
