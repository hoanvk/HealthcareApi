using HealthCareApi.Repositories;
using HealthCareApi.Validators.AgentValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCareApi.Dtos
{
    public class Agent
    {        
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        [Duplicate()]
        public string AgentCode { get; set; }
        [Required]
        [StringLength(250)]
        public string AgentName { get; set; }
    }
}
