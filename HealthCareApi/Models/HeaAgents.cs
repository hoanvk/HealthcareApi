using System;
using System.Collections.Generic;

namespace HealthCareApi.Models
{
    public partial class HeaAgents
    {
        public HeaAgents()
        {
            HeaPolicyHeader = new HashSet<HeaPolicyHeader>();
        }

        public int Id { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<HeaPolicyHeader> HeaPolicyHeader { get; set; }
    }
}
